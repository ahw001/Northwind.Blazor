using Northwind.Blazor.Services.Utilities;

namespace Northwind.Blazor.Services.DBServices
{
    public static class DBCustomerServices
    {
        public static async Task<int> GetCustomerCount()
        {
            using HttpClient client = HttpClientHelper.CreateClient("Northwind.WebApi.Service");

            string path = "api/customercount";
            int result = await client.GetFromJsonAsync<int>(path);
            return result;
        }
    }
}
