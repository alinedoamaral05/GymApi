using GymApi.Data.Request.ExerciseDetail;
using GymApi.Data.Response.ExerciseDetail;

namespace GymApi.Services;

public interface IExerciseDetailService
{
    ReadExerciseDetailDto Create(CreateExerciseDetailDto dto);
    ReadExerciseDetailDto UpdateById(UpdateExerciseDetailDto dto, int id);
    void DeleteById(int id);
    ReadExerciseDetailDto FindById(int id);
    ICollection<ReadExerciseDetailDto> FindByWorkout(int workoutId);
}
