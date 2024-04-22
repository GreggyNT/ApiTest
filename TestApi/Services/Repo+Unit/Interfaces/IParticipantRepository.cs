using TestApi.Dtos;
using TestApi.Entities;

namespace TestApi.Services.Repo_Unit.Interfaces;

public interface IParticipantRepository
{                                                                               
    public  Task<ParticipantDto?> Get(long id);

    public void Create(Participant item);

    public void Update(Participant item);

    public void Delete(long id);

    public Task Save();
}