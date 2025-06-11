using Northwind.Blazor.Model.Cybersource.Transactions;


namespace Northwind.Blazor.Services.DIServices
{
    public class SessionTransactions : ISessionTransactions
    {
        private List<SessionTransJson> sessionTransactions { get; set; } = new();

        public string TransactionJsonInfo()
        {
            string count = sessionTransactions.Count().ToString();
            return count;
        }

        public IList<SessionTransJson> Transactions
        {
            get => sessionTransactions;
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void AddTrans(SessionTransJson trans)
        {
            sessionTransactions.Add(trans);
            NotifyStateChanged();
        }
        public void DeleteTrans(SessionTransJson trans)
        {
            sessionTransactions.Remove(trans);
            NotifyStateChanged();
        }

        public void DeleteAll()
        {
            sessionTransactions.Clear();
        }
    }
}
