using Northwind.Blazor.Model.Cybersource.Authorization;
using Northwind.Blazor.Model.OutboundObjects;

namespace Northwind.Blazor.Services.DIServices
{
    public interface ICustomersScoped
    {
        IList<B2cCustomer> CustData { get; }
        Guid Value { get; }

        event Action? OnChange;

        void AddCustData(B2cCustomer custInfo);
        void DeleteCustData(B2cCustomer custInfo);

        public void DeleteAll();
        
        void AddAuthTransReponse(AuthTransResponse authTransResponse);
        void DeleteAuthTransResponse(AuthTransResponse authTransResponse);
    }
}