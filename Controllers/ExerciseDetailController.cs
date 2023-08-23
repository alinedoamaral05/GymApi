using AutoMapper;
using GymApi.Data.Request.ExerciseDetail;
using GymApi.Data.Response.ExerciseDetail;
using GymApi.Domain.Models;
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

    [HttpGet]
    public IActionResult GetAllExerciseDetailByWorkout(int workoutId)
    {
        try
        {
            var details = _exerciseDetailService.FindByWorkout(workoutId);
            return Ok(details);
        }
        catch (Exception ex)
        { return Problem(ex.Message); }
    }

    [HttpGet("{exerciseDetailId}")]
    public IActionResult GetClientExerciseDetailsById(int exerciseDetailId)
    {
        try
        {
            var detail = _exerciseDetailService.FindById(exerciseDetailId);
            return Ok(detail);
        }
        catch (Exception ex)
        { return Problem(ex.Message); }
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateExerciseDetailDto), StatusCodes.Status201Created)]
    public IActionResult CreateClientExerciseDetails([FromBody] CreateExerciseDetailDto exerciseDetailDto)
    {
        try
        {
            var exerciseDetail = _exerciseDetailService.Create(exerciseDetailDto);

            return CreatedAtAction(
            nameof(GetClientExerciseDetailsById),
            new { id = exerciseDetail.Id },
            exerciseDetail);
        }
        catch (Exception ex)
        { return Problem(ex.Message); }
    }

    [HttpPut("{exerciseDetailId}")]
    public IActionResult UpdateClientExerciseDetail(int exerciseDetailId, [FromBody] UpdateExerciseDetailDto dto)
    {
        try
        {
            _exerciseDetailService.UpdateById(dto, exerciseDetailId);
            return NoContent();
        }
        catch (Exception ex)
        { return Problem(ex.Message); }
    }

    [HttpDelete("{exerciseDetailId}")]
    public IActionResult DeleteExerciseDetail(int exerciseDetailId)
    {
        try
        {
            _exerciseDetailService.DeleteById(exerciseDetailId);
            return Ok();
        }
        catch (Exception ex)
        { return Problem(ex.Message); }
    }

}
