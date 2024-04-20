using Microsoft.EntityFrameworkCore;
using TestApi.Entities;

namespace TestApi.Context;

public class ApiContext:DbContext
{
    public ApiContext()
    {
    }

    public virtual DbSet<Participant> Participants { get; set; }
    
    public virtual DbSet<Event> Events { get; set; }
    
    public virtual DbSet<EventParticipant> EventParticipants { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("test");

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(t => t.Id);
        });
        
        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(t => t.Id);
        });
        
        modelBuilder.Entity<EventParticipant>(entity =>
        {
            entity.HasKey(t => new { t.ParticipantId,t.EventId });
            entity.HasOne<Event>(e => e.Event)
                .WithMany(s => s.EventParticipants)
                .HasForeignKey(k => k.EventId);
            entity.HasOne<Participant>(e => e.Participant)
                .WithMany(s => s.EventParticipants)
                .HasForeignKey(k => k.ParticipantId);
        });


    }
}