using AutoMapper;
using GymApi.Data;
using GymApi.Data.Request.Workout;
using GymApi.Data.Response.Workout;
using GymApi.Domain.Models;
using GymApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Controllers;

[ApiController]
[Route("alunos/{clientId}/treinos")]
public class WorkoutController : ControllerBase
{    
    private readonly IWorkoutService _workoutService;

    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    public WorkoutController(GymContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet()]
    public IActionResult GetAllWorkouts(int clientId)
    {
        var client = _context.GymClients.Include(client => client.Workouts).FirstOrDefault(client => client.Id == clientId);
        if (client == null) return NotFound();

        var workoutsToList = client.Workouts.ToList();
        var map = _mapper.Map<IList<ReadWorkoutDto>>(workoutsToList);

        return Ok(map);
    }

    [HttpGet("{workoutId}")]
    public IActionResult GetWorkoutById(int clientId, int workoutId)
    {
        var clientWorkout = _context.GymClients
            .Include(client => client.Workouts.FirstOrDefault(workout => workout.Id == workoutId))
            .FirstOrDefault(client => client.Id == clientId);
        if (clientWorkout == null) return NotFound();

        var map = _mapper.Map<ReadWorkoutDto>(clientWorkout);
        return Ok(map);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateWorkoutDto), StatusCodes.Status201Created)]
    public IActionResult CreateWorkout(int clientId, [FromBody] CreateWorkoutDto createWorkoutDto)
    {
        var client = _context.GymClients.FirstOrDefault(client => client.Id == clientId);
        if (client == null) return NotFound();

        var workout = _mapper.Map<Workout>(createWorkoutDto);

        client.Workouts.Add(workout);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetWorkoutById),
            new { id = workout.Id },
            workout);
    }

    [HttpPut("{workoutId}")]
    public IActionResult UpdateWorkout(int clientId, int workoutId, [FromBody] UpdateWorkoutDto updateWorkoutDto)
    {
        var client = _context.GymClients
            .Include(client => client.Workouts)
            .FirstOrDefault(client => client.Id == clientId);

        if (client is null) return NotFound();

        var workout = client.Workouts.FirstOrDefault(workout => workout.Id == workoutId);
        if (workout is null) return NotFound();

        _mapper.Map(updateWorkoutDto, workout);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{workoutId}")]
    public IActionResult DeleteWorkout(int clientId, int workoutId)
    {
        var workout = _context.GymClients
            .Include(client => client.Workouts
                .FirstOrDefault(workout => workout.Id == workoutId))
            .FirstOrDefault(client => client.Id == clientId);
        if (workout == null) return NotFound();

        _context.GymClients.Remove(workout);
        _context.SaveChanges();

        return NoContent();
    }
}
