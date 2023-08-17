namespace GymApi.Data.Request.ExerciseDetail;

public class CreateExerciseDetailDto
{
    public double Weight { get; set; }
    public int Rep { get; set; }
    public int SeriesCount { get; set; }
    public TimeSpan RestTime { get; set; }
}
