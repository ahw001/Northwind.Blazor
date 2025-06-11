namespace Northwind.Blazor.Services.Utilities
{
    public static class HttpClientHelper
    {
        private static IHttpClientFactory? _httpClientFactory;

        public static void Initialize(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public static HttpClient CreateClient(string name)
        {
            if (_httpClientFactory == null)
            {
                throw new InvalidOperationException("HttpClientFactory has not been initialized.");
            }

            return _httpClientFactory.CreateClient(name);
        }
    }
}
