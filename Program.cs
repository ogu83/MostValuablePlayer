using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var task = services?
            .AddSingleton<Executor, Executor>()?
            .BuildServiceProvider()?
            .GetService<Executor>()?
            .Execute();
        if (task != null)
        {
            await task;
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ISimulation, Simulation>();
    }
}