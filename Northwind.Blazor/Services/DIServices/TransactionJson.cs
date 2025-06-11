using System.Text.Json.Nodes;

namespace Northwind.Blazor.Services.DIServices
{
    public class TransactionJson : ITransactionJson
    {
        private List<JsonNode> transactions = new();

        public string TransactionJsonInfo()
        {
            string count = transactions.Count().ToString();
            return count;
        }

        public IList<JsonNode> Transactions
        {
            get => transactions;
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void AddTrans(JsonNode trans)
        {
            transactions.Add(trans);
            NotifyStateChanged();
        }
        public void DeleteTrans(JsonNode trans)
        {
            transactions.Remove(trans);
            NotifyStateChanged();
        }

    }
}
