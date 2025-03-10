using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RestCharp
{
    public class User
    {
       
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
    public class JwtToken
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
    public class JsonAuthenticator:AuthenticatorBase
    {   // Username and password of the User
        private readonly string _baseUrl;
        private readonly User _userData;

        public JsonAuthenticator(string baseUrl, User userData) : base("")
        {
            _baseUrl = baseUrl;
            _userData = userData;
        }

        protected override ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            Token = string.IsNullOrEmpty(Token) ? GetToken() : Token;
            return new ValueTask<Parameter>(new HeaderParameter(KnownHeaders.Authorization, Token));
        }
     
        private string GetToken()
        {
            using (var client = new RestClient(_baseUrl))
            {
                // Create a Request for the User Registration /users/sign-up
                var regResponse = client.PostJson<User>("api/login", _userData);

            
                // Create a Second Request for authenticating the created user /users/authenticate
                var authResponse = client.PostJson<User, JwtToken>("users/authenticate", _userData);
                
                if (string.IsNullOrEmpty(authResponse?.Token))
                {
                    throw new Exception("Authentication failed! No token received.");
                }

                return $"Bearer {authResponse.Token}";
            }
        }}

    }
        
    

