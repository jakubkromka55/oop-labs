using System;
using System.Collections.Generic;

namespace Simulator.Maps
{
    public class Map
    {
        public int SizeX { get; }
        public int SizeY { get; }

        private readonly Dictionary<Point, List<Creature>> _creatures = new();

        public Map(int sizeX, int sizeY)
        {
            if (sizeX < 5 || sizeY < 5)
                throw new ArgumentException("Minimalny rozmiar mapy to 5x5");

            SizeX = sizeX;
            SizeY = sizeY;
        }

        public virtual bool Exist(Point p)
        {
       
            return p.X >= 0 && p.X < SizeX &&
                   p.Y >= 0 && p.Y < SizeY;
        }

        public List<Creature> At(int x, int y) => At(new Point(x, y));

        public List<Creature> At(Point p)
        {
            if (_creatures.TryGetValue(p, out var list))
                return list;

            return new List<Creature>();
        }

        public void Add(Creature creature, Point p)
        {
            if (!Exist(p))
                throw new ArgumentException("Pozycja spoza mapy.");

            if (!_creatures.ContainsKey(p))
                _creatures[p] = new List<Creature>();

            _creatures[p].Add(creature);
        }

        public void Remove(Creature creature, Point p)
        {
            if (_creatures.TryGetValue(p, out var list))
            {
                list.Remove(creature);
                if (list.Count == 0)
                    _creatures.Remove(p);
            }
        }

        public void Move(Creature creature, Point from, Point to)
        {
            Remove(creature, from);
            Add(creature, to);
        }

        public virtual Point Next(Point current, Direction direction)
        {
            int x = current.X;
            int y = current.Y;

            switch (direction)
            {
                case Direction.Up: y--; break;
                case Direction.Down: y++; break;
                case Direction.Left: x--; break;
                case Direction.Right: x++; break;
                default: break;
            }

            return new Point(x, y);
        }
    }
}
