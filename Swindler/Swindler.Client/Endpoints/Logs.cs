using System.Net.Http;
using System.Threading.Tasks;
using Swindler.Client.Contracts.Logs;

namespace Swindler.Client.Endpoints
{
    public class Logs : Endpoint
    {
        private readonly string _mountebankLocation;

        public Logs(string mountebankLocation, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _mountebankLocation = mountebankLocation;
        }

        public async Task<SystemLog> GetMountebankLogs()
        {
            return await GetEndpointResponse(async () =>
            {
                var response = await HttpGetAsync<SystemLog>($"{_mountebankLocation}logs");

                return response;
            });
        }
    }
}
