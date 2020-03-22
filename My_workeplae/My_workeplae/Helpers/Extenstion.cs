using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_workeplae.Helpers
{
    public static class Extenstion 
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headersr", "Application-Error");
            response.Headers.Add("Access-Control-Aiiow-Origin", "*");

        }
    }
}
