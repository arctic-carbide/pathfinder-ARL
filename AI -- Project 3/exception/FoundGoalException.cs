using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    class FoundGoalException : Exception
    {
        public FoundGoalException() : base("YOU FOUND THE GOAL") { }
    }
}
