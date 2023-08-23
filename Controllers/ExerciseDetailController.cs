using GymApi.Data.Request.ExerciseDetail;
using GymApi.Exceptions;
using GymApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Controllers;

[ApiController]
[Route("detalhesExercicio")]
public class ExerciseDetailController : ControllerBase
{
    public readonly IExerciseDetailService _exerciseDetailService;

    public ExerciseDetailController(IExerciseDetailService exerciseDetailService)
    {
        _exerciseDetailService = exerciseDetailService;
    }

    [HttpGet("/treinos/{workoutId}/detalhesExercicio")]
    public IActionResult GetAllExerciseDetailByWorkout(int workoutId)
    {
        try
        {
            var details = _exerciseDetailService
                .FindByWorkout(workoutId);
            
            return Ok(details);
        }
        
        catch (Exception ex)
        { 
            return Problem(ex.Message); 
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetExerciseDetailsById(int id)
    {
        try
        {
            var detail = _exerciseDetailService
                .FindById(id);
            
            return Ok(detail);
        }

        catch (Exception ex)
        {
            if (ex is NotFoundException)
                return NotFound(ex.Message);

            return Problem(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateExerciseDetailDto), StatusCodes.Status201Created)]
    public IActionResult CreateExerciseDetails(
        [FromBody] CreateExerciseDetailDto exerciseDetailDto
    )
    {
        try
        {
            var exerciseDetail = _exerciseDetailService
                .Create(exerciseDetailDto);

            return CreatedAtAction(
                nameof(GetExerciseDetailsById),
                new { id = exerciseDetail.Id },
                exerciseDetail
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
    public IActionResult UpdateClientExerciseDetail(
        int id, 
        [FromBody] UpdateExerciseDetailDto dto
    )
    {
        try
        {
            _exerciseDetailService
                .UpdateById(dto, id);
            
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
    public IActionResult DeleteExerciseDetail(int id)
    {
        try
        {
            _exerciseDetailService
                .DeleteById(id);
            
            return NoContent();
        }
        catch (Exception ex)
        { 
            if (ex is NotFoundException)
                return NotFound(ex.Message);

            return Problem(ex.Message); 
        }
    }
}
