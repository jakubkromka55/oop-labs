using System;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size));

        Size = size;
    }

    public override bool Exist(Simulator.Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }

    private int Wrap(int value)
    {
        if (value < 0) return Size - 1;
        if (value >= Size) return 0;
        return value;
    }

    public override Simulator.Point Next(Simulator.Point p, Simulator.Direction d)
    {
        var next = p.Next(d);
        return new Simulator.Point(
            Wrap(next.X),
            Wrap(next.Y)
        );
    }

    public override Simulator.Point NextDiagonal(Simulator.Point p, Simulator.Direction d)
    {
        var next = p.NextDiagonal(d);
        return new Simulator.Point(
            Wrap(next.X),
            Wrap(next.Y)
        );
    }
}
