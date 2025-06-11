using Northwind.Blazor.Model.Cybersource.BaseData;
using System.Text.Json.Serialization;

namespace Northwind.Blazor.Model.Cybersource.FollowOnTransactions
{
    public class FollowOnInvoiceTransResponse
    {
        [JsonPropertyName("_links")]
        public Links? Links { get; set; }

        [JsonPropertyName("clientReferenceInformation")]
        public ClientReferenceInformation? ClientReferenceInformation { get; set; }

        [JsonPropertyName("consumerAuthenticationInformation")]
        public ConsumerAuthenticationInformation? ConsumerAuthenticationInformation { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("issuerInformation")]
        public IssuerInformation? IssuerInformation { get; set; }

        [JsonPropertyName("orderInformation")]
        public OrderInformationNumeric? OrderInformation { get; set; }

        [JsonPropertyName("paymentAccountInformation")]
        public PaymentAccountInformation? PaymentAccountInformation { get; set; }

        [JsonPropertyName("paymentInformation")]
        public PaymentInformation? PaymentInformation { get; set; }

        [JsonPropertyName("pointOfSaleInformation")]
        public PointOfSaleInformation? PointOfSaleInformation { get; set; }

        [JsonPropertyName("processorInformation")]
        public ProcessorInformation? ProcessorInformation { get; set; }

        [JsonPropertyName("reconciliationId")]
        public string? ReconciliationId { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("submitTimeUtc")]
        public string? SubmitTimeUtc { get; set; }

        [JsonPropertyName("tokenInformation")]
        public TokenInformation? TokenInformation { get; set; }

        [JsonPropertyName("object")]
        public string? TokenObject { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("tokenReferenceId")]
        public string? TokenReferenceId { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [JsonPropertyName("requestorId")]
        public string? RequestorId { get; set; }

        [JsonPropertyName("PaymentCardId")]
        public string? PaymentCardId { get; set; }

        [JsonPropertyName("errorInformation")]
        public ErrorInformation? ErrorInformation { get; set; }

        [JsonPropertyName("tokenizedCard")]
        public TokenizedCard? TokenizedCard { get; set; }

        [JsonPropertyName("card")]
        public CardDetails? Card { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

    }

}
