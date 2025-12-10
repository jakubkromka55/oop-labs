using Simulator;
using Simulator.Maps;
using SimConsole;
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor")
        };

        List<Point> points = new()
        {
            new(2, 2),
            new(3, 1)
        };

        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer visualizer = new(simulation.Map);

        visualizer.Draw();

        while(!simulation.Finished){
            var key=Console.ReadKey(true);
            if(key.Key==ConsoleKey.Escape) break;
            if(key.Key==ConsoleKey.Enter){
                simulation.Turn();
                visualizer.Draw();
            }
        }
    }
}
