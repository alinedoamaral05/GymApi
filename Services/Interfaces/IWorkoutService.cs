using GymApi.Data.Request.Workout;
using GymApi.Data.Response.Workout;

namespace GymApi.Services
{
    public interface IWorkoutService
    {
        ReadWorkoutDto Create(CreateWorkoutDto dto);
        ReadWorkoutDto UpdateById(UpdateWorkoutDto dto, int id);
        ReadWorkoutDto DeleteById(int id);
        ReadWorkoutDto FindById(int id);
        ICollection<ReadWorkoutDto> FindAll();
    }
}
