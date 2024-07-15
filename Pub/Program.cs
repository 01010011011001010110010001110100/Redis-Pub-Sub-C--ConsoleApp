using StackExchange.Redis;

public class App {
    private ConnectionMultiplexer Redis;

    public App(){
        Redis = ConnectionMultiplexer.Connect(new ConfigurationOptions(){
            EndPoints =  { Environment.GetEnvironmentVariable("DOTNET_REDIS_ID")! },
            Password = Environment.GetEnvironmentVariable("DOTNET_REDIS_PASSWORD")!
        });

        ISubscriber pub = Redis.GetSubscriber();
        pub.Publish("messages", "HOLAAA, ESTE ES UN MENSJAE DESDE EL PUBLICADOR");
    }

    public static void Main(string[] args){
        var obj = new App();
        while(true){}
    }
}
