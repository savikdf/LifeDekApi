using  LifeDekApi.Models;

namespace LifeDekApi.Services.Interfaces
{
    public interface ICardService
    {
         Card GetCard(Guid id);
         IEnumerable<Card> GetCards();
    }
}