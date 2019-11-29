using System;
using System.Collections.Generic;
using System.Text;

// AUTHOR: MITCHELL MYERS
// DATE: 11/29/2019
// TIME: 2:48 AM

namespace AI____Project_3
{
    public class GoalTile : Tile
    {
        public override string Symbol => "+50";

        public GoalTile() : base()
        {
            foreach (var p in policies)
            {
                p.QValue = 50.0; // for the goal only, set the value to a predefined amount of points
            }
        }
        
    }
}
