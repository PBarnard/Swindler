using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Swindler.Client;
using Xunit;

namespace Swindler.Tests.Integration.Endpoints
{
    public class ConfigurationTests
    {
        private const string MountebankUrl = "http://localhost:2525";
        private readonly IHttpClientFactory _httpClientFactory;

        public ConfigurationTests()
        {
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();

            _httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        }

        [Fact]
        public async Task Mountebank_Is_Running()
        {
            var client = new SwindlerClient(MountebankUrl, _httpClientFactory);

            var available = await client.MountebankAvailable();

            available.ShouldBeTrue();
        }
    }
}
