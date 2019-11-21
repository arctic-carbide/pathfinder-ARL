using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    class IllegalPolicyException : Exception
    {
        public IllegalPolicyException() : base("CANNOT SET READONLY POLICY TO NEW POLICY") { }
    }
}
