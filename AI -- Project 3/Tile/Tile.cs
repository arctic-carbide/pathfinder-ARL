using System;
using System.Collections.Generic;
using System.Text;

// AUTHOR: MITCHELL MYERS
// DATE: 11/29/2019
// TIME: 2:48 AM

namespace AI____Project_3
{
    public abstract class Tile
    {
        public abstract string Symbol { get; } // the graphical symbol used to indicate the type of tile via the console
        public List<Policy> policies; // all the policies associated with this particular tile

        public List<Tile> AdjacentTiles // tiles that are cardinally adjcent to this one
        {
            get => _adjacentTiles;
            set
            {
                _adjacentTiles = value;
                DetermineTrajectoryTiles(); // when we have adjacent tiles, figure out the trajectory tiles for our policies
            }
        }
        private List<Tile> _adjacentTiles = new List<Tile>();

        private Policy _optimalPolicy;
        public Policy OptimalPolicy => DetermineOptimalPolicy(); // the policy with the highest qvalue
        public Policy RandomPolicy => GetRandomPolicy();



        protected Tile()
        {
            policies = new List<Policy>();
            policies.Add(new MoveWest(this));
            policies.Add(new MoveNorth(this));
            policies.Add(new MoveEast(this));
            policies.Add(new MoveSouth(this));

            _optimalPolicy = policies[0]; // the optimal policy is pretty much any policy on the tile initially, since they are all 0
            // arbitrarily pick the first one
        }

        private Policy GetRandomPolicy()
        {
            Random r = new Random();
            int x = r.Next(0, policies.Count);

            return policies[x];           
        }

        private Policy DetermineOptimalPolicy()
        {
            // the optimal policy is the policy with the highest qvalue
            foreach (Policy p in policies)
            {
                _optimalPolicy = Max(_optimalPolicy, p);
            }

            return _optimalPolicy;
        }

        private void DetermineTrajectoryTiles()
        {
            foreach (Policy p in policies)
            {
                p.DetermineTrajectoryTiles();
            }
        }

        private Policy Max(Policy x, Policy y)
        {
            if (y.QValue > x.QValue) return y;
            else return x;
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

        public void PrintPolicies()
        {
            if (this is FloorTile)
            {
                OptimalPolicy.PrintDirection();
            }
            else if (this is WallTile)
            {
                Console.Write("#### ");
            }
            else
            {
                Console.Write("GGGG ");
            }
        }

        public void PrintQValue(int padding)
        {
            int xOrigin = Console.CursorLeft;
            int yOrigin = Console.CursorTop;

            if (!(this is FloorTile))
            {
                Console.SetCursorPosition(xOrigin - 2, yOrigin);
                Console.Write(Symbol);
            }
            else
            {

                for (int i = 0; i < policies.Count; i++)
                {
                    SetCursor(xOrigin, yOrigin, padding, i);
                    policies[i].PrintQValue();
                }
            }
        }

        private void SetCursor(int x, int y, int pad, int i)
        {
            switch (i % 4)
            {
                case 0: Console.SetCursorPosition(x, y - pad / 2); break;
                case 1: Console.SetCursorPosition(x - pad, y); break;
                case 2: Console.SetCursorPosition(x + pad, y); break;
                case 3: Console.SetCursorPosition(x, y + pad / 2); break;
                default: break;
            }
        }

        public void PrintFrequencies(int padding)
        {
            int xOrigin = Console.CursorLeft;
            int yOrigin = Console.CursorTop;

            if (!(this is FloorTile))
            {
                Console.SetCursorPosition(xOrigin - 2, yOrigin);
                Console.Write(Symbol);
            }
            else
            {

                for (int i = 0; i < policies.Count; i++)
                {
                    SetCursor(xOrigin, yOrigin, padding, i);
                    policies[i].PrintFrequency();
                }
            }

        }
       
    }
}
