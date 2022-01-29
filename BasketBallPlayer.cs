public class BasketBallPlayer : Player
{
    public BasketBallPlayer(string[] arr) : base(arr)
    {
        ScoredPoints = int.Parse(arr[5]);
        Rebounds = int.Parse(arr[6]);
        Assists = int.Parse(arr[7]);
    }

    public int ScoredPoints { get; set; }
    public int Rebounds { get; set; }
    public int Assists { get; set; }
}
