using Northwind.Blazor.Model.DBQueries;

namespace Northwind.Blazor.Services.DIServices
{
    public interface ICartService
    {
        IList<DBProduct> Cart { get; }
        decimal? Total { get; }
        public Guid Value { get; }

        event Action OnChange;
        void AddProduct(DBProduct product);
        void DeleteProduct(DBProduct product);

        public void DeleteAll();

    }
}

