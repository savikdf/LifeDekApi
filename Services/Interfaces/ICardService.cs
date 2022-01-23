using LifeDekApi.Dtos;

namespace LifeDekApi.Services.Interfaces;

public interface ICardService
{
    CardDto GetCard(Guid id);
    IEnumerable<CardDto> GetCards(Guid userId);
    CardDto CreateCard(CardDto request);
    CardDto UpdateCard(CardDto request);
    CardDto DeleteCard(Guid id);
}
