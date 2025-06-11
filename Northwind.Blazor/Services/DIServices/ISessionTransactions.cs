using Northwind.Blazor.Model.Cybersource.Transactions;

namespace Northwind.Blazor.Services.DIServices
{
    public interface ISessionTransactions
    {
        IList<SessionTransJson> Transactions { get; }

        event Action? OnChange;

        void AddTrans(SessionTransJson trans);
        void DeleteAll();
        void DeleteTrans(SessionTransJson trans);
        string TransactionJsonInfo();
    }
}