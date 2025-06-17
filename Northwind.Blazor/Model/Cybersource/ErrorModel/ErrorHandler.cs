using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Northwind.Blazor.Model.Cybersource.BaseData;

namespace Northwind.Blazor.Model.Cybersource.ErrorModel
{
    public class ErrorHandler
    {
    }



    public class ErrorResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("submitTimeUtc")]
        public DateTime SubmitTimeUtc { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("details")]
        public List<Detail>? Details { get; set; }

        [JsonPropertyName("clientReferenceInformation")]
        public ClientReferenceInformation? ClientReferenceInformation { get; set; }

        [JsonPropertyName("consumerAuthenticationInformation")]
        public ConsumerAuthenticationInformation? ConsumerAuthenticationInformation { get; set; }

        [JsonPropertyName("errorInformation")]
        public ErrorInformation? ErrorInformation { get; set; }

        [JsonPropertyName("response")]
        public Response Response { get; set; } = new Response();
    }

    public class Detail
    {
        [JsonPropertyName("field")]
        public string? Field { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }

}
