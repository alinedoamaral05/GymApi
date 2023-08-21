using AutoMapper;
using GymApi.Data.Request.Exercise;
using GymApi.Data.Response.Exercise;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories.Interfaces;
using GymApi.Exceptions;

namespace GymApi.Services;

public class ExerciseService : IExerciseService
{
    private readonly IMapper _mapper;
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IMapper mapper, IExerciseRepository exerciseRepository)
    {
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
    }
    public ReadExerciseDto Create(CreateExerciseDto dto)
    {
        var exercise = _mapper.Map<Exercise>(dto);
        exercise = _exerciseRepository.Create(exercise);
        var readDto = _mapper.Map<ReadExerciseDto>(exercise);

        return readDto;
    }

    public void DeleteById(int id)
    {
        var exercise = _exerciseRepository.FindById(id)
            ?? throw new NotFoundException();

        _exerciseRepository.Delete(exercise);
    }

    public ICollection<ReadExerciseDto> FindAll()
    {
        var exercises = _exerciseRepository.FindAll();
        var dto = _mapper.Map<ICollection<ReadExerciseDto>>(exercises);
        
        return dto;
    }

    public ReadExerciseDto FindById(int id)
    {
        var exercise = _exerciseRepository.FindById(id)
             ?? throw new NotFoundException();
        var map = _mapper.Map<ReadExerciseDto>(exercise);


        return map;
    }

    public ReadExerciseDto UpdateById(UpdateExerciseDto updateExerciseDto, int id)
    {
        var exercise = _exerciseRepository.FindById(id);
        if (exercise == null)
        {
            var create = _mapper.Map<CreateExerciseDto>(updateExerciseDto);
            return Create(create);
        }

        _mapper.Map(updateExerciseDto, exercise);
        var updated = _exerciseRepository.Update(exercise);

        var readExercise = _mapper.Map<ReadExerciseDto>(updated);

        return readExercise;
    }

}

