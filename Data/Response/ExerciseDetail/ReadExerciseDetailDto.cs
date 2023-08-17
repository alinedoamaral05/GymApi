namespace GymApi.Data.Response.ExerciseDetail;

public class ReadExerciseDetailDto
{
    public int Id { get; set; }
    public double Weight { get; set; }
    public int Rep { get; set; }
    public int SeriesCount { get; set; }
    public TimeSpan RestTime { get; set; }
    public int ExerciseId { get; set; }
    public int WorkoutId { get; set; }
}
