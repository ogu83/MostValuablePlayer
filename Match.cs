public abstract class Match<T> where T : Player
{
    public string? FilePath { get; set; }

    public List<T> Players { get; set; } = new List<T>();

    public virtual Task ReadPlayers() { return Task.CompletedTask; }

    public virtual Dictionary<char, int[]> GetRuleMatrix() { return new Dictionary<char, int[]>(); }

    public virtual void CalculatePlayerRating(T Player, bool IsWinnigTeam) { return; }

    public virtual IEnumerable<Team> Teams() { return new Team[] { }.AsEnumerable(); }

    public virtual Team WinnerTeam()
    {
        return Teams().OrderByDescending(t => t.Score).FirstOrDefault(new Team("", 0));
    }

    public virtual void CalculatePlayerRatings()
    {
        var winningTeam = WinnerTeam();
        foreach (var player in Players)
        {
            var isPlayerInWinnigTeam = player.TeamName == winningTeam.Name;
            CalculatePlayerRating(player, isPlayerInWinnigTeam);
        }
    }

    public T? MostValuablePlayer() 
    {
        return Players.OrderByDescending(p => p.RatingPoint).FirstOrDefault();
    }
}
