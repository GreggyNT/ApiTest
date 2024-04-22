using TestApi.Context;
using TestApi.Dtos;
using TestApi.Entities;
using TestApi.Services.Repo_Unit.Interfaces;

namespace TestApi.Services.Repo_Unit;

public class EventParticipantRepository:IEventParticipantRepository
{
    private readonly ApiContext _apiContext;

    public EventParticipantRepository(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }

    public async Task AddToEvent(long partId, long eventId)
    {
       await _apiContext.EventParticipants.AddAsync(new EventParticipant(eventId, partId));
    }
    public IEnumerable<EventParticipant> GetEventParticipants(long id)=> _apiContext.EventParticipants.Select(x=>x).Where(x=>x.EventId==id).ToList();

    public void RemoveFromEvent(long partId, long eventId)
    {
        _apiContext.EventParticipants.Remove(new EventParticipant(eventId, partId));
    }
}