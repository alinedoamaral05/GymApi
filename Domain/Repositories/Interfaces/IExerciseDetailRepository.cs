using GymApi.Domain.Models;

namespace GymApi.Domain.Repositories.Interfaces;

public interface IExerciseDetailRepository
{
    ExerciseDetail Create(ExerciseDetail exerciseDetail);
    ExerciseDetail Update(ExerciseDetail exerciseDetail);
    ExerciseDetail DeleteById(int id);
    ExerciseDetail FindById(int id);
    ICollection<ExerciseDetail> FindAll();
}
