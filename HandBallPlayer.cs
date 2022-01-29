public class HandBallPlayer : Player
{
    public HandBallPlayer(string[] arr) : base(arr)
    {
        GoalsMade = int.Parse(arr[5]);
        GoalsReceived = int.Parse(arr[6]);
    }

    public int GoalsMade { get; set; }
    public int GoalsReceived { get; set; }
}
