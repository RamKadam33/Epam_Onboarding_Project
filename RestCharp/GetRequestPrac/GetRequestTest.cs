using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCharp.GetRequestPrac
{
    [TestFixture]
    internal class GetRequestTest
    {//private string Url = "https://opensource-demo.orangehrmlive.com/web/index.php/api/v2/core/about";
        private string Url = "https://jsonplaceholder.typicode.com/users";
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
        public void Test3()
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

    
}
}
