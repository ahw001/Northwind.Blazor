namespace Northwind.Blazor.Services.DTOs;

public partial class SampleInvoiceDetailDto
{
    public int SampleInvoiceId { get; set; }

    public string? CustomerInformationName { get; set; }

    public string? CustomerInformationEmail { get; set; }

    public string? CustomerInformationMerchantCustomerId { get; set; }

    public string? CustomerInformationCompanyName { get; set; }

    public string? InvoiceInformationInvoiceNumber { get; set; }

    public DateOnly? InvoiceInformationDueDate { get; set; }

    public string? InvoiceInformationSendImmediately { get; set; }

    public string? InvoiceInformationAllowPartialPayments { get; set; }

    public string? InvoiceInformationDeliveryMode { get; set; }

    public decimal? OrderInformationAmountDetailsTotalAmount { get; set; }

    public string? OrderInformationAmountDetailsCurrency { get; set; }

    public decimal? OrderInformationAmountDetailsDiscountAmount { get; set; }

    public decimal? OrderInformationAmountDetailsDiscountPercent { get; set; }

    public decimal? OrderInformationAmountDetailsSubAmount { get; set; }

    public decimal? OrderInformationAmountDetailsMinimumPartialAmount { get; set; }

    public string? OrderInformationAmountDetailsTaxDetailsType { get; set; }

    public decimal? OrderInformationAmountDetailsTaxDetailsAmount { get; set; }

    public decimal? OrderInformationAmountDetailsTaxDetailsRate { get; set; }

    public decimal? OrderInformationAmountDetailsFreightAmount { get; set; }

    public string? OrderInformationAmountDetailsFreightTaxable { get; set; }

    public string? OrderInformationLineItemsProductSku { get; set; }

    public int? OrderInformationLineItemsQuantity { get; set; }

    public decimal? OrderInformationLineItemsUnitPrice { get; set; }

    public decimal? OrderInformationLineItemsDiscountAmount { get; set; }

    public decimal? OrderInformationLineItemsDiscountRate { get; set; }

    public decimal? OrderInformationLineItemsTaxAmount { get; set; }

    public decimal? OrderInformationLineItemsTaxRate { get; set; }

    public decimal? OrderInformationLineItemsTotalAmount { get; set; }

    public string? Error { get; set; }
}
