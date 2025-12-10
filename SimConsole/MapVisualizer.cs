using Simulator;
using Simulator.Maps;
using System;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    private char CreatureSymbol(Creature c)
    {
   
        return c switch
        {
            Orc => 'O',
            Elf => 'E',
            _ => '?' 
        };
    }

    public void Draw()
    {
        Console.Clear();

        int w = _map.SizeX;
        int h = _map.SizeY;

        Console.Write(Box.TopLeft);
        for (int i = 0; i < w; i++)
            Console.Write(Box.Horizontal);
        Console.Write(Box.TopRight);
        Console.WriteLine();

        for (int y = 0; y < h; y++)
        {
            Console.Write(Box.Vertical);

            for (int x = 0; x < w; x++)
            {
                var list = _map.At(x, y);

                if (list.Count == 0)
                {
                    Console.Write(' ');
                }
                else if (list.Count == 1)
                {
                   
                    Console.Write(CreatureSymbol(list[0]));
                }
                else
                {
                   
                    Console.Write('X');
                }
            }

            Console.Write(Box.Vertical);
            Console.WriteLine();
        }

        Console.Write(Box.BottomLeft);
        for (int i = 0; i < w; i++)
            Console.Write(Box.Horizontal);
        Console.Write(Box.BottomRight);

        Console.WriteLine();
    }
}
