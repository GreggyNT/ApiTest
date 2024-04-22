namespace TestApi.Services;

public interface IRedisHash
{
    Task<Byte[]?> GetData(long key);
    
    Task<bool> SetData(long key, Byte[] value);
    
}