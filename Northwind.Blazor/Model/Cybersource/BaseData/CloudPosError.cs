using System.Net;
using System.Text.Json.Serialization;

namespace Northwind.Blazor.Model.Cybersource.BaseData
{
    public class CloudPosError
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("developerDescription")]
        public string? DeveloperDescription { get; set; }
    }
}

