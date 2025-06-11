using Northwind.Blazor.Model.Cybersource.CloudPos;
using Northwind.Blazor.Model.OutboundObjects;
using System.Text.Json.Nodes;

namespace Northwind.Blazor.Model.Cybersource.Transactions
{
    public class SessionTransJson
    {
        public string? TransactionId { get; set; } = string.Empty;
        public string? TransactionType { get; set; }
        public CcTransactionTypes? OriginalTransactionType { get; set; }
        public CcTransactionTypes? CurrentTransactionType { get; set; }
        public JsonNode? TransactionJson { get; set; }
        public B2cCustomer? Customer { get; set; }
        public CloudPaymentResponseJson? CloudPaymentResponseJson { get; set; }
        public string? TransactionState { get; set; }
        public string? TransactionStatus { get; set; }
        public string? TransactionOrderId { get; set; }
        public string? OriginalTransactionId { get; set; }
        public string? TransactionAmount { get; set; }
        public string? ReconciliationId { get; set; }
        public string? TransientToken { get; set; }
        public TransactionStateValues? JsonTransactionStateValues { get; set; }
        public CcTransactionTypes? FollowOnTransaction { get; set; }
        public string error { get; set; } = string.Empty;

    }
}
