public class HandBallMatch : Match<HandBallPlayer>
{
    public override async Task ReadPlayers()
    {
        if (!string.IsNullOrEmpty(FilePath))
        {
            var playerLines = await File.ReadAllLinesAsync(FilePath);
            Players = playerLines.Select(pl => new HandBallPlayer(pl.Split(';'))).ToList();
        }
    }

    public override IEnumerable<Team> Teams()
    {
        var retval = from p in Players
                     group p by p.TeamName into g
                     select new Team(g.Key, g.Sum(x => x.GoalsMade));
        return retval;
    }

    public override Dictionary<char, int[]> GetRuleMatrix()
    {
        var matrix = new Dictionary<char, int[]>();
        matrix.Add('G', new int[] { 50, 5, -2 });
        matrix.Add('F', new int[] { 20, 1, -1 });
        return matrix;
    }

    public override void CalculatePlayerRating(HandBallPlayer Player, bool IsWinnigTeam = false)
    {
        var matrix = GetRuleMatrix();
        var multipliers = matrix[Player.Position];
        var rating = multipliers[0] + multipliers[1] * Player.GoalsMade + multipliers[2] * Player.GoalsReceived;
        Player.RatingPoint = rating;
    }

    public override void CalculatePlayerRatings()
    {
        foreach (var player in Players)
        {
            CalculatePlayerRating(player, false);
        }
    }
}