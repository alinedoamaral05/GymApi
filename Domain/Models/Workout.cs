using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GymApi.Domain.Models;

public class Workout
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required]
    public required string Name { get; set; }
    
    [Required]
    public int GymClientId { get; set; }
    
    public GymClient GymClient { get; set; }
    
    [JsonIgnore]
    public ICollection<ExerciseDetail> ExerciseDetails { get; set; }
    
    public Workout()
    {
        ExerciseDetails = new List<ExerciseDetail>();
    }
}
