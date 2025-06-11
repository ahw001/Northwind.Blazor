

namespace Northwind.Blazor.Model.DBQueries
{
    public class DbResultB2cCustomer
    {
        public int B2cCustomerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public ICollection<DBPaymentCardInfo> PaymentCardInfos { get; set; } = new List<DBPaymentCardInfo>();
    }
}
