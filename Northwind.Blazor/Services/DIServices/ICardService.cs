using Northwind.Blazor.Model.DBQueries;
using Northwind.Blazor.Services.DTOs;

namespace Northwind.Blazor.Services.DIServices
{
    public interface ICardService
    {
        IList<PayerAuthCardSampleDto> Cards { get; }

        event Action OnChange;

        void AddCardList(IList<PayerAuthCardSampleDto> payerAuthCardSampleDtos);
        void AddCard(PayerAuthCardSampleDto payerAuthCardSampleDto);
        void DeleteCard(PayerAuthCardSampleDto payerAuthCardSampleDto);

        public void DeleteAll();
    }
}
