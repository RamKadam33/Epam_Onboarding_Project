using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public enum StatusCode
    {
        Success = 200,
        NotFound = 404,
        InternalError = 500
    }

    internal class EnumExamples
    {
        [Test]
        public void epamEnum()
        {
            StatusCode response = StatusCode.Success;
            Console.WriteLine($"Response Status: {response} ({(int)response})");

            StatusCode errorCode = (StatusCode)404;
            Console.WriteLine($"Converted Integer to Enum: {errorCode}");
        }

    }

    public class AccessSpecifierEnum
    {
        private string requestId; 
        protected StatusCode status;
        public string Message { get; set; }

        public string RequestId => requestId;
        public StatusCode Status => status;

        public AccessSpecifierEnum(string reqId, StatusCode code, string message)
        {
            requestId = reqId;
            status = code;
            Message = message;
        }
    }

    public class SpecifierTest
    {
        //public SpecifierTest(string reqId, StatusCode code, string message)
        //: base(reqId, code, message)
        //{ }
        [Test]
        public void SpecifierMethod()
        {
            AccessSpecifierEnum response = new AccessSpecifierEnum("REQ12345", StatusCode.Success, "Request processed successfully.");
                        
            Console.WriteLine($"Request ID: {response.RequestId}");
            Console.WriteLine($"Status Code: {response.Status} ({(int)response.Status})");
            Console.WriteLine($"Message: {response.Message}");
        }
    }


}
