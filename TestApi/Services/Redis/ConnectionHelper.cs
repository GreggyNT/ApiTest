using StackExchange.Redis;

namespace TestApi.Services;

public class ConnectionHelper {
    static ConnectionHelper() {
        ConnectionHelper.lazyConnection = new Lazy < ConnectionMultiplexer > (() => {
            return ConnectionMultiplexer.Connect("localhost");
        });
    }
    private static Lazy < ConnectionMultiplexer > lazyConnection;
    public static ConnectionMultiplexer Connection {
        get {
            return lazyConnection.Value;
        }
    }
}