using GymApi.Domain.Models;

namespace GymApi.Domain.Repositories.Interfaces;

public interface IWorkoutRepository
{
    Workout Create(Workout workout);
    Workout Update(Workout workout);
    Workout DeleteById(int id);
    Workout FindById(int id);
    ICollection<Workout> FindAll();
}
