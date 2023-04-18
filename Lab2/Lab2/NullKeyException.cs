using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    [Serializable]
    internal class NullKeyException : Exception
    {
        public NullKeyException() : base("Error: Key is null!") { }
    }
}
