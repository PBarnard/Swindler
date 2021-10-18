using System.Net.Http;
using System.Threading.Tasks;
using Swindler.Client.Endpoints;

namespace Swindler.Client
{
    public class SwindlerClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SwindlerClient(string mountebankUrl, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            Configuration = new Configuration(mountebankUrl, httpClientFactory);
        }

        public Configuration Configuration { get; }

        /// <summary>
        /// Returns a value indicating whether Mountebank is already running at the specified location.
        /// </summary>
        /// <returns>True if Mountebank is already running; otherwise, false.</returns>
        public async Task<bool> MountebankAvailable()
        {
            var configuration = await Configuration.GetMountebankConfiguration();

            return configuration.Process.Uptime > 0;
        }
    }
}
