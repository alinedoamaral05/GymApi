using GymApi.Data.Request.Workout;
using GymApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Controllers;

[ApiController]
[Route("treinos")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpGet("/alunos/{clientId}/treinos")]
    public IActionResult GetWorkoutbyGymClient(int clientId)
    {
        try
        {
            var workouts = _workoutService.FindByClient(clientId);
            return Ok(workouts);
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }

    [HttpGet("{id}")]
    public IActionResult GetWorkoutById(int id)
    {
        try
        {
            var workout = _workoutService.FindById(id);
            return Ok(workout);
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateWorkoutDto), StatusCodes.Status201Created)]
    public IActionResult CreateWorkout(int clientId, [FromBody] CreateWorkoutDto createWorkoutDto)
    {
        try
        {
            var workout = _workoutService.Create(createWorkoutDto);
            return CreatedAtAction(
                nameof(GetWorkoutById),
                new { id = workout.Id },
                workout);
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }

    [HttpPut("{workoutId}")]
    public IActionResult UpdateWorkout(int workoutId, [FromBody] UpdateWorkoutDto updateWorkoutDto)
    {
        try
        {
            _workoutService.UpdateById(updateWorkoutDto, workoutId);
            return NoContent();
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }

    [HttpDelete("{workoutId}")]
    public IActionResult DeleteWorkout(int workoutId)
    {
        try
        {
            _workoutService.DeleteById(workoutId);
            return NoContent();
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }
}
