using LifeDekApi.Daos.Interfaces;
using LifeDekApi.Models;

namespace LifeDekApi.Daos
{
    public class CardDao : ICardDao
    {
        //temp in memory repo
        private List<Card> cards = new List<Card>(){
            new Card(){
              Id = new Guid(),
              Name = "Test Card 1",
              Description = "Test Description 1"
            },
            new Card(){
              Id = new Guid(),
              Name = "Test Card 2",
              Description = "Test Description 2"
            }
        };

        public Card GetCard(Guid id)
        {
            return cards.Where(c => c.Id == id).SingleOrDefault();
        }

        public IEnumerable<Card> GetCards()
        {
            return cards;
        }
    }
}