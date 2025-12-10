namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20) throw new ArgumentOutOfRangeException(nameof(size));
        Size = size;
    }

    public override bool Exist(Simulator.Point p)
    {
        var rect = new Simulator.Rectangle(0,0, Size-1, Size-1);
        return rect.Contains(p);
    }

    public override Simulator.Point Next(Simulator.Point p, Simulator.Direction d)
    {
        var n = p.Next(d);
        return Exist(n) ? n : p;
    }

    public override Simulator.Point NextDiagonal(Simulator.Point p, Simulator.Direction d)
    {
        var n = p.NextDiagonal(d);
        return Exist(n) ? n : p;
    }
}
