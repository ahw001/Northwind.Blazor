using Northwind.Blazor.Services.DIServices;

namespace Northwind.Blazor.Services.Utilities
{
    public class GetSessionTransactions
    {
        private readonly IServiceScopeFactory? _scopeFactory;

        public GetSessionTransactions()
        { }

        public GetSessionTransactions(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public SessionTransactions CreateAndUseSessionTransactions()
        {
            using (var scope = _scopeFactory?.CreateScope())
            {
                var sessionTransactions = scope!.ServiceProvider.GetRequiredService<ISessionTransactions>();
                return (SessionTransactions)sessionTransactions;

            }
        }
    }
}
