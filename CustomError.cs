using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BiblioApi
{
    public class CustomJsonResponse : JsonResult
    {
        private struct Message
        {
            public string Description { get; set; }
        }

        public CustomJsonResponse(string message, HttpStatusCode status) : base(new Message { Description = message }) 
        {
            StatusCode = (int)status;
        }
    }
}
