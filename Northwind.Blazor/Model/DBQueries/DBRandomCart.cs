namespace Northwind.Blazor.Model.DBQueries;

public class DBRandomCart
{
    public List<DBProduct> cart = new();
    public int TotalNumberofItems;
    public decimal? TotalPrice = 0;
    public Guid guid = Guid.NewGuid();
    public string error = string.Empty;
}
