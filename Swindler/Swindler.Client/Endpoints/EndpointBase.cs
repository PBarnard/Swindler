using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Swindler.Client.Endpoints
{
    public class EndpointBase
    {
        protected static async Task<TypedResponse<T>> HttpGetAsync<T>(string requestUri)
        {
            TypedResponse<T> output;

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(requestUri);
                var data = await result.Content.ReadAsStringAsync();

                output = new TypedResponse<T>
                {
                    StatusCode = result.StatusCode,
                    Data = JsonSerializer.Deserialize<T>(data)
                };
            }

            return output;
        }

        protected static async Task<HttpResponseMessage> HttpPostAsync<T>(string requestUri, T resource)
        {
            HttpResponseMessage output;

            using (var client = new HttpClient())
            {
                var content = JsonSerializer.Serialize(
                    resource,
                    new JsonSerializerOptions
                    {
                        IgnoreNullValues = true
                    });

                var result = await client.PostAsync(requestUri, new StringContent(content));

                output = result;
            }

            return output;
        }

        protected static async Task<HttpResponseMessage> HttpDeleteAsync(string requestUri)
        {
            HttpResponseMessage output;

            using (var client = new HttpClient())
            {
                var result = await client.DeleteAsync(requestUri);

                output = result;
            }

            return output;
        }
        protected static async Task<T> GetEndpointResponse<T>(Func<Task<TypedResponse<T>>> endpointRequest) where T : class
        {
            TypedResponse<T> response = null;
            T output = null;

            try
            {
                response = await endpointRequest();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Caught exception retrieving Mountebank response: {ex}");
            }

            if (response?.StatusCode == HttpStatusCode.OK)
            {
                output = response.Data;
            }

            return output;
        }
    }
}
