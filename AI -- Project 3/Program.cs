using System;

// AUTHOR: MITCHELL MYERS
// DATE: 11/29/2019
// TIME: 2:48 AM

namespace AI____Project_3
{
    class Program
    {
        const int MaxTrials = 10000;
        static void Main(string[] args)
        {
            Agent agent = new Agent();
            agent.Start(MaxTrials);
        }
    }
}
