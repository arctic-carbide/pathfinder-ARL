using System;

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
