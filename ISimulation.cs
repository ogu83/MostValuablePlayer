public interface ISimulation
{
    Task Simulate();

    Task SimulateMatch<T>(Match<T> match) where T : Player;
}
