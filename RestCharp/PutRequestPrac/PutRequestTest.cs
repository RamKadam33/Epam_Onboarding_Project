using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCharp.PutRequestPrac
{
    class PutRequestTest
    {
        private string _baseUrl = "https://jsonplaceholder.typicode.com";
        Random random = new Random();
        [Test]
        public void TestPutRequest()
        {
            int id = random.Next(1000);
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("/posts/1", Method.Put);
            request.AddHeader("Content-Type", "application/json");

            var body = new
            {
                id = id,
                title = "Updated Title",
                body = "Updated body content",
                userId = 1
            };

            request.AddJsonBody(body);

            var response = client.Execute(request);

            Assert.AreEqual(200, (int)response.StatusCode, "Expected status code 200 for a successful update.");

            var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);
            responseData.
            Assert.AreEqual("Updated Title", (string)responseData.title, "Title did not update correctly.");
        }
        [Test]
        public void TestPutRequestWithPreviousAndAfterResponse()
        {

            //int id = random.Next(1000);
            var client = new RestClient("https://postman-echo.com");

            // POST request to create data
            var postRequest = new RestRequest("/post", Method.Post);
            postRequest.AddHeader("Content-Type", "application/json");
            postRequest.AddHeader("Accept", "application/json");
            postRequest.AddJsonBody(new { name = "Test Item", description = "Created via API" });
            var postResponse = client.Execute(postRequest);


            Console.WriteLine(postResponse.IsSuccessful);
            

            Console.WriteLine("POST response: " + postResponse.Content);

            
                var jsonResponse = JObject.Parse(postResponse.Content);
                string name= jsonResponse["json"]?["name"]?.ToString();

               Console.WriteLine("Name: " + name);  

               // PUT request to update data
                var putRequest = new RestRequest($"/put", Method.Put);
                putRequest.AddJsonBody(new { name = "Ram Kadam", description = "Updated via API" });
                var putResponse = client.Execute(putRequest);

                Console.WriteLine("PUT Response Content: " + putResponse.Content);

                if (!putResponse.IsSuccessful)
                {
                    Console.WriteLine("PUT request failed: " + putResponse.ErrorMessage);
                    return;
                }

                Console.WriteLine("PUT request successful.");
            
        }
    }
    }

