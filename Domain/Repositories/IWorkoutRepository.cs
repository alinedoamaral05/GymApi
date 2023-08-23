using GymApi.Domain.Models;

namespace GymApi.Domain.Repositories;

public interface IWorkoutRepository
{
    Workout Create(Workout workout);
    Workout Update(Workout workout);
    void Delete(Workout workout);
    Workout? FindById(int id);
    ICollection<Workout> FindByClient(int clientId);
    
}
