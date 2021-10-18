using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Shouldly;
using Swindler.Client;
using Swindler.Client.Contracts;
using Xunit;

namespace Swindler.Tests.Unit.Endpoints
{
    public class ConfigurationTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactory;

        public ConfigurationTests()
        {
            _httpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
        }

        [Fact]
        public async Task MountebankIsRunning_ProcessUptimeHasValue_ReturnsOk()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(CreateSystemConfiguration())),
            };

            _httpClientFactory
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(CreateHttpClientMock(response));

            var swindlerClient = new SwindlerClient("http://mountebank", _httpClientFactory.Object);

            var available = await swindlerClient.MountebankAvailable();

            available.ShouldBeTrue();
        }

        private static HttpClient CreateHttpClientMock(HttpResponseMessage expectedResponse)
        {
            var handler = new Mock<DelegatingHandler>();

            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(expectedResponse);

            handler.As<IDisposable>().Setup(s => s.Dispose());

            return new HttpClient(handler.Object);
        }

        private static SystemConfiguration CreateSystemConfiguration()
        {
            return new SystemConfiguration
            {
                Process = new Process
                {
                    Uptime = 100
                }
            };
        }
    }
}
