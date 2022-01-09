using LifeDekApi.Entities;

namespace LifeDekApi.Daos.Interfaces
{
    public interface ICardDao
    {
        IEnumerable<Card> GetCards();
        Card GetCard(Guid id);
        Card CreateCard(Card request);
        Card UpdateCard(Card request);
        Card DeleteCard(Guid id);
    }
}