using GymApi.Domain.Models;

namespace GymApi.Domain.Repositories;

public interface IExerciseDetailRepository
{
    ExerciseDetail Create(ExerciseDetail exerciseDetail);

    ExerciseDetail Update(ExerciseDetail exerciseDetail);

    void Delete(ExerciseDetail exerciseDetail);

    ExerciseDetail? FindById(int id);

    ICollection<ExerciseDetail> FindByWorkout(int workoutId);
}
