using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorCode { get; }
        public string UserMessage { get; }

        public AppException(
            string userMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            string errorCode = "APP_ERROR")
            : base(userMessage)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            UserMessage = userMessage;
        }
      
        public static AppException Create(string message, HttpStatusCode code = HttpStatusCode.BadRequest, string error = "APP_ERROR")
            => new AppException(message, code, error);
    }
}
 
