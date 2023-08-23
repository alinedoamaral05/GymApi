using AutoMapper;
using GymApi.Data.Request.ExerciseDetail;
using GymApi.Data.Response.ExerciseDetail;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories;
using GymApi.Exceptions;

namespace GymApi.Services;

public class ExerciseDetailService : IExerciseDetailService
{
    private readonly IMapper _mapper;
    private readonly IExerciseDetailRepository _exerciseDetailRepository;
    
    public ExerciseDetailService(
        IMapper mapper, 
        IExerciseDetailRepository exerciseDetailRepository
    )
    {
        _mapper = mapper;
        _exerciseDetailRepository = exerciseDetailRepository;
    }

    public ReadExerciseDetailDto Create(CreateExerciseDetailDto dto)
    {
        var detail = _mapper
            .Map<ExerciseDetail>(dto);
        
        _exerciseDetailRepository
            .Create(detail);
        
        var readDto = _mapper
            .Map<ReadExerciseDetailDto>(detail);

        return readDto;
    }

    public void DeleteById(int id)
    {
        var detail =_exerciseDetailRepository
            .FindById(id)
            ?? throw new NotFoundException();

        _exerciseDetailRepository
            .Delete(detail);
        
        return;
    }

    public ICollection<ReadExerciseDetailDto> FindByWorkout(int workoutId)
    {
        var exercises = _exerciseDetailRepository
            .FindByWorkout(workoutId)
            ?? throw new NotFoundException();

        var readDto = _mapper
            .Map<IList<ReadExerciseDetailDto>>(exercises);

        return readDto;
    }

    public ReadExerciseDetailDto FindById(int id)
    {
        var exercise = _exerciseDetailRepository
            .FindById(id)
            ?? throw new NotFoundException();
        
        var readDto = _mapper
            .Map<ReadExerciseDetailDto>(exercise);

        return readDto;
    }

    public ReadExerciseDetailDto UpdateById(UpdateExerciseDetailDto dto, int id)
    {
        var exercise = _exerciseDetailRepository
            .FindById(id);

        if (exercise == null)
        {
            var newExerciseDetail = _mapper
                .Map<CreateExerciseDetailDto>(dto);
            
            return Create(newExerciseDetail);
        }

        var updatedDetail = _mapper
            .Map(dto, exercise);
        
        _exerciseDetailRepository
            .Update(updatedDetail);

        var read = _mapper
            .Map<ReadExerciseDetailDto>(updatedDetail);

        return read;
    }
}
