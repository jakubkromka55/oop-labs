using System;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public SmallTorusMap(int sizeX, int sizeY)
            : base(sizeX, sizeY)
        {
            if (sizeX > 20 || sizeY > 20)
                throw new ArgumentException("SmallTorusMap mo¿e mieæ maksymalnie 20x20.");
        }

        public override bool Exist(Point p)
        {
 
            return true;
        }

        public override Point Next(Point current, Direction direction)
        {
            int x = current.X;
            int y = current.Y;

            switch (direction)
            {
                case Direction.Up: y--; break;
                case Direction.Down: y++; break;
                case Direction.Left: x--; break;
                case Direction.Right: x++; break;
            }

            x = (x + SizeX) % SizeX;
            y = (y + SizeY) % SizeY;

            return new Point(x, y);
        }

        public Point NextDiagonal(Point p, int step)
        {
            int x = p.X + step;
            int y = p.Y + step;

            x = (x % SizeX + SizeX) % SizeX;
            y = (y % SizeY + SizeY) % SizeY;

            return new Point(x, y);
        }

        public Point NextDiagonal(Point p, Direction direction)
        {
            int dx = 0;
            int dy = 0;

            switch (direction)
            {
                case Direction.Up:
                    dx = -1; dy = -1;
                    break;
                case Direction.Down:
                    dx = 1; dy = 1;
                    break;
                case Direction.Left:
                    dx = -1; dy = 1;
                    break;
                case Direction.Right:
                    dx = 1; dy = -1;
                    break;
            }

            int x = (p.X + dx + SizeX) % SizeX;
            int y = (p.Y + dy + SizeY) % SizeY;

            return new Point(x, y);
        }
    }
}
