using Northwind.Blazor.Model.Cybersource.Authorization;
using Northwind.Blazor.Model.OutboundObjects;

namespace Northwind.Blazor.Services.DIServices
{
    public class CustomersScoped : ICustomersScoped
    {
        private List<B2cCustomer> custData = new();
        private List<AuthTransResponse> authTransResponses = new();
        public Guid value = Guid.NewGuid();

        public void DeleteAll()
        {
            custData.Clear();
        }
        public Guid Value
        {
            get => value;
        }

        public IList<B2cCustomer> CustData
        {
            get => custData;
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void AddCustData(B2cCustomer custInfo)
        {
            custData.Add(custInfo);
            NotifyStateChanged();
        }
        public void DeleteCustData(B2cCustomer custInfo)
        {
            custData.Remove(custInfo);
            NotifyStateChanged();
        }

        public void AddAuthTransReponse(AuthTransResponse authTransResponse)
        {
            authTransResponses.Add(authTransResponse);
            NotifyStateChanged();
        }
        public void DeleteAuthTransResponse(AuthTransResponse authTransResponse)
        {
            authTransResponses.Remove(authTransResponse);
            NotifyStateChanged();
        }
    }
}
