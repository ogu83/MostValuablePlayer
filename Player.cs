public abstract class Player
{
    public string? PlayerName { get; set; }
    public string? NickName { get; set; }
    public int Number { get; set; }
    public string? TeamName { get; set; }
    public char Position { get; set; }

    public Player(string[] arr)
    {
        PlayerName = arr[0];
        NickName = arr[1];
        Number = int.Parse(arr[2]);
        TeamName = arr[3];
        Position = char.Parse(arr[4]);
    }

    public int RatingPoint { get; set; }

    public override string ToString()
    {
        return $"{PlayerName} {NickName} {Number}, Team: {TeamName}, Rating: {RatingPoint}";
    }
}
