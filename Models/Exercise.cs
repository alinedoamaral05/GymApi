using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GymApi.Models
{
    public class Exercise
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Picture { get; set; }
    }
}
