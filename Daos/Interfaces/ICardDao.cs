using LifeDekApi.Models;

namespace LifeDekApi.Daos.Interfaces;

public interface ICardDao
{
    IEnumerable<Card> GetCards(Guid userId);
    Card GetCard(Guid id);
    Card CreateCard(Card request);
    Card UpdateCard(Card request);
    Card DeleteCard(Guid id);
}
