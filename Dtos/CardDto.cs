using System.ComponentModel.DataAnnotations;

namespace LifeDekApi.Dtos
{
    public class CardDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
