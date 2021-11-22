using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AutomationTest_GetNet.RESTRequests
{
    public static class WebRequest
    {
        public static HttpClient client = new HttpClient();

        public static HttpResponseMessage Get(string Url)
        {
            HttpRequestMessage message = new HttpRequestMessage
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(Url)
            };

            return client.SendAsync(message).Result;
        }

        public static HttpResponseMessage Post(string Url, string content)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage message = new HttpRequestMessage
            {
                Method = new HttpMethod("POST"),
                Content = new StringContent(content, Encoding.UTF8, "application/json"),
                RequestUri = new Uri(Url)
            };

            return client.SendAsync(message).Result;
        }
    }
}
