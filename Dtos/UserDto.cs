using System.ComponentModel.DataAnnotations;

namespace LifeDekApi.Dtos
{
    public class UserDto
    {
        public Guid Guid { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
