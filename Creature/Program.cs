namespace Simulator;

public class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    private bool _nameSet = false;
    private bool _levelSet = false;

    public string Name
    {
        get => _name;
        set
        {
            if (_nameSet) return;
            _nameSet = true;

            if (string.IsNullOrWhiteSpace(value))
            {
                _name = "Unknown";
                return;
            }

            string n = value.Trim();

            if (n.Length < 3)
                n = n.PadRight(3, '#');

            if (n.Length > 25)
            {
                n = n.Substring(0, 25).TrimEnd();
                if (n.Length < 3)
                    n = n.PadRight(3, '#');
            }

            if (char.IsLetter(n[0]) && char.IsLower(n[0]))
                n = char.ToUpper(n[0]) + n.Substring(1);

            _name = n;
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            if (_levelSet) return;
            _levelSet = true;

            if (value < 1) value = 1;
            if (value > 10) value = 10;

            _level = value;
        }
    }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name} at level {Level}.");
    }

    public string Info => $"{Name}<{Level}>";

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }

    public void Go(Direction dir)
    {
        string d = dir.ToString().ToLower();
        Console.WriteLine($"{Name} goes {d}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var d in directions)
            Go(d);
    }

    public void Go(string directions)
    {
        var parsed = DirectionParser.Parse(directions);
        Go(parsed);
    }
}
