using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCharp
{
    class TestAuthenticator
    {
        private readonly string _baseUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/";
        private readonly User _userData;
        [Test]
        public async Task TestAuthenticatorAsync()
        {
            var options = new RestClientOptions(_baseUrl)
            {
                Authenticator = new JsonAuthenticator(_baseUrl, new User
                {
                    Username = "Admin",
                    Password = "admin123"
                })
            };

            var client = new RestClient(options);
            //var request = new RestRequest(_baseUrl, Method.Get);
        var request = new RestRequest("api/v1/employees", Method.Get); // Example request to get employees
            var response = await client.ExecuteAsync(request);

            Console.WriteLine($"Response: {response.StatusCode} - {response.Content}");
       
        }

        
    }
}
