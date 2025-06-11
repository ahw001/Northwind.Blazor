using System.Text.Json.Serialization;

namespace Northwind.Blazor.Model.OutboundObjects
{
    public class SimpleJsonObject
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = null!;

        [JsonPropertyName("value")]
        public string Value { get; set; } = null!;

        [JsonPropertyName("resource")]
        public string Resource { get; set; } = null!;
    }
}
