using LifeDekApi.Daos.Interfaces;
using LifeDekApi.Daos;
using LifeDekApi.Models;
using LifeDekApi.Dtos;
using LifeDekApi.Services.Interfaces;

namespace LifeDekApi.Services;

public class CardService : ICardService
{
    private readonly ICardDao cardDao;

    public CardService() : this(new CardDao()) { }
    public CardService(ICardDao cardDao)
    {
        this.cardDao = cardDao;
    }

    public CardDto CreateCard(CardDto request)
    {
        Card model = (Card)request;
        return (CardDto)cardDao.CreateCard(model);
    }

    public CardDto DeleteCard(Guid id)
    {
        Card model = cardDao.DeleteCard(id);
        return (CardDto)model;
    }

    public CardDto GetCard(Guid id)
    {
        Card model = cardDao.GetCard(id);
        return (CardDto)model;
    }

    public IEnumerable<CardDto> GetCards(Guid userId)
    {
        IEnumerable<Card> models = cardDao.GetCards(userId);
        return models.Select(c => (CardDto)c);
    }

    public CardDto UpdateCard(CardDto request)
    {
        Card model = (Card)request;
        return (CardDto)cardDao.UpdateCard(model);
    }
}
