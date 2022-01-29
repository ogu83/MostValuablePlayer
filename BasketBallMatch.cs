public class BasketBallMatch : Match<BasketBallPlayer>
{
    public override async Task ReadPlayers()
    {
        if (!string.IsNullOrEmpty(FilePath))
        {
            var playerLines = await File.ReadAllLinesAsync(FilePath);
            Players = playerLines.Select(pl => new BasketBallPlayer(pl.Split(';'))).ToList();
        }
    }

    public override IEnumerable<Team> Teams()
    {
        var retval = from p in Players
                     group p by p.TeamName into g
                     select new Team(g.Key, g.Sum(x => x.ScoredPoints));
        return retval;
    }

    public override Dictionary<char, int[]> GetRuleMatrix()
    {
        var matrix = new Dictionary<char, int[]>();
        matrix.Add('G', new int[] { 2, 3, 1 });
        matrix.Add('F', new int[] { 2, 2, 2 });
        matrix.Add('C', new int[] { 2, 1, 3 });
        return matrix;
    }

    public override void CalculatePlayerRating(BasketBallPlayer Player, bool IsWinnigTeam)
    {
        var matrix = GetRuleMatrix();
        var multipliers = matrix[Player.Position];
        var rating = Player.ScoredPoints * multipliers[0] + Player.Rebounds * multipliers[1] + Player.Assists * multipliers[2];
        if (IsWinnigTeam)
        {
            rating += 10;
        }
        Player.RatingPoint = rating;
    }
}
