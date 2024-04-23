using FluentValidation;
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
    IValidator<ParticipantDto> _validator;
    public ParticipantController(IRepository<Participant> participantRepository, IValidator<ParticipantDto> validator)
    {
        _participantRepository = participantRepository;
        _validator = validator;
    }
    
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ParticipantDto>>> GetAll(long id) =>  Ok(await _participantRepository.Get(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Create(ParticipantDto participantDto)
    {
        if (_validator.Validate(participantDto).IsValid)
        {
            await _participantRepository.Create(participantDto.Adapt<Participant>());
            await _participantRepository.Save();
            return Ok();
        }
        return BadRequest(participantDto);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ParticipantDto>> Update([FromBody] ParticipantDto participantDto)
    { 
        if (_validator.Validate(participantDto).IsValid)
        { 
            _participantRepository.Update(participantDto.Adapt<Participant>());
            await _participantRepository.Save();
            return Ok(participantDto);
        }
        return BadRequest(participantDto);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete(int id)
    {
        await _participantRepository.Delete(id);
        await _participantRepository.Save();
        return NoContent();
    }
    
    [HttpGet(@"\d+")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async  Task<ActionResult<EventDto>> GetById(int id) => Ok(await _participantRepository.Get(id));
}