using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    public abstract class Tile
    {
        public Policy Policy { get; set; }
        public abstract string TileSymbol { get; }


        // TODO: a prioirty queue of utilty values where the largest value is on top

    }
}
