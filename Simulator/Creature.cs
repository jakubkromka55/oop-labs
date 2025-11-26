namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get => name;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                name = "Unknown";
                return;
            }
            var n = value.Trim();
            if (n.Length > 25) n = n.Substring(0, 25).TrimEnd();
            if (n.Length < 3) n = n.PadRight(3, '#');
            if (char.IsLower(n[0])) n = char.ToUpper(n[0]) + n.Substring(1);
            name = n;
        }
    }

    public int Level
    {
        get => level;
        init => level = value < 1 ? 1 : (value > 10 ? 10 : value);
    }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract void SayHi();

    public string Info => $"{Name} [{Level}]";

    public void Upgrade()
    {
        if (level < 10) level++;
    }

    public void Go(Direction dir) => Console.WriteLine($"{Name} goes {dir.ToString().ToLower()}.");

    public void Go(Direction[] dirs)
    {
        foreach (var d in dirs) Go(d);
    }

    public void Go(string input)
    {
        var dirs = DirectionParser.Parse(input);
        Go(dirs);
    }

    public abstract int Power { get; }
}
