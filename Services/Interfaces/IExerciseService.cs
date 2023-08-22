using GymApi.Data.Request.Exercise;
using GymApi.Data.Response.Exercise;

namespace GymApi.Services;

public interface IExerciseService
{
    ReadExerciseDto Create(CreateExerciseDto dto);
    ReadExerciseDto UpdateById(UpdateExerciseDto dto, int id);
    void DeleteById(int id);
    ReadExerciseDto FindById(int id);
    ICollection<ReadExerciseDto> FindAll();
}
