using GymApi.Data.Request.GymClient;
using GymApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Controllers;

[ApiController]
[Route("/alunos")]
public class GymClientController : ControllerBase
{
    public readonly IGymClientService _gymClientService;

    public GymClientController(IGymClientService gymClientService)
    {
        _gymClientService = gymClientService;
    }

    [HttpGet]
    public IActionResult GetAllGymClient()
    {
        try
        {
            var gymClients = _gymClientService.FindAll();
            return Ok(gymClients);
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }

    [HttpGet("{clientId}")]
    public IActionResult GetGymClientById(int clientId)
    {
        try
        {
            var gymClient =_gymClientService.FindById(clientId);
            return Ok(gymClient);
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateGymClientDto), StatusCodes.Status201Created)]
    public IActionResult CreateGymClient([FromBody] CreateGymClientDto createGymClientDto)
    {
        try
        {
            var gymClient = _gymClientService.Create(createGymClientDto);
            return CreatedAtAction(
                nameof(GetGymClientById),
                new { id = gymClient.Id },
                gymClient);
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }

    [HttpPut("{clientId}")]
    public IActionResult UpdateGymClient(int clientId, [FromBody] UpdateGymClientDto updateGymClientDto)
    {
        try
        {
            _gymClientService.UpdateById(updateGymClientDto, clientId);
            return NoContent();
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }

    [HttpDelete("{clientId}")]
    public IActionResult DeleteGymClient(int clientId)
    {
        try
        {
            _gymClientService.DeleteById(clientId);
            return Ok();
        }
        catch (Exception ex) { return Problem(ex.Message); }
    }
}
