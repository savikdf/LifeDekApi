using System.ComponentModel.DataAnnotations;

namespace LifeDekApi.Dtos
{
    public class CardDto
    {
        [Required]
        public Guid Guid { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
