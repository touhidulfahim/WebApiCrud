using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CRUDMVC
{
    public static class CustomerClient
    {
        public static HttpClient ApiCLient = new HttpClient();

        static CustomerClient()
        {
            ApiCLient.BaseAddress = new Uri("http://localhost:37482/api/");
            ApiCLient.DefaultRequestHeaders.Clear();
            ApiCLient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}