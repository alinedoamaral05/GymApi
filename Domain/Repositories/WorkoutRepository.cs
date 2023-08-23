using GymApi.Data;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories.Interfaces;
using GymApi.Exceptions;

namespace GymApi.Domain.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly GymContext _context;

    public WorkoutRepository(GymContext context)
    {
        _context = context;
    }

    public Workout Create(Workout workout)
    {
        var clientExists = _context
            .GymClients
            .Any(gymClient => gymClient.Id == workout.GymClientId);

        if (!clientExists) throw new BadRequestException();

        _context
            .Workouts
            .Add(workout);
        
        _context
            .SaveChanges();
        
        return workout;
    }

    public void Delete(Workout workout)
    {        
        _context.Workouts
            .Remove(workout);
        
        _context
            .SaveChanges();

        return;
    }

    public ICollection<Workout> FindByClient(int clientId)
    {
        var workouts = _context
            .Workouts
            .Where(workout => workout.GymClientId == clientId)
            .ToList();

        return workouts;
    }

    public Workout? FindById(int id)
    {
        var workout = _context
            .Workouts
            .FirstOrDefault(workout => workout.Id == id);
        
        return workout;
    }

    public Workout Update(Workout workout)
    {
        _context
            .Workouts
            .Update(workout);
        
        _context
            .SaveChanges();
        
        return workout;
    }
}
