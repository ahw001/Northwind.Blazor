namespace Northwind.Blazor.Model.Cybersource.SecureAcceptance
{
    public class SecureAcceptanceFields
    {
        public string access_key = "4668ae2d6ec638899107cf534c3bd93d";

        public string profile_id = "SaDefault";

        public string transaction_uuid = Guid.NewGuid().ToString();

        public string signed_field_names = "access_key,profile_id," +
            "transaction_uuid,signed_field_names,unsigned_field_names," +
            "signed_date_time,locale,transaction_type,reference_number,amount,currency";
        public string? unsigned_field_names { get; set; }
        public string? signed_date_time { get; set; }
        public string? locale { get; set; }
        public string? transaction_type { get; set; }
        public string? reference_number { get; set; }
        public string? amount { get; set; }
        public string? currency { get; set; }
        public string? signature { get; set; }
    }
}
