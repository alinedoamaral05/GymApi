using AutoMapper;
using GymApi.Data;
using GymApi.Models;
using Microsoft.AspNetCore.Mvc;
using GymApi.Data.Response.Exercise;
using GymApi.Data.Request.Exercise;
using GymApi.Data.Request.Workout;

namespace GymApi.Controllers;

[ApiController]
[Route("/exercicios")]
public class ExerciseController: ControllerBase
{
    public readonly GymContext _context;
    public readonly IMapper _mapper;

    public ExerciseController(GymContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllExercises()
    {
        var exercisesToList = _context.Exercises.ToList();
        var map = _mapper.Map<IList<ReadExerciseDto>>(exercisesToList);

        return Ok(map);
    }

    [HttpGet("{exerciseId}")]
    public IActionResult GetExerciseById(int exerciseId)
    {
        var exercise = _context.Exercises.Find(exerciseId);
        if (exercise == null) return NotFound();

        var map = _mapper.Map<ReadExerciseDto>(exercise);
        return Ok(map);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateExerciseDto), StatusCodes.Status201Created)]
    public IActionResult CreateExercise([FromBody] CreateExerciseDto createExerciseDto)
    {
        var exercise = _mapper.Map<Exercise>(createExerciseDto);

        _context.Exercises.Add(exercise);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetExerciseById),
            new {id = exercise.Id},
            exercise);
    }

    [HttpPut("{exerciseId}")]
    public IActionResult UpdateExercise(int exerciseId, [FromBody] UpdateExerciseDto updateExerciseDto)
    {
        var exercise = _context.Exercises
            .FirstOrDefault(exercise => exercise.Id == exerciseId);

        if (exercise is null) return NotFound();

        _mapper.Map(updateExerciseDto, exercise);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{exerciseId}")]
    public IActionResult DeleteExercise(int exerciseId)
    {
        var exercise = _context.Exercises.Find(exerciseId);
        if (exercise == null) return NotFound();

        _context.Exercises.Remove(exercise);
        _context.SaveChanges();

        return Ok();
    }
}

