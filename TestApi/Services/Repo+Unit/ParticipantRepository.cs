using Mapster;
using Microsoft.EntityFrameworkCore;
using TestApi.Context;
using TestApi.Dtos;
using TestApi.Entities;
using TestApi.Services.Repo_Unit.Interfaces;

namespace TestApi.Services.Repo_Unit;

public class ParticipantRepository:IParticipantRepository
{
    private readonly ApiContext _apiContext;
    
    public ParticipantRepository(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }


    public async Task<ParticipantDto?> Get(long id)
    {
        var res = await _apiContext.Participants.FindAsync(id);
        return res.Adapt<ParticipantDto>();
    }

    public async void Create(Participant item)
    {
        await _apiContext.Participants.AddAsync(item);
    }

    public void Update(Participant item)
    {
        _apiContext.Participants.Update(item);
    }

    public async void Delete(long id)
    {
        var res = await _apiContext.Participants.FindAsync(id);
        if (res != null)
            _apiContext.Participants.Remove(res);
    }
    public async Task Save() => await _apiContext.SaveChangesAsync();
}