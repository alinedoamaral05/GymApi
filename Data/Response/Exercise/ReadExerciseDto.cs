using System.ComponentModel.DataAnnotations;

namespace GymApi.Data.Response.Exercise;

public class ReadExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Picture { get; set; }
}
