using GymApi.Domain.Models;

namespace GymApi.Domain.Repositories;

public interface IExerciseRepository 
{
    Exercise Create(Exercise exercise);
    Exercise Update(Exercise exercise);
    void Delete(Exercise exercise);
    Exercise? FindById(int id);
    ICollection<Exercise> FindAll();
}
