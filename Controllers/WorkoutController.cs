using GymApi.Data.Request.Workout;
using GymApi.Exceptions;
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
    public IActionResult GetWorkoutByGymClient(int clientId)
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
            var workout = _workoutService
                .FindById(id);

            return Ok(workout);
        }

        catch (Exception ex) { return Problem(ex.Message); }
    }

    [HttpPost()]
    [ProducesResponseType(typeof(CreateWorkoutDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult CreateWorkout(
        [FromBody] CreateWorkoutDto createWorkoutDto
    )
    {
        try
        {
            var workout = _workoutService
                .Create(createWorkoutDto);
            
            return CreatedAtAction(
                nameof(GetWorkoutById),
                new { id = workout.Id },
                workout
            );
        }
        
        catch (Exception ex) 
        {
            if (ex is BadRequestException)
                return BadRequest(ex.Message);

            return Problem(ex.Message); 
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateWorkout(
        int id, 
        [FromBody] UpdateWorkoutDto updateWorkoutDto
    )
    {
        try
        {
            _workoutService
                .UpdateById(updateWorkoutDto, id);
            
            return NoContent();
        }
        
        catch (Exception ex) 
        { 
            if (ex is BadRequestException)
                return BadRequest(ex.Message);

            return Problem(ex.Message); 
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWorkout(int id)
    {
        try
        {
            _workoutService
                .DeleteById(id);
            
            return NoContent();
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }
}
