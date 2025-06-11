using Microsoft.Extensions.Configuration;


namespace Northwind.Blazor.Services.Utilities
{
    public class ConfigValues
    {
        private readonly IConfiguration _configuration;

        public ConfigValues(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetServereUrlAddress()
        {
            string? serverUrlAddress = _configuration["WebServiceServerURL"];
            if (serverUrlAddress is not null)
            {
                return serverUrlAddress;
            }
            else
            {
                serverUrlAddress = "false";
                return serverUrlAddress;
            }
        }

    }
}
