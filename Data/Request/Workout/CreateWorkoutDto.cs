namespace GymApi.Data.Request.Workout;

public class CreateWorkoutDto
{
    public required string Name { get; set; }
    public int GymClientId { get; set; }
}
