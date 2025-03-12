using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCharp.HttpTracerClient
{
    public class TracerClientt
    {
        private string url = "https://jsonplaceholder.typicode.com/posts";
        private string complexUrl = "https://dummyjson.com/posts/add";
        Random random = new Random();
        [Test]
        public void TracerTest()
        {
            int id = random.Next(1000);
            string jsonData = $"{{\r\n  \"title\": \"Exploring the Future of AI\",\r\n  \"body\": \"Artificial Intelligence is transforming the world, from automation to decision-making.\",\r\n  \"userId\": {id}\r\n}}\r\n";
            var options = new RestClientOptions()
            {
                ConfigureMessageHandler = handler => new HttpTracerHandler(handler) // Attach Tracer
            };


            IRestClient restClient = new RestClient(options);
            RestRequest restRequest = new RestRequest(url, Method.Post);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(jsonData);
            var restResponse = restClient.Post(restRequest);
            Console.WriteLine(restResponse.Content);
            Console.WriteLine(restResponse.StatusCode);
            Console.WriteLine(restResponse.IsSuccessful);



        }
    }
}
