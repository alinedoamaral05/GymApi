using GymApi.Domain.Models;
using GymApi.Domain.Repositories;
using GymApi.Exceptions;

namespace GymApi.Infra.Repositories;

public class ExerciseDetailRepository: IExerciseDetailRepository
{
    private readonly GymContext _context;

    public ExerciseDetailRepository(GymContext context)
    {
        _context = context;
    }

    public ExerciseDetail Create(ExerciseDetail exerciseDetail)
    {
        var exerciseExists = _context
            .Exercises
            .Any(exercise => exercise.Id == exerciseDetail.ExerciseId);

        var workoutExists = _context
            .Workouts
            .Any(workout => workout.Id == exerciseDetail.WorkoutId);

        if (!exerciseExists || !workoutExists)
            throw new BadRequestException();

        _context
            .ExerciseDetails
            .Add(exerciseDetail);

        _context
            .SaveChanges();

        return exerciseDetail;
    }

    public void Delete(ExerciseDetail exerciseDetail)
    {
        _context
            .ExerciseDetails
            .Remove(exerciseDetail);
        
        _context
            .SaveChanges();
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
        var exerciseDetail = _context
            .ExerciseDetails
            .FirstOrDefault(ex => ex.Id == id);

        return exerciseDetail;
    }

    public ExerciseDetail Update(ExerciseDetail exerciseDetail)
    {
        var exerciseExists = _context
            .Exercises
            .Any(exercise => exercise.Id == exerciseDetail.ExerciseId);

        var workoutExists = _context
            .Workouts
            .Any(workout => workout.Id == exerciseDetail.WorkoutId);

        if (!exerciseExists || !workoutExists)
            throw new BadRequestException();

        _context
            .ExerciseDetails
            .Update(exerciseDetail);

        _context
            .SaveChanges();

        return exerciseDetail;
    }
}
