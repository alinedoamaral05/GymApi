using AutoMapper;
using GymApi.Data.Request.Workout;
using GymApi.Data.Response.Workout;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories.Interfaces;
using GymApi.Exceptions;

namespace GymApi.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IMapper _mapper;

    public WorkoutService(IWorkoutRepository workoutRepository, IMapper mapper)
    {
        _workoutRepository = workoutRepository;
        _mapper = mapper;
    }
    public ReadWorkoutDto Create(CreateWorkoutDto dto)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int clientId, int id)
    {
        var workout = _workoutRepository.FindById(clientId, id)
            ?? throw new NotFoundException();

        _workoutRepository.DeleteById(clientId, workout);
    }

    public ICollection<ReadWorkoutDto> FindAll(int clientId)
    {
        var workouts = _workoutRepository.FindAll(clientId)
            ?? throw new NotFoundException();

        var readWorkouts = _mapper.Map<ICollection<ReadWorkoutDto>>(workouts);

        return readWorkouts;
    }

    public ReadWorkoutDto FindById(int clientId, int id)
    {
        var workout = _workoutRepository.FindById(clientId, id)
        ?? throw new NotFoundException();

        var readWorkout = _mapper.Map<ReadWorkoutDto>(workout);

        return readWorkout;
    }

    public ReadWorkoutDto UpdateById(UpdateWorkoutDto dto, int clientId, int id)
    {
        var workout = _workoutRepository.FindById(id);

        var workout = _mapper.Map<Workout>(dto)
            
    }
}
