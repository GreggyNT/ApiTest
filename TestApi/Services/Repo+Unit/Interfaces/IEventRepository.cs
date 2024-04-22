using TestApi.Entities;

namespace TestApi.Services.Repo_Unit.Interfaces;

public interface IEventRepository:IRepository<Event>
{
    public IEnumerable<Event> GetAll(); 
   
    public Task<Event?> Get(string name);
    public IQueryable<Event?>? Get(DateTime date = new(), string location = "", string category = "");


}