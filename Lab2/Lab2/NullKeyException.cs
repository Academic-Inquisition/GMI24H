using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /**
     * Enkel implementation för en NullKeyException, används när vi får en Null-Key inmatad till någon av våra funktioner.
     */
    [Serializable]
    internal class NullKeyException : Exception
    {
        public NullKeyException() : base("Error: Key is null!") { }
    }
}
