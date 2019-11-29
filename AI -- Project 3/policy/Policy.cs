using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

// AUTHOR: MITCHELL MYERS
// DATE: 11/29/2019
// TIME: 2:48 AM

namespace AI____Project_3
{
    public abstract class Policy
    {
        public const double Discount = 0.9;
        public int Frequency { get; private set; } = 0;
        public double QValue { get; set; } = 0.0;

        protected abstract int TrajectoryStartingIndex { get; } // determines how to interpret collect adjacent tiles, for drifting and navigation
        public abstract int Reward { get; } // the cost of moving to another tile
        public abstract string Direction { get; } // visual indication of what the policy wants the agent to move to
        
        public List<Tile> TrajectoryTiles { get; } = new List<Tile>(); // all possible tiles the agent can move to
        public List<Tile> DriftTiles => new List<Tile>() { LeftTile, RightTile }; // tiles the agent can drift to, on move
        public Tile LeftTile => TrajectoryTiles[0]; 
        public Tile TargetTile => TrajectoryTiles[1]; // the tile the agent wants to move to
        public Tile RightTile => TrajectoryTiles[2];
        private Tile hostTile; // the tile this policy exists on
        


        protected Policy(Tile t)
        {
            hostTile = t;
        }

        public void DetermineTrajectoryTiles()
        {
            int number = hostTile.AdjacentTiles.Count;
            Tile tile;

            // first tile is left drift
            // second tile is target tile
            // third tile is right drift

            for (int i = 0; i < number - 1; i++)
            {
                tile = hostTile.AdjacentTiles[TrajectoryStartingIndex % number]; // if exceed index bound, wrap
                TrajectoryTiles.Add(tile);
            }

            System.Diagnostics.Debug.Assert(TrajectoryTiles.Count == 3);
        }


        public void Update(Tile target)
        {
            // every update, we increaes policy frequency and update qvalue
            Frequency++;
            QValue = QValue + (1.0/Frequency) * (Reward + Discount * target.OptimalPolicy.QValue - QValue);
        }

        protected abstract List<Policy> GetPolicyInverse(Tile t); // the inverse is everything that is not this policy type
        // for example, if the policy is MoveEast, then we will get every other policy that is not MoveEast for the target tile


        public void PrintQValue()
        {
            Console.Write(QValue.ToString().PadRight(4).Substring(0, 4));
        }

        public void PrintFrequency()
        {
            Console.Write(Frequency);
        }

        public void PrintDirection()
        {
            Console.Write(Direction + " ");
        }
    }
}
