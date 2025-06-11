using System.ComponentModel.DataAnnotations;

namespace Northwind.Blazor.Model.DBQueries;

public class DBPaymentCardInfo
{
    public int PaymentCardId { get; set; }

    public int B2cCustomerId { get; set; }
    [Required]
    public string? AccountNumber { get; set; } = null!;

    public string? TokenValue { get; set; }
    [Required]
    public string? ExpMonth { get; set; }
    [Required]
    public string? ExpYear { get; set; }
    [Required]
    public string? Cvv { get; set; }

    public string? PaymentAccountReferenceNumber { get; set; }

    public string? TokenizedCardType { get; set; }

    public string? InstrumentidentifierNew { get; set; }

    public string? InstrumentIdentifierId { get; set; }

    public string? InstrumentIdentifierState { get; set; }

    public string? PaymentInstrumentId { get; set; }

    public DBPaymentCardInfo? paymentCardInfo { get; set; }

}

