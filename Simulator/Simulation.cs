using Simulator.Maps;
using System;
using System.Collections.Generic;

namespace Simulator
{
    public class Simulation
    {
        /// <summary>
        /// Simulation's map.
        /// </summary>
        public Map Map { get; }

        /// <summary>
        /// Creatures moving on the map.
        /// </summary>
        public List<Creature> Creatures { get; }

        /// <summary>
        /// Starting positions of creatures.
        /// </summary>
        public List<Point> Positions { get; }

        /// <summary>
        /// Cyclic list of creature moves.
        /// </summary>
        public string Moves { get; }

        /// <summary>
        /// Has all moves been done?
        /// </summary>
        public bool Finished { get; private set; } = false;

        private int _turnIndex = 0; 
        private int _creatureIndex = 0;

        /// <summary>
        /// Creature which will be moving current turn.
        /// </summary>
        public Creature CurrentCreature => Creatures[_creatureIndex];

        /// <summary>
        /// Lowercase name of direction which will be used in current turn.
        /// </summary>
        public string CurrentMoveName => Moves[_turnIndex].ToString().ToLower();

        /// <summary>
        /// Constructor
        /// </summary>
        public Simulation(Map map, List<Creature> creatures,
            List<Point> positions, string moves)
        {
            if (creatures == null || creatures.Count == 0)
                throw new ArgumentException("Creatures list cannot be empty.");

            if (positions == null || positions.Count != creatures.Count)
                throw new ArgumentException("Number of positions must match number of creatures.");

            if (moves == null || moves.Length == 0)
                throw new ArgumentException("Moves cannot be empty.");

            Map = map;
            Creatures = creatures;
            Positions = positions;
            Moves = moves;


            for (int i = 0; i < creatures.Count; i++)
            {
                Creatures[i].AssignToMap(Map, Positions[i]);
                Map.Add(Creatures[i], Positions[i]);
            }
        }

        /// <summary>
        /// Makes one move of current creature in current direction.
        /// </summary>
        public void Turn()
        {
            if (Finished)
                throw new InvalidOperationException("Simulation already finished.");


            char moveChar = Moves[_turnIndex];

            bool parsed = DirectionParser.TryParse(moveChar.ToString(), out Direction direction);

            if (parsed)
            {

                CurrentCreature.Go(direction);
            }


            _turnIndex++;


            _creatureIndex++;

            if (_creatureIndex >= Creatures.Count)
                _creatureIndex = 0;


            if (_turnIndex >= Moves.Length)
                Finished = true;
        }
    }
}
