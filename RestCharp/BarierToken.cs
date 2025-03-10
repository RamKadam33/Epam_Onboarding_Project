using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCharp
{
    class ApiKeyAuthenticator : AuthenticatorBase
    {
        private readonly string _apiKey;

        public ApiKeyAuthenticator(string apiKey) : base("")
        {
            _apiKey = apiKey;
        }

        protected override ValueTask<Parameter> GetAuthenticationParameter(string _)
            => new ValueTask<Parameter>(new HeaderParameter("x-api-key", _apiKey));
    }
    class BarierToken
    {
        [Test]
        public async Task BT()
        {
            var options = new RestClientOptions("https://opensource-demo.orangehrmlive.com/web/index.php/")
            {
                Authenticator = new ApiKeyAuthenticator("your-api-key")
            };

            var client = new RestClient(options);
            var request = new RestRequest("/custom-auth-endpoint", Method.Get);

            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }
}
