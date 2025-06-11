using Northwind.Blazor.Model.DBQueries;
using Northwind.Blazor.Model.Cybersource.BaseData;
using System.ComponentModel.DataAnnotations;


namespace Northwind.Blazor.Model.OutboundObjects;

public class B2cCustomer
{
    public int B2cCustomerId { get; set; }
    
    public string? PaymentCardId { get; set; }
    public string? OrderId { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string FullName { get; set; } = null!;
    public string? MiddleName  { get; set; }
    public string? Title { get; set; }
    public string? District { get; set; }

    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? BuildingNumber { get; set; }

    public string? PhoneType { get; set; }

    [Required]
    public string? City { get; set; }

    public string? AdministrativeArea { get; set; }

    public string? Region { get; set; }

    [Required]
    public string? PostalCode { get; set; }
    [Required]
    public string? Country { get; set; }
    [Required]
    public string? Phone { get; set; }

    public string? BearerToken { get; set; }

    public string? CloudPosType { get; set; }

    public string? MerchantCustomerID { get; set; } = string.Empty;

    public string? MerchantReferenceCode { get; set; }

    public string? CustomerInstrumentId { get; set; }

    public string? InstrumentIdentifier { get; set; }

    public string? PaymentMethod { get; set; } = "Credit/Debit";

    public string? PreAuthOrOnDeviceTip { get; set; } = "Standard";

    public string? InvoiceType { get; set; } = "Draft";

    public bool ShippingSameAsBilling { get; set; }

    public bool SaveFormData { get; set; }

    public bool PerformZeroAuth { get; set; }

    [Required]
    public string? AccountNumber { get; set; } = null!;

    [Required]
    public string? ExpMonth { get; set; }
    [Required]
    public string? ExpYear { get; set; }
    [Required]
    public string? Cvv { get; set; }
    public string? CardType { get; set; } = null!;

    public string? TransientToken { get; set; }

    public string? TransientTokenJwt { get; set; }

    public bool MarkedForCapture { get; set; }

    public string[]? ActionTokenTypes { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? CompanyName { get; set; }
    public string? CompanyAddress1 { get; set; }
    public string? CompanyAdministrativeArea { get; set; }
    public string? CompanyBuildingNumber { get; set; }
    public string? CompanyCountry { get; set; }
    public string? CompanyDistrict { get; set; }
    public string? CompanyLocality { get; set; }
    public string? CompanyPostalCode { get; set; }

    public string ShippingFirstName { get; set; } = null!;

    public string ShippingLastName { get; set; } = null!;

    public string ShippingFullName { get; set; } = null!;

    public string? ShippingEmail { get; set; }

    public string? ShippingAddress1 { get; set; }

    public string? ShippingAddress2 { get; set; }

    public string? ShippingAddress3 { get; set; }

    public string? ShippingBuildingNumber { get; set; }

    public string? ShippingPhoneType { get; set; }

    public string? ShippingCity { get; set; }

    public string? ShippingAdministrativeArea { get; set; }

    public string? ShippingPostalCode { get; set; }

    public string? ShippingCountry { get; set; }

    public string? ShippingPhone { get; set; }

    public string? FreightAmount { get; set; }
    public string? TaxableFreightAmount { get; set; }

    public string? TaxDetailsType { get; set; }

    public string? TaxDetailsAmount { get; set; }
    public string? TaxDetailsRate { get; set; }

    public string? Currency { get; set; } = "USD";

    public string? PosTransId { get; set; }

    public string? IdType { get; set; }

    public string? CloudStatusType { get; set; }
    public string? Reason { get; set; }

    public bool OnDeviceTip { get; set; } = false;

    public bool PreAuthOnly { get; set; } = false;

    public bool PreAuthTip { get; set; }

    public bool IncrementalAuth { get; set; }

    public string? CloudPaymentMode { get; set; }

    public string? PosActivationCode { get; set; }

    public string? PosSetupCode { get; set; }

    public string? Error { get; set; }

    public Freight? Freight { get; set; } = new();

    public AmountDetails? AmountDetails { get; set; } = new();

    public LineItems? LineItem { get; set; } = new();

    public InvoiceInformation? InvoiceInformation { get; set; } = new();

    public AdditionalInformation? AdditionalInformation { get; set; } = new();

    public List<DBProduct>? Cart { get; set; } = new();

    public List<LineItems> LineItems { get; set; } = new();

    public ErrorObject? ErrorObject { get; set; } = new();

    public ErrorObject DbErrorObject { get; set; } = new();

}
