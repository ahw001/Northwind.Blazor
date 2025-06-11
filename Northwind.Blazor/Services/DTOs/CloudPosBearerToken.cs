using System.Text.Json.Serialization;

namespace Northwind.Blazor.Services.DTOs
{
    public class CloudPosBearerToken
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
