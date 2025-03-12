using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace RestCharp
{
    [TestFixture]
    public class Tests
    {
        //private string Url = "https://opensource-demo.orangehrmlive.com/web/index.php/api/v2/core/about";
        private string Url = "https://mocktarget.apigee.net/xml";
        private byte[] credentials = System.Text.Encoding.ASCII.GetBytes("Admin:admin123");

        [Test]
        public void SimpleGet()
        {
            IRestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Url);

            restRequest.AddHeader("Authorization", "Basic " + Convert.ToBase64String(credentials));
            RestResponse res = restClient.Get(restRequest);
            Console.WriteLine(res.IsSuccessful);
            if(res.IsSuccessful)
            {
                Console.WriteLine(res.Content);
            }
            Console.WriteLine(res.StatusCode);
            Console.WriteLine(res.ErrorMessage);
            Console.WriteLine(res.ErrorException);
        }

       
        [Test]
        public void Test3()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Url,Method.Get);

            restRequest.AddHeader("Accept", "application/xml");

            RestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine($"Response Content: \n{restResponse.Content}");
            // Check response status
            if (restResponse.StatusCode == HttpStatusCode.OK && restResponse.IsSuccessful)
            {
                // Deserialize XML response
                 XmlRootObject data = DeserializeXmlResponse<XmlRootObject>(restResponse.Content);
                Console.WriteLine("Status "+ restResponse.StatusCode);
                Console.WriteLine("Successful? "+ restResponse.IsSuccessful);
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

        //public static T DeserializeXmlResponse<T>(string xmlContent)
        //{
        //    if (string.IsNullOrEmpty(xmlContent))
        //        return default;

        //    XmlSerializer serializer = new XmlSerializer(typeof(T));
        //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        //    ns.Add("", ""); // Removes unexpected namespaces

        //    using (StringReader reader = new StringReader(xmlContent))
        //    {
        //        XmlReaderSettings settings = new XmlReaderSettings
        //        {
        //            IgnoreWhitespace = true
        //        };

        //        using (XmlReader xmlReader = XmlReader.Create(reader, settings))
        //        {
        //            return (T)serializer.Deserialize(xmlReader);
        //        }
        //    }
        //}


    }
}