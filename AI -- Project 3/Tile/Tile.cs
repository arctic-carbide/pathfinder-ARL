using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    public abstract class Tile
    {
        public abstract char Symbol { get; }


        // TODO: a prioirty queue of utilty values where the largest value is on top

        public static List<Tile> Select(string str)
        {
            List<Tile> result = new List<Tile>();

            foreach (var c in str)
            {
                result.Add(Select(c));
            }

            return result;
        }

        public static Tile Select(char c)
        {
            switch (c)
            {
                case '.': return new FloorTile();
                case '#': return new WallTile();
                default: throw new InvalidTileException();
            }
        }

    }
}
