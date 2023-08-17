namespace GymApi.Data.Response.GymClient;
public class ReadGymClientDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public double Weight { get; set; }
    public double ArmCircunference { get; set; }
    public double WaistCircunference { get; set; }
    public double AbdomenCircunference { get; set; }
    public double ChestCircunference { get; set; }
    public int WorkoutId { get; set; }
}
