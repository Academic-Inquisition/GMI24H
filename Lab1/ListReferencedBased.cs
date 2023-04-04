using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLab1
{
    public class ListReferencedBased<T> : ListInterface<T>
    {

        private Node<T>? head;

        public ListReferencedBased()
        {
            head = null;
        }

        public void Add(T item)
        {
            if (MainClass.IsDebug)
            {
                //Console.WriteLine("Lägger till en Person!");
                int i = 1;
                if (head == null) Console.WriteLine($"index {i} -> {item}");
                else
                {
                    Node<T> node = head;
                    while (node.Next != null)
                    {
                        node = node.Next;
                        i++;
                    }
                    Console.WriteLine($"index {i} -> {item}");
                }
            }
            Node<T> new_node = new(item);
            if (head == null)
            {
                head = new_node;
                return;
            }
            Node<T> lastNode = GetLastNode();
            lastNode.Next = new_node;
        }

        // TODO: Finish implementing this
        public void Add(T data, int index)
        {
            throw new NotImplementedException();
        }

        // TODO: Finish implementing this
        public void Remove(int index)
        {
            // If the index is less than 0 and larger than the max index position of the list then throw an exception!
            if (index <= 0 || index > Length()) throw new ListIndexOutOfBoundsException(index, Length());
            Node<T>? node = head;
            int i = 1;
            while (node != null && i+1 < index)
            {
                i++;
                node = node.Next;
            }
        }

        public void Clear()
        {
            head = null;
            if (MainClass.IsDebug) Console.WriteLine("Listan har tömts");
        }

        // TODO: Finish implementing/looking over this
        public T? GetValueAtIndex(int index)
        {
            if (index <= 0 || index > Length()) throw new ListIndexOutOfBoundsException(index, Length());
            if (head != null && index == 0) return head.Data;
            int i = 0;
            Node<T> node = head;
            while (node != null && node.Next != null && i < index)
            {
                node = node.Next;
                i++;
            }
            if (node == null || node.Next == null && i < index) throw new InvalidOperationException("Can't get a value from an index that is unreachable!");
            return node == null ? default(T) : node.Data;
        }

        // TODO: Finish implementing/looking over this
        private Node<T> GetLastNode()
        {
            Node<T> temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }

        // TODO: Finish implementing/looking over this
        public bool IsEmpty()
        {
            return Length() == 0;
        }

        // TODO: Finish implementing/looking over this
        public int Length()
        {
            int length = 0; 
            Node<T>? node = head;
            if (node != null)
            {
                length++;
                while (node.Next != null)
                {
                    node = node.Next;
                    length++;
                }
            }
            return length;
        }

        public override String ToString()
        {
            Node<T>? temp = head;
            StringBuilder builder = new();
            if (temp != null)
            {
                builder.AppendLine(temp.Data.ToString());
                while (temp.Next != null)
                {
                    builder.AppendLine(temp.Next.Data.ToString());
                    temp = temp.Next;
                }
            }
            return builder.ToString();
        }

    }

}
