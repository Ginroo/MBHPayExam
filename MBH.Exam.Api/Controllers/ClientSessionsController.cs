using MBH.Exam.Application.DTOs;
using MBH.Exam.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MBH.Exam.Api.Controllers;

[ApiController]
[Route("api/client-session")]
public class ClientSessionsController(IClientSessionService sessionService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ClientSessionDto>> CreateSession([FromBody] CreateClientSessionDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var session = await sessionService.CreateSessionAsync(dto);

        return CreatedAtAction(
            nameof(GetSessionById),
            new { id = session.Id },
            session);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientSessionDto>>> GetAllSessions()
    {
        var sessions = await sessionService.GetAllSessionsAsync();
        return Ok(sessions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientSessionDto>> GetSessionById(int id)
    {
        var session = await sessionService.GetSessionByIdAsync(id);

        if (session == null)
        {
            return NotFound(new { error = $"Session with ID {id} not found" });
        }

        return Ok(session);
    }

    [HttpGet("client/{clientName}")]
    public async Task<ActionResult<IEnumerable<ClientSessionDto>>> GetSessionsByClientName(string clientName)
    {
        if (string.IsNullOrWhiteSpace(clientName))
        {
            return BadRequest(new { error = "Client name cannot be empty" });
        }

        var sessions = await sessionService.GetSessionsByClientNameAsync(clientName);
        return Ok(sessions);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ClientSessionDto>> UpdateSession(int id, [FromBody] UpdateClientSessionDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var session = await sessionService.UpdateSessionAsync(id, dto);
        return Ok(session);
    }

  
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        var deleted = await sessionService.DeleteSessionAsync(id);

        if (!deleted)
        {
            return NotFound(new { error = $"Session with ID {id} not found" });
        }

        return NoContent();
    }
}
