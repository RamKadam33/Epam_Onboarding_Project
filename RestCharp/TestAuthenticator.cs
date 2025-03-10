using RestSharp;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestSharp
{
    // Define the User class to send login credentials
    public class User
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    // Define the JWT Token response class
    public class JwtTokenResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }

    class Program
    {
        private static readonly string _baseUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/";
        [Test]
        public async Task Main1()
        {
            // User credentials
            var user = new User
            {
                Username = "Admin",
                Password = "admin123"
            };

            // Step 1: Get Bearer Token
            string token = await GetBearerToken(user);
            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("Failed to authenticate.");
                return;
            }

            Console.WriteLine($"✅ Bearer Token: {token}");

            // Step 2: Use Bearer Token for an authenticated API request
            // await GetEmployeeList(token);
        }

        // Method to authenticate and get Bearer Token
        static async Task<string> GetBearerToken(User user)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("auth/login", Method.Post);
            request.AddJsonBody(user);

            var response = await client.ExecuteAsync<JwtTokenResponse>(request);

            if (response.IsSuccessful && response.Data != null && !string.IsNullOrEmpty(response.Data.Token))
            {
                return $"Bearer {response.Data.Token}"; 
            }

            Console.WriteLine($"❌ Authentication Failed: {response.Content}");
            return null;
        }

        // Method to make an authenticated request using Bearer Token
        static async Task GetEmployeeList(string token)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/v1/employees", Method.Get);
            request.AddHeader("Authorization", token); // Add Bearer Token

            var response = await client.ExecuteAsync(request);
            Console.WriteLine("📌 Employee List Response:");
            Console.WriteLine(response.Content);
        }
    }
}
