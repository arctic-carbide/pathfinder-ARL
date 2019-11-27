using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    public abstract class Tile
    {
        public abstract char Symbol { get; }
        List<Policy> policies;

        private Policy _optimalPolicy;
        public Policy OptimalPolicy 
        { 
            get
            {
                DetermineOptimalPolicy();
                return _optimalPolicy;
            }

            private set
            {
                _optimalPolicy = value;
            }
        
        }


        // TODO: a prioirty queue of utilty values where the largest value is on top

        public Tile()
        {
            policies = new List<Policy>();
            policies.Add(new MoveWest());
            policies.Add(new MoveNorth());
            policies.Add(new MoveEast());
            policies.Add(new MoveSouth());
        }

        public Policy GetRandomPolicy()
        {
            Random r = new Random();
            int x = r.Next(0, policies.Count - 1);

            return policies[x];           
        }

        private void DetermineOptimalPolicy()
        {
            Policy determinate = policies[0];

            foreach (Policy p in policies)
            {
                determinate = Max(determinate, p);
            }

            OptimalPolicy = determinate;

        }

        private Policy Max(Policy x, Policy y)
        {
            if (y.QValue > x.QValue) return y;
            else return x;
        }
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
                case 'G': return new GoalTile();
                default: throw new InvalidTileException();
            }
        }

        //public List<Tile> GetTrajectoryTiles()
        //{
            
        //}
    }
}
