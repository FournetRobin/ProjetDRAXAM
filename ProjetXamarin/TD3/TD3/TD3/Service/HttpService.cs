using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace TD3.Service
{
    public static class HttpService
    {
        static HttpClient client;

        public static HttpClient GetInstance()
        {
            if(client == null)
            {
                client = new HttpClient();
            }
            return client;
        }
    }
}
