using System;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public SmallSquareMap(int size)
            : base(size, size)
        {
            if (size > 20)
                throw new ArgumentException("SmallSquareMap mo¿e mieæ maksymalnie rozmiar 20.");
        }

        public int Size => SizeX;

        public Point NextDiagonal(Point p)
        {
            var np = new Point(p.X + 1, p.Y + 1);

            if (Exist(np))
                return np;

            return p;
        }

        public override bool Exist(Point p)
        {
            return base.Exist(p);
        }
    }
}
