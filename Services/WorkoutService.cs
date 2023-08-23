using AutoMapper;
using GymApi.Data.Request.Workout;
using GymApi.Data.Response.Workout;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories;
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
        var workout = _mapper
            .Map<Workout>(dto);

        _workoutRepository
            .Create(workout);

        var readWorkout = _mapper
            .Map<ReadWorkoutDto>(workout);
        
        return readWorkout;
    }

    public void DeleteById(int id)
    {
        var workout = _workoutRepository
            .FindById(id)
            ?? throw new NotFoundException();

        _workoutRepository
            .Delete(workout);
    }

    public ICollection<ReadWorkoutDto> FindByClient(int clientId)
    {
        var workouts = _workoutRepository
            .FindByClient(clientId)
            ?? throw new NotFoundException();

        var readWorkouts = _mapper
            .Map<ICollection<ReadWorkoutDto>>(workouts);

        return readWorkouts;
    }
    public ReadWorkoutDto FindById(int id)
    {
        var workout = _workoutRepository
            .FindById(id)
            ?? throw new NotFoundException();

        var readWorkout = _mapper
            .Map<ReadWorkoutDto>(workout);

        return readWorkout;
    }

    public ReadWorkoutDto UpdateById(
        UpdateWorkoutDto dto,
        int id
    )
    {
        var workout = _workoutRepository
            .FindById(id);
        
        if (workout == null)
        {
            var newWorkout = _mapper
                .Map<CreateWorkoutDto>(dto);
            
            return Create(newWorkout);
        }

        _mapper
            .Map(dto, workout);

        _workoutRepository
            .Update(workout);

        var readWorkout = _mapper
            .Map<ReadWorkoutDto>(workout);

        return readWorkout;               
    }
}
