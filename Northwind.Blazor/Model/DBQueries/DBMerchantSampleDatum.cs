using System.Text.Json.Serialization;

namespace Northwind.Blazor.Model.DBQueries;

public partial class DBMerchantSampleDatum
{
    [JsonPropertyName("sampleMerchantId")]
    public int SampleMerchantId { get; set; }

    [JsonPropertyName("organizationId")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("configurable")]
    public string? Configurable { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("administrativeArea")]
    public string? AdministrativeArea { get; set; }

    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    [JsonPropertyName("businessContactFirstName")]
    public string? BusinessContactFirstName { get; set; }

    [JsonPropertyName("businessContactLastName")]
    public string? BusinessContactLastName { get; set; }

    [JsonPropertyName("businessContactPhoneNumber")]
    public string? BusinessContactPhoneNumber { get; set; }

    [JsonPropertyName("businessContactEmail")]
    public string? BusinessContactEmail { get; set; }

    [JsonPropertyName("technicalContactFirstName")]
    public string? TechnicalContactFirstName { get; set; }

    [JsonPropertyName("technicalContactLastName")]
    public string? TechnicalContactLastName { get; set; }

    [JsonPropertyName("technicalContactphoneNumber")]
    public string? TechnicalContactphoneNumber { get; set; }

    [JsonPropertyName("technicalContactEmail")]
    public string? TechnicalContactEmail { get; set; }

    [JsonPropertyName("emergencyContactFirstName")]
    public string? EmergencyContactFirstName { get; set; }

    [JsonPropertyName("emergencyContactLastName")]
    public string? EmergencyContactLastName { get; set; }

    [JsonPropertyName("emergencyContactPhoneNumber")]
    public string? EmergencyContactPhoneNumber { get; set; }

    [JsonPropertyName("emergencyContactEmail")]
    public string? EmergencyContactEmail { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("websiteUrl")]
    public string? WebsiteUrl { get; set; }

    [JsonPropertyName("businessInformationPhoneNumber")]
    public string? BusinessInformationPhoneNumber { get; set; }

    [JsonPropertyName("businessInformationTimeZone")]
    public string? BusinessInformationTimeZone { get; set; }

    [JsonPropertyName("merchantCategoryCode")]
    public int? MerchantCategoryCode { get; set; }
}
