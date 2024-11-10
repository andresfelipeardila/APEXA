using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexaApp.API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string? message = null, string? details = null) : base(statusCode, message, details)
        {
            Details = details;
        }

        //public string? Details { get; set; }
    }
}