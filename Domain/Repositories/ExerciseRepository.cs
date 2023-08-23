using GymApi.Data;
using GymApi.Domain.Repositories.Interfaces;
using GymApi.Domain.Models;

namespace GymApi.Domain.Repositories;

public class ExerciseRepository: IExerciseRepository
{
    private readonly GymContext _context;

    public ExerciseRepository(GymContext context)
    {
        _context = context;
    }
    
    public Exercise Create(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        _context.SaveChanges();

        return exercise;
    }

    public void Delete(Exercise exercise)
    {
        _context.Exercises.Remove(exercise);
        _context.SaveChanges();
    }

    public ICollection<Exercise> FindAll()
    {
        var exerciseList = _context.Exercises.ToList();

        return exerciseList;
    }

    public Exercise? FindById(int id)
    {
        var exerciseById = _context.Exercises
            .FirstOrDefault(exercise => exercise.Id == id);
        
        return exerciseById;
    }

    public Exercise Update(Exercise exercise)
    {
        _context.Update(exercise);
        _context.SaveChanges();
        return exercise;
    }
}
