using StackExchange.Redis;

public class App {
    private ConnectionMultiplexer Redis;

    public App(){
        Redis = ConnectionMultiplexer.Connect(new ConfigurationOptions(){
            EndPoints =  { Environment.GetEnvironmentVariable("DOTNET_REDIS_ID")! },
            Password = Environment.GetEnvironmentVariable("DOTNET_REDIS_PASSWORD")!
        });

        ChannelMessageQueue Channel = Redis.GetSubscriber().Subscribe("messages");
        Channel.OnMessage(message => {
           Console.WriteLine((string)message.Message!);
        });
    }

    public static void Main(string[] args){
        var obj = new App();
        while(true){}
    }
}
