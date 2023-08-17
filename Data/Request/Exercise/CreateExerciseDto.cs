namespace GymApi.Data.Request.Exercise;

public class CreateExerciseDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Picture { get; set; }
}
