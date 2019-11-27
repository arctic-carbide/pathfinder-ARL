using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    public class NoPolicy : Policy
    {
        public override string Direction => "####";
        public override void Behavior()
        {
            throw new NotImplementedException();
        }
    }
}
