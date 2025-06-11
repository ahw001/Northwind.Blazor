using System.Text.Json.Serialization;


namespace Northwind.Blazor.Model.Cybersource.Boarding
{
    public class BoardingResponseRoot
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("submitTimeUtc")]
        public string? SubmitTimeUtc { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("details")]
        public List<Details>? Details { get; set; }

        [JsonPropertyName("registrationInformation")]
        public RegistrationInformation? RegistrationInformation { get; set; }

        [JsonPropertyName("organizationInformation")]
        public OrganizationInformation? OrganizationInformation { get; set; }
    }

    public class Details
    {
        [JsonPropertyName("field")]
        public string? Field { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }

    public class RegistrationInformation
    {
        [JsonPropertyName("mode")]
        public string? Mode { get; set; }

        [JsonPropertyName("boardingPackageId")]
        public string? BoardingPackageId { get; set; }

        [JsonPropertyName("boardingFlow")]
        public string? BoardingFlow { get; set; }
    }

    public class OrganizationInformation
    {
        [JsonPropertyName("organizationId")]
        public string? OrganizationId { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("parentOrganizationId")]
        public string? ParentOrganizationId { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("configurable")]
        public bool? Configurable { get; set; }

        [JsonPropertyName("businessInformation")]
        public BusinessInformation? BusinessInformation { get; set; }
    }

    public class BusinessInformation
    {
        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("businessContact")]
        public Contact? BusinessContact { get; set; }

        [JsonPropertyName("technicalContact")]
        public Contact? TechnicalContact { get; set; }

        [JsonPropertyName("emergencyContact")]
        public Contact? EmergencyContact { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("websiteUrl")]
        public string? WebsiteUrl { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("timeZone")]
        public string? TimeZone { get; set; }

        [JsonPropertyName("merchantCategoryCode")]
        public string? MerchantCategoryCode { get; set; }
    }

    public class Address
    {
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
    }

    public class Contact
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }

}
