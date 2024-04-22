using TestApi.Entities;

namespace TestApi.Services.Repo_Unit.Interfaces;

public interface IEventParticipantRepository
{
    public Task AddToEvent(long partId, long eventId);

    public IEnumerable<EventParticipant> GetEventParticipants(long id);

    public void RemoveFromEvent(long partId, long eventId);
}