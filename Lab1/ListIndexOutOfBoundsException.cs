using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLab1
{
    [Serializable]
    internal class ListIndexOutOfBoundsException : Exception
    {

        public ListIndexOutOfBoundsException() { }

        public ListIndexOutOfBoundsException(int index, int size) : base($"Index: {index} is not a valid value, List of Size: {size}") { }

    }
}
