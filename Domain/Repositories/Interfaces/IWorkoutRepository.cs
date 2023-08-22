using GymApi.Domain.Models;
using System.Collections;

namespace GymApi.Domain.Repositories.Interfaces;

public interface IWorkoutRepository
{
    Workout Create(Workout workout);
    Workout Update(Workout workout);
    void Delete(Workout workout);
    Workout? FindById(int id);
    ICollection<Workout> FindByClient(int clientId);
    
}
