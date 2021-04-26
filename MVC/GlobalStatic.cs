using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MVC
{
    public static class GlobalStatic
    {
        public static HttpClient WebApiClient = new HttpClient();
        static GlobalStatic()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:57131/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}