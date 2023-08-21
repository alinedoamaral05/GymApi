using Microsoft.AspNetCore.Mvc;
using GymApi.Data.Request.Exercise;
using GymApi.Services;

namespace GymApi.Controllers;

[ApiController]
[Route("/exercicios")]
public class ExerciseController: ControllerBase
{
    public readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpGet]
    public IActionResult GetAllExercises()
    {
        var exercises = _exerciseService.FindAll();
        return Ok(exercises);
    }

    [HttpGet("{exerciseId}")]
    public IActionResult GetExerciseById(int exerciseId)
    {
        var exercise = _exerciseService.FindById(exerciseId);

        return Ok(exercise);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateExerciseDto), StatusCodes.Status201Created)]
    public IActionResult CreateExercise([FromBody] CreateExerciseDto createExerciseDto)
    {
        var exercise = _exerciseService.Create(createExerciseDto);

        return CreatedAtAction(
            nameof(GetExerciseById),
            new {id = exercise.Id},
            exercise);
    }

    [HttpPut("{exerciseId}")]
    public IActionResult UpdateExercise(int exerciseId, [FromBody] UpdateExerciseDto updateExerciseDto)
    {
        _exerciseService.UpdateById(updateExerciseDto, exerciseId);

        return NoContent();
    }

    [HttpDelete("{exerciseId}")]
    public IActionResult DeleteExercise(int exerciseId)
    {
        _exerciseService.DeleteById(exerciseId);

        return Ok();
    }
}

