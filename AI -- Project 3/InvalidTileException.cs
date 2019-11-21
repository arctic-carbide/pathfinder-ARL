using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    class InvalidTileException : Exception
    {
        public InvalidTileException() : base("PROVIDED SYMBOL DOES NOT MATCH KNOWN TILE TYPES") { }
    }
}
