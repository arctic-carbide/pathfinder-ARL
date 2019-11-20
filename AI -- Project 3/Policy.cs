using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    public abstract class Policy
    {
        public abstract string Direction { get; }

        public void Execute()
        {
            try
            {
                Behavior();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static Policy Select(string o)
        {
            // TODO: SWITCH ON ENUM FOR SELECTING 
            switch (o) {
                default: throw new NotImplementedException();
            }
        }
    }
}
