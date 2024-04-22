namespace TestApi.Entities;

public class EventParticipant
{

    public EventParticipant(long eventId, long participantId)
    {
        EventId = eventId;
        ParticipantId = participantId;
    }
    public long EventId { get; set; }
    public Event Event { get; set; }
    
    public long ParticipantId { get; set; }
    
    public Participant Participant { get; set; }
}