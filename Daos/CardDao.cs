using LifeDekApi.Daos.Interfaces;
using LifeDekApi.Entities;

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

        #region Get

        public IEnumerable<Card> GetCards()
        {
            return cards;
        }

        public Card GetCard(Guid id)
        {
            return cards.Where(c => c.Id == id).SingleOrDefault();
        }

        #endregion

        #region Create

        public Card CreateCard(Card request)
        {
            if (request.Id == null) { 
                request.Id = new Guid(); 
            }
            cards.Add(request);

            return request;
        }

        #endregion

        #region Update

        public Card UpdateCard(Card request)
        {
            Card cardToUpdate = cards.SingleOrDefault(c => c.Id == request.Id);
            if(cardToUpdate == null)
            {
                return null;
            }

            cardToUpdate.Name = request.Name;
            cardToUpdate.Description = request.Description;

            return cardToUpdate;
        }

        #endregion

        #region Delete

        public Card DeleteCard(Guid id)
        {
            Card cardToDelete = cards.SingleOrDefault(c => c.Id == id);
            if(cardToDelete == null){ 
                return null; 
            }            
            cards.Remove(cardToDelete);
            return cardToDelete;
        }

        #endregion




    }
}