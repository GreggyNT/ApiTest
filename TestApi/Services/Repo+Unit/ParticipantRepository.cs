using Mapster;
using Microsoft.EntityFrameworkCore;
using TestApi.Context;
using TestApi.Dtos;
using TestApi.Entities;
using TestApi.Services.Repo_Unit.Interfaces;

namespace TestApi.Services.Repo_Unit;

public class ParticipantRepository:IRepository<Participant>
{
    private readonly ApiContext _apiContext;
    
    public ParticipantRepository(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }


    public async Task<Participant?> Get(long id)
    {
        var res = await _apiContext.Participants.FindAsync(id);
        return res;
    }

    public async Task<Participant?> Create(Participant item)
    {
        await _apiContext.Participants.AddAsync(item);
        return await Get(item.Id);
    }

    public void Update(Participant item)
    {
        _apiContext.Participants.Update(item);
    }

    public async Task Delete(long id)
    {
        var res = await _apiContext.Participants.FindAsync(id);
        if (res != null)
            _apiContext.Participants.Remove(res);
    }
    public async Task Save() => await _apiContext.SaveChangesAsync();
}