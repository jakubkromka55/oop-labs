namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get => name;
        set => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => level;
        set => level = Validator.Limiter(value, 1, 10);
    }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void Upgrade() => Level = Validator.Limiter(Level + 1, 1, 10);

    public abstract void SayHi();

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public abstract int Power { get; }
}
