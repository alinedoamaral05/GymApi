using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GymApi.Domain.Models;

public class GymClient
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public double Weight { get; set; }
    [Required]
    public double ArmCircunference { get; set; }
    [Required]
    public double WaistCircunference { get; set; }
    [Required]
    public double AbdomenCircunference { get; set; }
    [Required]
    public double ChestCircunference { get; set; }
    [JsonIgnore]
    public ICollection<Workout> Workouts { get; set; }
    public GymClient()
    {
        Workouts = new List<Workout>();
    }

}