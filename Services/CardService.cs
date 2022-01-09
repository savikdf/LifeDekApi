using LifeDekApi.Daos.Interfaces;
using LifeDekApi.Daos;
using LifeDekApi.Entities;
using LifeDekApi.Dtos;
using LifeDekApi.Services.Interfaces;
using LifeDekApi.Extensions;

namespace LifeDekApi.Services
{
    public class CardService : ICardService
    {
        #region ctor
        private readonly ICardDao cardDao;

        public CardService() : this(new CardDao()) { }
        public CardService(ICardDao cardDao)
        {
            this.cardDao = cardDao;
        }

        public CardDto CreateCard(CardDto card)
        {
            Card cardEntity = card.ToCardEntity();
            return cardDao.CreateCard(cardEntity).ToCardDto();
        }

        public CardDto DeleteCard(Guid id)
        {
            Card cardEntity = cardDao.DeleteCard(id);
            return cardEntity.ToCardDto();
        }

        public CardDto GetCard(Guid id)
        {
            Card cardEntity = cardDao.GetCard(id);
            return cardEntity.ToCardDto();
        }

        public IEnumerable<CardDto> GetCards()
        {
            IEnumerable<Card> cardEntities = cardDao.GetCards();
            return cardEntities.Select(c => c.ToCardDto());
        }

        public CardDto UpdateCard(CardDto request)
        {
            Card cardEntity = request.ToCardEntity();
            return cardDao.UpdateCard(cardEntity).ToCardDto();
        }

        #endregion

    }
}