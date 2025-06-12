using Microsoft.Extensions.Http;
using Moq;
using Northwind.Blazor.Model.OutboundObjects;
using Northwind.Blazor.Services.Utilities;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Northwind.Tests
{

    public class PopulateBillingRealServerTests
    {
        private readonly Xunit.Abstractions.ITestOutputHelper _output;

        public PopulateBillingRealServerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private void Log(string level, string message)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            _output.WriteLine($"[{timestamp}] [{level}] {message}");
        }

        private void LogInfo(string message) => Log("INFO", message);
        private void LogError(string message) => Log("ERROR", message);

        [Fact]
        public async Task PopulateBilling_Should_RunMultipleTimesAgainstRealServer()
        {
            // 1. Create one HttpClient to reuse
            var httpClient = new HttpClient(new HttpClientHandler(), disposeHandler: false)
            {
                BaseAddress = new Uri("http://localhost:7173")
            };

            // 2. Return the SAME client every time from the mock
            var mockFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            mockFactory
                .Setup(f => f.CreateClient(It.Is<string>(name => name == "Northwind.WebApi.Service")))
                .Returns(httpClient);

            // 3. Initialize your static helper ONCE
            HttpClientHelper.Initialize(mockFactory.Object);

            for (int i = 0; i < 100; i++)
            {
                var result = await GeneralUtilities.PopulateBilling();

                if (!string.IsNullOrEmpty(result.Error))
                {
                    _output.WriteLine($"[Run {i + 1}] ❌ Error: {result.Error}");
                }
                else
                {
                    var json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
                    _output.WriteLine($"[Run {i + 1}] ✅ Customer:\n{json}");
                }

                await Task.Delay(75);
            }
        }


    }

}

