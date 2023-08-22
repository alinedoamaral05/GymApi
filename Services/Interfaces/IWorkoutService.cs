using GymApi.Data.Request.Workout;
using GymApi.Data.Response.Workout;

namespace GymApi.Services;

public interface IWorkoutService
{
    ReadWorkoutDto Create(CreateWorkoutDto dto);
    ReadWorkoutDto UpdateById(UpdateWorkoutDto dto, int id);
    void DeleteById(int clientId, int id);
    ReadWorkoutDto FindById(int clientId, int id);
    ICollection<ReadWorkoutDto> FindAll();
}
