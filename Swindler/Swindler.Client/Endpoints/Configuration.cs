using System.Diagnostics;
using System.Threading.Tasks;
using Swindler.Client.Contracts;

namespace Swindler.Client.Endpoints
{
    public class Configuration : EndpointBase
    {
        private const string Api = "config";
        private readonly string _apiPath;

        public Configuration(string mountebankLocation)
        {
            _apiPath = $"{mountebankLocation}{Api}";
        }

        public async Task<SystemConfiguration> GetMountebankConfiguration()
        {
            return await GetEndpointResponse(async () =>
            {
                Trace.WriteLine("Retrieving Mountebank configuration");

                var response = await HttpGetAsync<SystemConfiguration>($"{_apiPath}");

                Trace.WriteLine("Mountebank configuration retrieved successfully:");

                return response;
            });
        }
    }
}
