using GymApi.Data;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories.Interfaces;

namespace GymApi.Domain.Repositories;

public class ExerciseDetailRepository: IExerciseDetailRepository
{
    private readonly GymContext _context;
    public ExerciseDetailRepository(GymContext context)
    {
        _context = context;
    }

    public ExerciseDetail Create(ExerciseDetail exerciseDetail)
    {
        _context.ExerciseDetails.Add(exerciseDetail);
        _context.SaveChanges();

        return exerciseDetail;
    }

    public void Delete(ExerciseDetail exerciseDetail)
    {
        _context.ExerciseDetails.Remove(exerciseDetail);
        _context.SaveChanges();
    }

    public ICollection<ExerciseDetail> FindByWorkout(int workoutId)
    {
        var exerciseDetails = _context.ExerciseDetails
            .Where(exercise => exercise.WorkoutId == workoutId)
            .ToList();

        return exerciseDetails;
    }

    public ExerciseDetail? FindById(int id)
    {
        var exerciseDetail = _context.ExerciseDetails.FirstOrDefault(ex => ex.Id == id);

        return exerciseDetail;
    }

    public ExerciseDetail Update(ExerciseDetail exerciseDetail)
    {
        _context.ExerciseDetails.Update(exerciseDetail);
        _context.SaveChanges();

        return exerciseDetail;
    }
}
