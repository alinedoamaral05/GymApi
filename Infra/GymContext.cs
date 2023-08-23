using GymApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Infra;

public class GymContext: DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseDetail> ExerciseDetails { get; set; }
    public DbSet<GymClient> GymClients { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    public GymContext(DbContextOptions<GymContext> options): base(options) {}
}
