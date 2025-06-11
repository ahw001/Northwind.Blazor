using System.Text.Json.Serialization;

namespace Northwind.Blazor.Model.Cybersource.PayerAuthentication
{
    public class PaReqResponse
    {
        [JsonPropertyName("messageType")]
        public string? MessageType { get; set; }

        [JsonPropertyName("messageVersion")]
        public string? MessageVersion { get; set; }

        [JsonPropertyName("threeDSServerTransID")]
        public string? ThreeDSServerTransID { get; set; }

        [JsonPropertyName("acsTransID")]
        public string? AcsTransID { get; set; }

        [JsonPropertyName("challengeWindowSize")]
        public string? ChallengeWindowSize { get; set; }

    }
}
