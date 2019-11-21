using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    public class AreaMap
    {

        Tile[,] tiles;

        public AreaMap(int row, int col)
        {
            InitializeTileMap(row, col);
        }

        private void InitializeTileMap(int row, int col)
        {
            tiles = new Tile[row, col];
            

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    tiles
                }
            }
        }



    }
}
