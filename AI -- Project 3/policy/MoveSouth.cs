using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    class MoveSouth : Policy
    {
        public override string Direction => "vvvv";
        public override int Reward => -2;
        public override void Behavior()
        {
            throw new NotImplementedException();
        }
    }
}
