namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        TestValidators();

        TestObjectsToString();

        Console.WriteLine("\nKoniec testów.");
        Console.WriteLine("Naciśnij dowolny klawisz, aby zamknąć...");
        Console.ReadKey();
    }

    static void TestValidators()
    {
        Console.WriteLine("=== VALIDATOR TEST ===\n");

        Creature[] creatures = {
            new Elf("   legolas   ", 15, 2),
            new Orc("   gorbag", -1, -3),
            new Elf("a", 1, 0),
            new Orc("#########", 2, 15)
        };

        foreach (var c in creatures)
        {
            c.SayHi();
            Console.WriteLine($"{c.Name,-20} Level:{c.Level} Power:{c.Power}\n");
        }

        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new Animals() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);
    }

    static void TestObjectsToString()
    {
        Console.WriteLine("\n=== OBJECTS ToString TEST ===\n");

        object[] myObjects = {
            new Animals() { Description = "dogs"},
            new Birds { Description = "  eagles ", Size = 10 },
            new Elf("e", 15, -3),
            new Orc("morgash", 6, 4)
        };

        Console.WriteLine("My objects:");
        foreach (var o in myObjects)
        {
            Console.WriteLine(o);
        }
    }
}
