namespace GymApi.Data.Request.ExerciseDetail;

public class UpdateExerciseDetailDto
{
    public int ExerciseId { get; set; }
    public int WorkoutId { get; set; }
    public double Weight { get; set; }
    public int Rep { get; set; }
    public int SeriesCount { get; set; }
    public TimeSpan RestTime { get; set; }
}
