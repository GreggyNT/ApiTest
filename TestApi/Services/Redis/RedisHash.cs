using Newtonsoft.Json;
using StackExchange.Redis;
namespace TestApi.Services;


public class RedisHash:IRedisHash
{
    private IDatabase _db;
    public RedisHash() {
        ConfigureRedis();
    }
    private void ConfigureRedis() {
        _db = ConnectionHelper.Connection.GetDatabase();
    }
    public async Task<Byte[]?> GetData(long key)
    {
        return await _db.HashGetAsync("redis",key);
    }

    public async  Task<bool> SetData(long key, Byte[] value)
    {
        var isSet = await _db.HashSetAsync("redis", key, value);
        return isSet;
    }
}