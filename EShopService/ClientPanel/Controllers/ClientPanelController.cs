using Microsoft.AspNetCore.Mvc;
using ClientDataBase.Application.Services;
using ClientDataBase.Domain.Models;
using ClientDataBase.Application.Services;
using ClientDataBase.Domain.Repositories;
using ClientDataBase.Domain.Seeders;

namespace ClientDataBase.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientPanelController : ControllerBase
{
    public readonly IClientDataService _clientDataService;
    public ClientPanelController(IClientDataService clientDataService)
    {
        _clientDataService = clientDataService;
    }
    //Interface decouple controller from the implementation 

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Client client)
    {
        
        var result = await _clientDataService.AddClientAsync(client);
        if (result == null)
        {
            return BadRequest("Failed to add client.");
        };
        return Ok(result);
    }
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var result = await _clientDataService.GetAllClientsAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var result = await _clientDataService.GetClientAsync(id);
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var client = await _clientDataService.GetClientAsync(id);
        if (client == null)
        {
            return NotFound("Client not found");
        }
        var result = await _clientDataService.DeleteClientAsync(id);
        return Ok(result);
    }
}
