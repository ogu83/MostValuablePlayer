public class Team
{
    public Team(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public string Name { get; private set; }

    public int Score { get; private set; }

    public override string ToString()
    {
        return $"{Name}: {Score}";
    }
}
