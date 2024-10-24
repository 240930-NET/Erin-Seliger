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

    [HttpGet("/getPlayerById/{id}")]
    public IActionResult GetPlayerById(int id) {
        try {
            Player player = _playerService.GetPlayerById(id);
            return Ok(player);
        }
        catch(Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("/addPlayer")]
    public IActionResult AddPlayer([FromBody] Player player) {
        try {
            _playerService.AddPlayer(player);
            return Ok(player);
        }
        catch {
            return BadRequest("Could not add player");
        }
    }

    [HttpPatch("/updatePlayer")]
    public IActionResult UpdatePlayer([FromBody] Player player) {
        try {
            _playerService.UpdatePlayer(player);
            return Ok(player);
        }
        catch {                                               
            return BadRequest("Could not edit player");
        }
    }

    [HttpDelete("/deletePlayer/{id}")]
    public IActionResult DeletePlayer(int id) {
        try {
            _playerService.DeletePlayer(id);
            return Ok("Player deleted");
        }
        catch {                                             
            return BadRequest("Could not delete player");
        }
    }
}