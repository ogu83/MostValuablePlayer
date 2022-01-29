public class Executor
{
    private readonly ISimulation _simulation;

    public Executor(ISimulation simulation)
    {
        _simulation = simulation;
    }

    public async Task Execute()
    {
        await _simulation.Simulate();
    }
}