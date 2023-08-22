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
        return Ok(_gymClientService.FindAll());
    }

    [HttpGet("{clientId}")]
    public IActionResult GetGymClientById(int clientId)
    {
        
        return Ok(_gymClientService.FindById(clientId));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateGymClientDto), StatusCodes.Status201Created)]
    public IActionResult CreateGymClient([FromBody] CreateGymClientDto createGymClientDto)
    {
        var client = _gymClientService.Create(createGymClientDto);

        return CreatedAtAction(
            nameof(GetGymClientById),
            new { id = client.Id },
            client);
    }

    [HttpPut("{clientId}")]
    public IActionResult UpdateGymClient(int clientId, [FromBody] UpdateGymClientDto updateGymClientDto)
    {
        _gymClientService.UpdateById(updateGymClientDto, clientId);

        return NoContent();
    }

    [HttpDelete("{clientId}")]
    public IActionResult DeleteGymClient(int clientId)
    {
        _gymClientService.DeleteById(clientId);

        return Ok();
    }
}
