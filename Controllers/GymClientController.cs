using AutoMapper;
using GymApi.Data;
using GymApi.Data.Request.GymClient;
using GymApi.Data.Request.Workout;
using GymApi.Data.Response.GymClient;
using GymApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Controllers;

[ApiController]
[Route("/alunos")]
public class GymClientController : ControllerBase
{
    public readonly GymContext _context;
    public readonly IMapper _mapper;

    public GymClientController(GymContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllGymClient()
    {
        var clientsToList = _context.GymClients.ToList();
        var map = _mapper.Map<IList<ReadGymClientDto>>(clientsToList);

        return Ok(map);
    }

    [HttpGet("{clientId}")]
    public IActionResult GetGymClientById(int clientId)
    {
        var client = _context.GymClients.Find(clientId);
        if (client == null) return NotFound();

        var map = _mapper.Map<ReadGymClientDto>(client);
        return Ok(map);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateGymClientDto), StatusCodes.Status201Created)]
    public IActionResult CreateGymClient([FromBody] CreateGymClientDto createGymClientDto)
    {
        var client = _mapper.Map<GymClient>(createGymClientDto);

        _context.GymClients.Add(client);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetGymClientById),
            new { id = client.Id },
            client);
    }

    [HttpPut("{clientId}")]
    public IActionResult UpdateGymClient(int clientId, [FromBody] UpdateGymClientDto updateGymClientDto)
    {
        var client = _context.GymClients
            .FirstOrDefault(client => client.Id == clientId);

        if (client is null) return NotFound();

        _mapper.Map(updateGymClientDto, client);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{clientId}")]
    public IActionResult DeleteGymClient(int clientId)
    {
        var client = _context.GymClients.Find(clientId);
        if (client == null) return NotFound();

        _context.GymClients.Remove(client);
        _context.SaveChanges();

        return Ok();
    }
}
