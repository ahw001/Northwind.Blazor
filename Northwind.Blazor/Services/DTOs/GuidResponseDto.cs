using Northwind.Blazor.Model.Cybersource.BaseData;
using System.Text.Json.Serialization;


namespace Northwind.Blazor.Services.DTOs
{
    public class GuidResponseDto
    {
        [JsonPropertyName("guid")]
        public string? Guid { get; set; }
    }
}
