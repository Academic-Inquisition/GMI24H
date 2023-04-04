using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLab1
{
    internal class Node<T>
    {
        internal T Data { get; set; }
        internal Node<T>? Next { get; set; }

        public Node(T Data) { this.Data = Data; }
    }
}
