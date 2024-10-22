using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Pinball.API.Model;
using Pinball.API.Service;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Pinball.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase{

    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService) => _playerService = playerService;

    [HttpGet("/player")]
    public IActionResult GetAllPlayers() {
        var players = _playerService.GetAllPlayers();
        return Ok(players);
    }
}