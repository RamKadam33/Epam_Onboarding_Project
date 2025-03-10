using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCharp.HttpTracerClient
{
    public class HttpTracerHandler : DelegatingHandler
    {
        public HttpTracerHandler(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            Console.WriteLine($"[HTTP Request] {request.Method} {request.RequestUri}");
            if (request.Content != null)
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                Console.WriteLine($"[Request Body]: {requestBody}");
            }

            var response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine($"[HTTP Response] {response.StatusCode}");
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"[Response Body]: {responseBody}");

            return response;
        }
    }
    }
