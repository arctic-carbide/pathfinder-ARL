using System;
using System.Collections.Generic;
using System.Text;

// AUTHOR: MITCHELL MYERS
// DATE: 11/29/2019
// TIME: 2:48 AM

namespace AI____Project_3
{
    class MoveSouth : Policy
    {
        public override string Direction => "vvvv";
        public override int Reward => -2;
        protected override int TrajectoryStartingIndex => 3;

        protected override List<Policy> GetPolicyInverse(Tile t)
        {
            return t.policies.FindAll(p => !(p is MoveSouth));
        }

        public MoveSouth(Tile t) : base(t) { }
    }
}
