using System.Text.Json.Serialization;

namespace Northwind.Blazor.Model.DBQueries;

public partial class DBSampleCustomerDatum
{
    [JsonPropertyName("sampleCustomerId")]
    public int SampleCustomerId { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = null!;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = null!;

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    [JsonPropertyName("_links")]
    public string? Address2 { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("ipAddressV4")]
    public string? IpAddressV4 { get; set; }

    [JsonPropertyName("ipAddressV6")]
    public string? IpAddressV6 { get; set; }

    [JsonPropertyName("errror")]
    public string? errror { get; set; }
}
