using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    class MoveWest : Policy
    {
        public override string Direction => "<<<<";
        public override int Reward => -1;
        public override void Behavior()
        {
            throw new NotImplementedException();
        }
    }
}
