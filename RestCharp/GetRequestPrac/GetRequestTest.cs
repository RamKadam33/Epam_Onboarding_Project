using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestCharp.GetRequestPrac
{
    [TestFixture]
    internal class GetRequestTest
    {    //private string Url = "https://opensource-demo.orangehrmlive.com/web/index.php/api/v2/core/about";
        private string Url = "https://jsonplaceholder.typicode.com/users";
        private string XmlUrl= "https://mocktarget.apigee.net/xml";
        private byte[] credentials = System.Text.Encoding.ASCII.GetBytes("Admin:admin123");

        [Test]
        public void SimpleGet()
        {
            IRestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Url);

            restRequest.AddHeader("Authorization", "Basic " + Convert.ToBase64String(credentials));
            RestResponse res = restClient.Get(restRequest);
            Console.WriteLine(res.IsSuccessful);
            if (res.IsSuccessful)
            {
                Console.WriteLine(res.Content);
            }
            Console.WriteLine(res.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, res.StatusCode,"Status code is not working properly");
            Assert.AreEqual(200, (int)res.StatusCode, "Status code is not working properly");
            Console.WriteLine(res.ErrorMessage);
            Console.WriteLine(res.ErrorException);
        }

        [Test]
        public void TestDeserialization()
        {//not providing proper result
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Url);

            // restRequest.AddHeader("Authorization", "Basic " + credentials);
            restRequest.AddHeader("Accept", "application/json");
            //RestResponse<List<JsonRootObject>> restResponse = restClient.Execute<List<JsonRootObject>>(restRequest);
            var restResponse = restClient.Get<List<JsonRootObject>>(restRequest);

            if (restResponse != null)
            {

                Console.WriteLine($"Deserialization Successful! {restResponse.Count} items.");

                if (restResponse.Count > 0)
                    Console.WriteLine(JsonConvert.SerializeObject(restResponse[0], Formatting.Indented));
            }
            else
            {
                Console.WriteLine("Deserialization returned null.");
            }
        }
        [Test]
        public void TestDeserializationJsonData()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Url);

            restRequest.AddHeader("Accept", "application/json");

            RestResponse<List<JsonRootObject>> restResponse = restClient.Execute<List<JsonRootObject>>(restRequest);

            // Check if the response is successful
            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK && restResponse.IsSuccessful)
            {
                if (restResponse.Data != null && restResponse.Data.Count > 0)
                {
                    Console.WriteLine($"{restResponse.StatusCode}");
                    Console.WriteLine($"Status {restResponse.IsSuccessful} items.");
                    Console.WriteLine($"Deserialization Successful! {restResponse.Data.Count} items.");
                    Console.WriteLine(JsonConvert.SerializeObject(restResponse.Data[0], Formatting.Indented));
                    Console.WriteLine("Object " + restResponse.Data[0]);
                    Console.WriteLine("Name " + restResponse.Data[0].name);
                }
                else
                {
                    Console.WriteLine("Response was successful, but data is empty or null.");
                }
            }
            else
            {
                Console.WriteLine($"Request failed! Status Code: {restResponse.StatusCode}, Error: {restResponse.ErrorMessage}");
            }
        }
        [Test]
        public void DeserializationXMLData()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(XmlUrl, Method.Get);

            restRequest.AddHeader("Accept", "application/xml");

            RestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine($"Response Content: \n{restResponse.Content}");
            // Check response status
            if (restResponse.StatusCode == HttpStatusCode.OK && restResponse.IsSuccessful)
            {
                // Deserialize XML response
                XmlRootObject data = DeserializeXmlResponse<XmlRootObject>(restResponse.Content);
                Console.WriteLine("Status " + restResponse.StatusCode);
                Console.WriteLine("Successful? " + restResponse.IsSuccessful);
                if (data != null)
                {
                    Console.WriteLine("Deserialization Successful!");
                    Console.WriteLine($"Id: {data.FirstName}, Address: {data.LastName}");
                }
                else
                {
                    Console.WriteLine("Deserialization returned null.");
                }
            }
            else
            {
                Console.WriteLine($"Request failed with status code: {restResponse.StatusCode}");
            }
        }
        public static T DeserializeXmlResponse<T>(string xmlContent)
        {
            if (string.IsNullOrEmpty(xmlContent))
                return default;

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlContent))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

    }
}
