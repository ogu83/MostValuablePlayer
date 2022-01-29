using System.Diagnostics;

public class Simulation : ISimulation
{
    public readonly BasketBallMatch _basketMatch;
    public readonly HandBallMatch _handBallMatch;

    private readonly string path = Directory.GetCurrentDirectory();

    public Simulation()
    {
        var basketBallMatchPath = $"{path}/Basketball.txt";
        _basketMatch = new BasketBallMatch { FilePath = basketBallMatchPath };

        var handBallMatchPath = $"{path}/Handball.txt";
        _handBallMatch = new HandBallMatch { FilePath = handBallMatchPath };
    }

    public async Task SimulateMatch<T>(Match<T> match) where T : Player
    {
        await match.ReadPlayers();
        match.CalculatePlayerRatings();
        Console.WriteLine(match.FilePath);
        Console.WriteLine($"Winner Team: {match.WinnerTeam()}");
        Console.WriteLine($"Most Valuable Player: {match.MostValuablePlayer()}");
        Console.WriteLine("WHOLE PLAYERS");
        foreach (var player in match.Players.OrderByDescending(x => x.RatingPoint))
        {
            Console.WriteLine($"{player}");
        }
        Console.WriteLine();
    }

    public async Task Simulate()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        await SimulateMatch(_basketMatch);
        await SimulateMatch(_handBallMatch);
        sw.Stop();
        Console.WriteLine($"Simulation done in {sw.ElapsedMilliseconds} ms");
    }
}