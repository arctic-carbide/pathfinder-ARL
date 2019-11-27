using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    public class AreaMap
    {
        private const int MaxRows = 5;
        private const int MaxColumns = 6;

        public int Rows => MaxRows;
        public int Columns => MaxColumns;

        Dictionary<Tile, int[]> rewards;
        Dictionary<Tile, int[]> frequencies;
        Dictionary<Tile, Policy> policies;

        private Tile[,] tiles;

        public AreaMap()
        {
            InitializeTileMap(Rows, Columns);
        }


        public Tile SelectRandomTile()
        {
            Tile randomTile;

            Random r = new Random();
            int x = r.Next(0, Rows * Columns);

            int row = x / Columns;
            int col = x % Columns;


            randomTile = tiles[row, col];
            return randomTile;
        }
        private void InitializeTileMap(int row, int col)
        {
            tiles = new Tile[row, col];
            string[] lines = System.IO.File.ReadAllLines("maze.txt");

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    tiles[r,c] = Tile.Select(lines[r][c]);
                }
            }
        }

        public void SetPolicy(Tile t, Policy p)
        {
            policies[t] = p;
        }

        public void IncreaseFrequency(Tile t, Policy p)
        {

        }

        public Policy GetOptimalPolicy(Tile t)
        {
            // the optimal policy is the policy with the largest Q value
            // in a priority queue, this will always be the first value



        }

        public Policy GetRandomPolicy(Tile t)
        {

        }


    }
}
