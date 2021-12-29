using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Errors
{
    public class ApiException
    {

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string Details { get; set; }


        public ApiException(int statuscode, string message = null, string details = null)
        {
            StatusCode = statuscode;
            Message = message;
            Details = details;
        }

    }
}
