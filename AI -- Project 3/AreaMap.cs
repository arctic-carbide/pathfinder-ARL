using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

// AUTHOR: MITCHELL MYERS
// DATE: 11/29/2019
// TIME: 2:48 AM

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
            EstablishTilePolicies();
        }

        private void EstablishTilePolicies()
        {
            Tile currentTile;
            List<Tile> adjacentTiles;

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    currentTile = tiles[r, c];
                    adjacentTiles = new List<Tile>();
                    if (currentTile is FloorTile)
                    {

                        adjacentTiles.Add(GetTile(r, c - 1));
                        adjacentTiles.Add(GetTile(r - 1, c));
                        adjacentTiles.Add(GetTile(r, c + 1));
                        adjacentTiles.Add(GetTile(r + 1, c));

                        currentTile.AdjacentTiles = adjacentTiles;
                    }
                }
            }
        }

        private Tile GetTile(int row, int column)
        {
            if (row >= 0 && row < Rows && column >= 0 && column < Columns)
            {
                return tiles[row, column];
            }
            else
            {
                return new WallTile();
            }
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
            string path = "../../../maze.txt";
            string[] lines = System.IO.File.ReadAllLines(path);

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

        public void PrintQValue(int padding)
        {
            int xOrigin = Console.CursorLeft + padding;
            int yOrigin = Console.CursorTop + padding;

            Console.WriteLine("POLICY QVALUE MAP");
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    Console.SetCursorPosition(xOrigin + padding * c * 4, yOrigin + padding * r * 2);
                    tiles[r, c].PrintQValue(padding);
                }
            }

            Console.WriteLine("\n");
        }

        public void PrintFrequency(int padding)
        {
            int xOrigin = Console.CursorLeft + padding;
            int yOrigin = Console.CursorTop + padding;

            Console.WriteLine("POLICY FREQUENCY MAP");
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    Console.SetCursorPosition(xOrigin + padding * c * 4, yOrigin + padding * r * 2);
                    tiles[r, c].PrintFrequencies(padding);
                }
            }

            Console.WriteLine("\n");
        }

        public void PrintPolicies()
        {
            Console.WriteLine("OPTIMAL POLICY MAP");
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    tiles[r, c].PrintPolicies();
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine();
        }

    }
}
