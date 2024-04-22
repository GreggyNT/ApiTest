using Microsoft.EntityFrameworkCore;
using TestApi.Context;
using TestApi.Entities;
using TestApi.Services.Repo_Unit.Interfaces;

namespace TestApi.Services.Repo_Unit;

public class EventRepository:IEventRepository
{
    private readonly ApiContext _apiContext;

    public EventRepository(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }


    public IEnumerable<Event> GetAll() => _apiContext.Events;


    public async Task<Event?> Get(long id)
    {
       var res = await _apiContext.Events.FindAsync(id);
       return res ?? null;
    }

    public async void Create(Event item)
    {
        await _apiContext.Events.AddAsync(item);
    }

    public void Update(Event item)
    {
        _apiContext.Events.Update(item);
    }

    public async void Delete(long id)
    {
        var res = await _apiContext.Events.FindAsync(id);
        if (res != null)
            _apiContext.Events.Remove(res);
    }

    public async Task<Event?> Get(string name)
    {
       return await _apiContext.Events.FirstOrDefaultAsync(x => x.Name == name);
    }

    public IQueryable<Event?>? Get(DateTime date = new DateTime(), string location = "", string category = "")
    {
        IQueryable<Event>? res = null;
        if (!date.Equals(new DateTime()))
            res = _apiContext.Events.Select(x => x).Where(x => x.DateTime.Equals(date));
        if  (!location.Equals(""))
            res = res.Intersect(_apiContext.Events.Select(x => x).Where(x => x.Location.Equals(location)));
        if (!category.Equals(""))
            res = res.Intersect(_apiContext.Events.Select(x => x).Where(x => x.Category.Equals(category)));
        return res;
    }

    public async Task Save() => await _apiContext.SaveChangesAsync();
}