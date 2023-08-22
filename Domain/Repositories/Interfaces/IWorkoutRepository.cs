using GymApi.Domain.Models;

namespace GymApi.Domain.Repositories.Interfaces;

public interface IWorkoutRepository
{
    Workout Create(Workout workout);
    Workout Update(Workout workout);
    void DeleteById(int clientId, Workout workout);
    Workout FindById(int clientId, int id);
    ICollection<Workout> FindAll(int clientId);
}
