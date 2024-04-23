using Microsoft.AspNetCore.Mvc;
using TestApi.Entities;
using TestApi.Services.Repo_Unit.Interfaces;

namespace TestApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class EventParticipantController:ControllerBase
{
    private IEventParticipantRepository _repo;

    public EventParticipantController(IEventParticipantRepository repo)
    {
        _repo = repo;
    }

    [HttpPost("{partId}-{eventId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Add(long eventId, long partId)
    {
        await _repo.AddToEvent(partId, eventId);
        return CreatedAtAction("Add", new EventParticipant(eventId,partId));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<EventParticipant>> GetParticipants(long id)
    {
        return Ok(_repo.GetEventParticipants(id));
    }

    [HttpDelete("{partId}-{eventId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult RemoveFromEvent(long partId, long eventId)
    {
        _repo.RemoveFromEvent(partId, eventId);
        return NoContent();
    }
}