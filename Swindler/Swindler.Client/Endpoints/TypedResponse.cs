using System.Net;

namespace Swindler.Client.Endpoints
{
    public class TypedResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
