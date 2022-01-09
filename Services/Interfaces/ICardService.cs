using LifeDekApi.Dtos;

namespace LifeDekApi.Services.Interfaces
{
    public interface ICardService
    {
        CardDto GetCard(Guid id);
        IEnumerable<CardDto> GetCards();
        CardDto CreateCard(CardDto card);
        CardDto UpdateCard(CardDto request);
        CardDto DeleteCard(Guid id);
    }
}