namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    private int singCount = 0;

    public int Agility
    {
        get => agility;
        init => agility = Clamp(value, 0, 10);
    }

    public Elf() : base() { }

    public Elf(string name = "Unknown", int level = 1, int agility = 1)
        : base(name, level)
    {
        Agility = agility;
    }

    public void Sing()
    {
        singCount++;
        Console.WriteLine($"{Name} is singing.");

        if (singCount % 3 == 0)
        {
            if (agility < 10) agility++;
        }
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name} (elf), level {Level}, agility {Agility}.");
    }

    public override int Power => 8 * Level + 2 * Agility;

    private static int Clamp(int v, int min, int max) => v < min ? min : (v > max ? max : v);
}
