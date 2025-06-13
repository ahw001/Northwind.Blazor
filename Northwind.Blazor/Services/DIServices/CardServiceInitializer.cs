namespace Northwind.Blazor.Services.DIServices
{
    public class CardServiceInitializer : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;

        public CardServiceInitializer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = serviceProvider.CreateScope();
            var sessionTransactions = scope.ServiceProvider.GetRequiredService<ISessionTransactions>();
            var cardService = scope.ServiceProvider.GetRequiredService<ICardService>();

            if (cardService is CardService concreteCardService)
            {
                try
                {
                    await concreteCardService.InitializeAsync(sessionTransactions);
                    Console.WriteLine("CardService initialized successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"CardService initialization failed: {ex.Message}");
                }
            }
        }

    }
}
