using GymApi.Data;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories.Interfaces;
using GymApi.Exceptions;
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
        _context.Workouts.Add(workout);
        _context.SaveChanges();
        return workout;

    }

    public void Delete(Workout workout)
    {        
        _context.Workouts.Remove(workout);
        _context.SaveChanges();

    }

    public ICollection<Workout> FindByClient(int clientId)
    {
        var workouts = _context.Workouts.Where(workout => workout.GymClientId == clientId).ToList();

        return workouts;
    }

    public Workout FindById(int id)
    {
        var workout = _context.Workouts.FirstOrDefault(workout => workout.Id == id)
            ?? throw new NotFoundException();
        return workout;
    }

    public Workout Update(Workout workout)
    {
        _context.Workouts.Update(workout);
        _context.SaveChanges();
    }
}
