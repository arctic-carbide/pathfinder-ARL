using System;
using System.Collections.Generic;
using System.Text;

// AUTHOR: MITCHELL MYERS
// DATE: 11/29/2019
// TIME: 2:48 AM

namespace AI____Project_3
{
    class MoveNorth : Policy
    {
        public override string Direction => "^^^^";
        public override int Reward => -2;
        protected override int TrajectoryStartingIndex => 1;

        protected override List<Policy> GetPolicyInverse(Tile t)
        {
            return t.policies.FindAll(p => !(p is MoveNorth));
        }
        public MoveNorth(Tile t) : base(t) { }
    }
}
