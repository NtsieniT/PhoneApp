using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            // 
            response.Headers.Add("Application-Error", message);

            // CORS Headers for angular to get proper access control header
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");

            // To allow cross origin between application eg angular from any origin
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
