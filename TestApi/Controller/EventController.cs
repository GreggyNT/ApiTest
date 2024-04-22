using Mapster;
using Microsoft.AspNetCore.Mvc;
using TestApi.Dtos;
using TestApi.Entities;
using TestApi.Services;
using TestApi.Services.Repo_Unit.Interfaces;

namespace TestApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class EventController:ControllerBase
{
    private IEventRepository _eventRepository;
    private IRedisHash _redisHash;
    
    public EventController(IEventRepository eventrepo, IRedisHash redisHash)
    {
        _eventRepository = eventrepo;
        _redisHash = redisHash;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<EventDto>> GetAll() => Ok(_eventRepository.GetAll());
    [HttpGet(@"\d+")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async  Task<ActionResult<EventDto>> GetById(int id) => Ok(await _eventRepository.Get(id));

    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<EventDto>> GetByName(string name) => Ok(await _eventRepository.Get(name));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<EventDto>> Create([FromBody] EventDto eventDto)
    {
        await _eventRepository.Create(eventDto.Adapt<Event>());
        await _eventRepository.Save();
        return Ok();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<EventDto>> Update([FromBody] EventDto eventDto)
    { 
        _eventRepository.Update(eventDto.Adapt<Event>());
        await _eventRepository.Save();
        return Ok(eventDto);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete(int id)
    {
        await _eventRepository.Delete(id);
        await _eventRepository.Save();
        return NoContent();
    }

    [HttpGet("{dateTime}/{location}/{category}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<EventDto>> GetByParametres(DateTime dateTime, string location,
        string category) => Ok(_eventRepository.Get(dateTime, location, category));

    [HttpGet("img/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetImage(long id)
    {
        var res = await _redisHash.GetData(id);
        return res == null ? NoContent() : File(res, "image/png");
    }

    [HttpPost("img/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> SetImage([FromBody] byte[] image, long id) =>
        Ok(await _redisHash.SetData(id, image));
}