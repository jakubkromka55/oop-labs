namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    private int huntCount = 0;

    public int Rage
    {
        get => rage;
        init => rage = Clamp(value, 0, 10);
    }

    public Orc() : base() { }

    public Orc(string name = "Unknown", int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
    }

    public void Hunt()
    {
        huntCount++;
        Console.WriteLine($"{Name} is hunting.");

        if (huntCount % 2 == 0)
        {
            if (rage < 10) rage++;
        }
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name} (orc), level {Level}, rage {Rage}.");
    }

    public override int Power => 7 * Level + 3 * Rage;

    private static int Clamp(int v, int min, int max) => v < min ? min : (v > max ? max : v);
}

