using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RestCharp.PostRequestPrac
{
    class PostRequestTest
    {
        private string url = "https://jsonplaceholder.typicode.com/posts";
        private string complexUrl = "https://dummyjson.com/posts/add";
        Random random=new Random();
        [Test]
        public void Test1()
        {
             int id=  random.Next(1000);
             string jsonData = $"{{\r\n  \"title\": \"Exploring the Future of AI\",\r\n  \"body\": \"Artificial Intelligence is transforming the world, from automation to decision-making.\",\r\n  \"userId\": {id}\r\n}}\r\n";


          
            IRestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url, Method.Post);              
           
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(jsonData);
            var restResponse = restClient.Post(restRequest);
            Console.WriteLine(restResponse.Content);
            Console.WriteLine(restResponse.StatusCode);
            Console.WriteLine(restResponse.IsSuccessful);



        }
        [Test]
        public void ComplexPostTest()
        {
            int id = random.Next(1000);
            string jsonData = $"{{\r\n  \"id\": {id},  // Unique ID (You can generate dynamically)\r\n  \"title\": \"The Rise of Artificial Intelligence\",\r\n  \"body\": \"Artificial Intelligence is revolutionizing industries worldwide, from healthcare to finance.\",\r\n  \"tags\": [\"technology\", \"AI\", \"innovation\"],\r\n  \"reactions\": {{\r\n    \"likes\": 245,\r\n    \"dislikes\": 12\r\n  }},\r\n  \"views\": 1500,\r\n  \"comments\": [\r\n    {{\r\n      \"userId\": 101,\r\n      \"comment\": \"This is a great read! AI is truly changing the world.\"\r\n    }},\r\n    {{\r\n      \"userId\": 102,\r\n      \"comment\": \"I believe ethical considerations in AI need more attention.\"\r\n    }}\r\n  ],\r\n  \"metadata\": {{\r\n    \"publishedDate\": \"2024-03-04T10:00:00Z\",\r\n    \"author\": {{\r\n      \"name\": \"John Doe\",\r\n      \"profile\": \"https://example.com/johndoe\"\r\n    }}\r\n  }},\r\n  \"userId\": 10\r\n}}\r\n";



            IRestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url, Method.Post);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "application/xml");
            //restRequest.RequestFormat = DataFormat.Json;//serialization
            restRequest.AddBody(CreatePost());
            var restResponse = restClient.Post(restRequest);
            Console.WriteLine(restResponse.Content);
            Console.WriteLine(restResponse.StatusCode);
            Console.WriteLine(restResponse.IsSuccessful);
            Console.WriteLine((int)restResponse.StatusCode);
            Console.WriteLine(restResponse.ContentType);
            Console.WriteLine(restResponse.Request);



        }
        private PostModule CreatePost()
        {
            int id = random.Next(1000);

            return new PostModule
            {
                Id = id,
                Title = "The Rise of Artificial Intelligence",
                Body = "Artificial Intelligence is revolutionizing industries worldwide, from healthcare to finance.",
                Tags = new List<string> { "technology", "AI", "innovation" },
                Reactions = new Reactions { Likes = 245, Dislikes = 12 },
                Views = 1500,
                //Comments = new List<Comment>
                //{
                //    new Comment { UserId = 101, CommentText = "This is a great read! AI is truly changing the world." },
                //    new Comment { UserId = 102, CommentText = "I believe ethical considerations in AI need more attention." }
                //},
                //Metadata = new Metadata
                //{
                //    PublishedDate = "2024-03-04T10:00:00Z",
                //    Author = new Author { Name = "John Doe", Profile = "https://example.com/johndoe" }
                //},
                UserId = 10
            };
        }
        [Test]
        public void XmlPostTest()
        {
            string url = "https://httpbin.org/post";  // Replace with your XML-supported API

            string xmlBody = @"<?xml version=""1.0"" encoding=""UTF-8""?>
        <Post>
            <Title>Artificial Intelligence Trends</Title>
            <Body>AI is evolving rapidly and shaping the future of technology.</Body>
            <Author>John Doe</Author>
        </Post>";

            var client = new RestClient();
            var request = new RestRequest(url,Method.Post);

            // ✅ Setting Headers for XML
            request.AddHeader("Content-Type", "application/xml");
            request.AddHeader("Accept", "application/xml");

            // ✅ Adding XML body
            request.AddParameter("application/xml", xmlBody, ParameterType.RequestBody);

            // ✅ Sending the request
            var response = client.Execute(request);

            // ✅ Printing the response
            Console.WriteLine("Response Content:");
            Console.WriteLine(response.Content);
            Console.WriteLine("Status Code: " + response.StatusCode);
            Console.WriteLine("Status Code: " + (int)response.StatusCode);
            Console.WriteLine("Content Type: " + response.ContentType);
        }

    }


}
