using AutoMapper;
using GymApi.Data;
using GymApi.Data.Request.ExerciseDetail;
using GymApi.Data.Request.Workout;
using GymApi.Data.Response.ExerciseDetail;
using GymApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Controllers;

[ApiController]
[Route("/alunos/{clientId}/treinos/{workoutId}/detalhesExercicio")]
public class ExerciseDetailController : ControllerBase
{
    public readonly GymContext _context;
    public readonly IMapper _mapper;

    public ExerciseDetailController(GymContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllClientExerciseDetails(int clientId, int workoutId)
    {
        var client = _context.GymClients
            .Include(client => client.Workouts)
            .ThenInclude(workout => workout.ExerciseDetails)
            .FirstOrDefault(client => client.Id == clientId);
        if (client == null) return NotFound();

        var workout = client.Workouts
            .FirstOrDefault(workout => workout.Id == workoutId);
        if (workout == null) return NotFound();

        var exerciseDetail = workout.ExerciseDetails;
        if (exerciseDetail == null) return NotFound();

        var map = _mapper.Map<IList<ReadExerciseDetailDto>>(exerciseDetail);

        return Ok(map);
    }

    [HttpGet("{exerciseDetailId}")]
    public IActionResult GetClientExerciseDetailsById(int clientId, int workoutId, int exerciseDetailId)
    {
        var client = _context.GymClients
            .Include(client => client.Workouts)
            .ThenInclude(workout => workout.ExerciseDetails)
            .FirstOrDefault(client => client.Id == clientId);
        if (client == null) return NotFound();

        var workout = client
            .Workouts
            .FirstOrDefault(workout => workout.Id == workoutId);
        if (workout == null) return NotFound();

        var exerciseDetail = workout
            .ExerciseDetails
            .FirstOrDefault(exerciseDetail => exerciseDetail.Id == exerciseDetailId);
        if (exerciseDetail == null) return NotFound();

        var map = _mapper.Map<ReadExerciseDetailDto>(exerciseDetail);

        return Ok(map);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateExerciseDetailDto), StatusCodes.Status201Created)]
    public IActionResult CreateClientExerciseDetails(int clientId, int workoutId, [FromBody] CreateExerciseDetailDto exerciseDetailDto)
    {
        var client = _context.GymClients
            .Include(client => client.Workouts)
            .ThenInclude(workouts => workouts.ExerciseDetails)
            .FirstOrDefault(client => client.Id == clientId);
        if (client == null) return NotFound();

        var workout = client.Workouts
            .FirstOrDefault(workout => workout.Id == workoutId);
        if (workout == null) return NotFound();

        var exerciseDetail = _mapper.Map<ExerciseDetail>(exerciseDetailDto);

        workout.ExerciseDetails.Add(exerciseDetail);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetClientExerciseDetailsById),
            new { id = exerciseDetail.Id },
            exerciseDetail);
    }

    [HttpPut("{exerciseDetailId}")]
    public IActionResult UpdateClientExerciseDetail(int clientId, int workoutId, int exerciseDetailId, [FromBody] UpdateExerciseDetailDto updateExerciseDetailDto)
    {
        var client = _context.GymClients
            .Include(client => client.Workouts)
            .ThenInclude(workouts => workouts.ExerciseDetails)
            .FirstOrDefault(client => client.Id == clientId);

        if (client is null) return NotFound();

        var workout = client.Workouts.FirstOrDefault(workout => workout.Id == workoutId);
        if (workout is null) return NotFound();

        var exerciseDetail = workout.ExerciseDetails.FirstOrDefault(exerciseDetail => exerciseDetail.Id == exerciseDetailId);
        if (exerciseDetail is null) return NotFound();

        _mapper.Map(updateExerciseDetailDto, exerciseDetail);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{exerciseDetailId}")]
    public IActionResult DeleteExerciseDetail(int clientId, int workoutId, int exerciseDetailId)
    {
        var client = _context.GymClients
                .Include(client => client.Workouts)
                .ThenInclude(workout => workout.ExerciseDetails)
                .FirstOrDefault(client => client.Id == clientId);
        if (client == null) return NotFound();

        var workout = client.Workouts
            .FirstOrDefault(workout => workout.Id == workoutId);
        if (workout == null) return NotFound();

        var exerciseDetail = workout
            .ExerciseDetails
            .FirstOrDefault(exerciseDetail => exerciseDetail.Id == exerciseDetailId);
        if (exerciseDetail == null) return NotFound();

        workout.ExerciseDetails.Remove(exerciseDetail);
        _context.SaveChanges();

        return Ok(workout);
    }
}
