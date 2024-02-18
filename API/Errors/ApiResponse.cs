using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode {get; set;}
        public string Message {get; set;}
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int code)
        {
            return code switch
            {
                400 => "A bad request, you have made",
                401 => "Autorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side",
                _ => null
            };
        }
    }
}