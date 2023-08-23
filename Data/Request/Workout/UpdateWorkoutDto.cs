namespace GymApi.Data.Request.Workout;

public class UpdateWorkoutDto
{
    public int GymClientId { get; set; }
    public required string Name { get; set; }
}
