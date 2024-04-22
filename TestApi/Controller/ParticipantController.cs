using Mapster;
using Microsoft.AspNetCore.Mvc;
using TestApi.Dtos;
using TestApi.Entities;
using TestApi.Services.Repo_Unit.Interfaces;

namespace TestApi.Controller;
[ApiController]
[Route("api/[controller]")]
public class ParticipantController:ControllerBase
{
    private readonly IRepository<Participant> _participantRepository;
    public ParticipantController(IRepository<Participant> participantRepository)
    {
        _participantRepository = participantRepository;
    }
    
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ParticipantDto>>> GetAll(long id) =>  Ok(await _participantRepository.Get(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Create(ParticipantDto participantDto)
    {
        await _participantRepository.Create(participantDto.Adapt<Participant>());
        await _participantRepository.Save();
        return Ok();
    }
}