using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    public class MoveEast : Policy
    {
        public override string Direction => ">>>>";
        public override int Reward => -3;
        public override void Behavior()
        {
            throw new NotImplementedException();
        }
    }
}
