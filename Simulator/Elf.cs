namespace Simulator;

public class Elf : Creature
{
    private int agility;
    private int singCounter = 0;

    public int Agility
    {
        get => agility;
        set => agility = Validator.Limiter(value, 0, 10);
    }

    public Elf() { }

    public Elf(string name, int level = 1, int agility = 1)
        : base(name, level)
    {
        Agility = agility;
    }

    public void Sing()
    {
        singCounter++;
        if (singCounter % 3 == 0)
            Agility++;
    }

    public override void SayHi()
    {
        
    }

    public override string Info => $"{Name} [{Level}][{Agility}]";

    public override int Power => 8 * Level + 2 * Agility;
}
