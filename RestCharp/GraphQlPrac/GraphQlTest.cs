using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using NUnit.Framework;
namespace RestCharp.GraphQlTest
{
    [TestFixture]
    public class GraphQlTest
    {
        private string url = "https://countries.trevorblades.com/";

        [Test]
        public void TestGraphQl()
        {
            var client = new RestClient();

            // GraphQL Query to get country details
            string query = @"{
            ""query"": ""query { country(code: \""IN\"") { name capital currency } }""
        }";

            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(query);

            var response = client.Execute(request);
            Console.WriteLine("GraphQL Response: " + response.Content);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("Query failed: " + response.ErrorMessage);
                return;
            }

            // Parse JSON response
            var jsonResponse = JObject.Parse(response.Content);
            var country = jsonResponse["data"]?["country"];
            Console.WriteLine("Extracted Country Info: " + country);
            Console.WriteLine("Extracted Country Info: " + jsonResponse);
        }
        [Test]
        public void secondTest()
        {
            var client = new RestClient();

            // GraphQL Query to get country details
            string query = @"{
            ""query"": ""query { countries(filter: {code: {in: [\""IN\"", \""US\""]}}) { name capital currency } }""
        }";

            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(query);

            var response = client.Execute(request);
            Console.WriteLine("GraphQL Response: " + response.Content);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("Query failed: " + response.ErrorMessage);
                return;
            }

            // Parse JSON response
            var jsonResponse = JObject.Parse(response.Content);
            var country = jsonResponse["data"]?["country"];
            Console.WriteLine("Extracted Country Info: " + country);
            Console.WriteLine("Extracted Country Info: " + jsonResponse);
        }
        [Test]
        public void TestGraphQl2()
        {
            var client = new RestClient();

            // GraphQL Query: Filter country by name (India)
            string query = @"{
            ""query"": ""query { countries(filter: {name: {eq: \""India\""}}) { code name capital currency } }""
        }";

            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(query);

            var response = client.Execute(request);
            Console.WriteLine("GraphQL Response: " + response.Content);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("Query failed: " + response.ErrorMessage);
                return;
            }

            // Parse JSON response
            var jsonResponse = JObject.Parse(response.Content);
            var countries = jsonResponse["data"]?["countries"];
            Console.WriteLine("Extracted Country Info: " + countries);
            Console.WriteLine("Extracted Country Info: " + jsonResponse);
        }
    }
}