using LifeDekApi.Models;

namespace LifeDekApi.Daos.Interfaces
{
    public interface ICardDao
    {
         Card GetCard(Guid id);
         IEnumerable<Card> GetCards();
    }
}