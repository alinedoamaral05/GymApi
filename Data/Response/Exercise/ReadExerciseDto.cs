namespace GymApi.Data.Response.Exercise;

public class ReadExerciseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Picture { get; set; }
}
