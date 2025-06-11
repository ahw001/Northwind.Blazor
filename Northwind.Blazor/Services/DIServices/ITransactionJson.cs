using System.Text.Json.Nodes;

namespace Northwind.Blazor.Services.DIServices
{
    public interface ITransactionJson
    {
        IList<JsonNode> Transactions { get; }

        event Action? OnChange;

        public string TransactionJsonInfo();

        void AddTrans(JsonNode trans);
        void DeleteTrans(JsonNode trans);
    }
}