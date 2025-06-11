using Northwind.Blazor.Model.DBQueries;

namespace Northwind.Blazor.Services.DIServices
{
    public class CartService : ICartService
    {

        private List<DBProduct> cart = new();
        private int totalNumberofItems;
        private decimal? totalPrice = 0;
        public Guid value = Guid.NewGuid();


        public CartService()
        {
            totalNumberofItems = 0;
        }

        public CartService(int initialTotal)
        {

            totalNumberofItems = initialTotal;
        }

        public Guid Value
        {
            get => value;
        }

        public IList<DBProduct> Cart
        {
            get => cart;
        }

        public decimal? Total
        {
            get => totalPrice;
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        decimal? price = 0;
        public void AddProduct(DBProduct product)
        {

            cart.Add(product);
            totalPrice += product.UnitPrice;
            price += product.UnitPrice;
            NotifyStateChanged();
        }
        public void DeleteProduct(DBProduct product)
        {
            cart.Remove(product);
            totalPrice -= product.UnitPrice;
            NotifyStateChanged();
        }

        public void DeleteAll()
        {
            price = 0; totalPrice = 0;
            cart.Clear();
            value = Guid.NewGuid();
        }

    }
}
