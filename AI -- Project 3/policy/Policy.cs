using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    public abstract class Policy
    {
        public double QValue { get; private set; } = 0.0;
        public int Frequency { get; private set; } = 0;
        public abstract int Reward { get; }
        public const double Discount = 0.9;
        
        public abstract string Direction { get; }
        // public abstract void Behavior();

        private Tile hostTile;

        protected Policy(Tile t)
        {
            hostTile = t;
        }

        public void Execute()
        {
            QValue = QValue + (1.0/Frequency) * (Reward + Discount * MaxOfDirection() - QValue);

        }

        private double Sum()
        {
            return Reward + Discount * MaxOfDirection() - QValue;
        }

        private double MaxOfDirection()
        {
            // the max of the tile we're moving to
            // and the tiles that I can drift to
            // unless I hit a wall
            // then I can ignore that tile
        }

        private double FrequencyFunc() { return 1.0 / Frequency; }
        public static Policy Select(string o)
        {
            // TODO: SWITCH ON ENUM FOR SELECTING 
            switch (o) {
                case "<<<<": return new MoveWest();
                case ">>>>": return new MoveEast();
                case "^^^^": return new MoveNorth();
                case "vvvv": return new MoveSouth();
                case "GGGG": return new Stay();
                case "####": return new NoPolicy();
                default: throw new Exception();
            }
        }
    }
}
