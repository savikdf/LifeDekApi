using LifeDekApi.Daos.Interfaces;
using LifeDekApi.Daos;
using LifeDekApi.Models;
using LifeDekApi.Services.Interfaces;

namespace LifeDekApi.Services
{
    public class CardService : ICardService
    {
        private readonly ICardDao cardDao;

        public CardService() : this(new CardDao()){}
        public CardService(ICardDao cardDao)
        {
            this.cardDao = cardDao;
        }

        public Card GetCard(Guid id)
        {
            return cardDao.GetCard(id);
        }

        public IEnumerable<Card> GetCards()
        {
            return cardDao.GetCards();
        }
    }
}