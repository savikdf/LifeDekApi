using LifeDekApi.Dtos;
using LifeDekApi.Entities;

namespace LifeDekApi.Extensions
{
    public static class CardExtensions
    {
        public static Card ToCardEntity(this CardDto value)
        {
            return value == null 
                ? null 
                : new Card()
                {
                    Id = value.Id,
                    Name = value.Name,
                    Description = value.Description
                };
        }

        public static CardDto ToCardDto(this Card value)
        {
            return value == null
                ? null
                : new CardDto()
                {
                    Id = value.Id,
                    Name = value.Name,
                    Description = value.Description
                };
        }



    }
}
