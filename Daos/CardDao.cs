using LifeDekApi.Daos.Interfaces;
using LifeDekApi.Models;

namespace LifeDekApi.Daos;

public class CardDao : ICardDao
{
    //temp in memory repo
    private List<Card> cards = new List<Card>();

    private ILifeDekDbContext context;

    public CardDao() : this(new LifeDekDbContext()) { }
    public CardDao(ILifeDekDbContext context)
    {
        this.context = context;
        for (int i = 0; i < 10; i++)
        {
            cards.Add(new Card()
            {
                Guid = Guid.NewGuid(),
                Name = $"Card Name {i}",
                Description = $"Card Description {i}"
            });
        }
    }

    public IEnumerable<Card> GetCards(Guid userId)
    {
        return context.Cards.Where(c => c.UserId == userId);
    }

    public Card GetCard(Guid id)
    {
        return context.Cards.SingleOrDefault(c => c.Guid == id);
    }

    public Card CreateCard(Card request)
    {
        if (request.Guid == null)
        {
            request.Guid = new Guid();
        }

        context.Cards.Add(request);

        if (context.SaveChanges() == 0)
        {
            throw new Microsoft.EntityFrameworkCore.DbUpdateException();
        }

        return request;
    }

    public Card UpdateCard(Card request)
    {
        Card cardToUpdate = GetCard(request.Guid);
        if (cardToUpdate == null)
        {
            return null;
        }

        cardToUpdate.Name = request.Name;
        cardToUpdate.Description = request.Description;

        if (context.SaveChanges() == 0)
        {
            throw new Microsoft.EntityFrameworkCore.DbUpdateException();
        }

        return cardToUpdate;
    }

    public Card DeleteCard(Guid id)
    {
        Card cardToDelete = GetCard(id);
        if (cardToDelete == null)
        {
            return null;
        }
        context.Cards.Remove(cardToDelete);

        if (context.SaveChanges() == 0)
        {
            throw new Microsoft.EntityFrameworkCore.DbUpdateException();
        }
        return cardToDelete;
    }

}
