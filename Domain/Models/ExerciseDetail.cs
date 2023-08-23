using System.ComponentModel.DataAnnotations;

namespace GymApi.Domain.Models;

public class ExerciseDetail
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required]
    public double Weight { get; set; }
    
    [Required]
    public int Rep { get; set; }
    
    [Required]
    public int SeriesCount { get; set; }
    
    [Required]
    public TimeSpan RestTime { get; set; }
    
    [Required]
    public int ExerciseId { get; set; }
    
    public Exercise Exercise { get; set; }
    
    [Required]
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; }
}
