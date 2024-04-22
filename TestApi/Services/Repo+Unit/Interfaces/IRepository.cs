namespace TestApi.Services.Repo_Unit.Interfaces;

public interface IRepository<T>
{
    public Task<T?> Get(long id); 
    public Task<T?> Create(T item); 
    public void Update(T item);
    public Task Delete(long id);
    
    public Task Save();
}