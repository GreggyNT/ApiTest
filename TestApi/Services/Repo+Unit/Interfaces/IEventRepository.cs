using TestApi.Entities;

namespace TestApi.Services.Repo_Unit.Interfaces;

public interface IEventRepository
{
    public IEnumerable<Event> GetAll(); 
    public Task<Event?> Get(long id); 
    public void Create(Event item); 
    public void Update(Event item);
    public void Delete(long id);
    public Task<Event?> Get(string name);

    public IQueryable<Event?>? Get(DateTime date = new(), string location = "", string category = "");


}