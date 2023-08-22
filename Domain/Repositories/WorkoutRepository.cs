using GymApi.Data;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        

    }

    public void DeleteById(int clientId, Workout workout)
    {
        var client = _context.GymClients
            .Include(client => client.Workouts)
            .FirstOrDefault(client => client.Id == clientId);
        
        client.Workouts.Remove(workout);

    }

    public ICollection<Workout> FindAll(int clientId)
    {
        var client = _context.GymClients
            .Include(client => client.Workouts)
            .FirstOrDefault(client => client.Id == clientId);

        var workouts = client.Workouts;

        return workouts;
    }

    public Workout FindById(int clientId, int id)
    {
        var client = _context.GymClients
            .Include(client => client.Workouts)
            .FirstOrDefault(client => client.Id == clientId);

        var workout = client.Workouts
            .FirstOrDefault(workout => workout.Id == id);

        return workout;
    }

    public Workout Update(Workout workout)
    {
        throw new NotImplementedException();
    }
}
