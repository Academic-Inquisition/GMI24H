using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLab1
{
    public class ListReferencedBased<T> : ListInterface<T>
    {
        private int _count = 0;
        private Node<T>? head;

        public ListReferencedBased()
        {
            head = null;
        }

        public void Add(T data)
        {
            if (head == null)
            {
                Console.WriteLine($"index 1 -> {data}");
            }
            else
            {
                Console.WriteLine($"index {Length() + 1} -> {data}");
            }
            
            Node<T> new_node = new(data);

            if (head == null)
            {
                head = new_node;
                _count++;
                return;
            }

            Node<T> lastNode = GetLastNode();

            lastNode.Next = new_node;
            _count++;
        }

        public void Add(T data, int index)
        {
            if (head == null)
            {
                Console.WriteLine($"index 1 -> {data}");
            }
            else
            {
                Console.WriteLine($"index {index} -> {data}");
            }
            
            Node<T> new_node = new(data);

            if (head == null)
            {
                head = new_node;
                _count++;
                return;
            }
            else if (index == Length() + 1)
            {
                Node<T> lastNode = GetLastNode();
                lastNode.Next = new_node;
                _count++;
                return;
            }

            Node<T> curr = head;

            for (int i = 1; i <= index; i++)
            {
                if (i == index - 1)
                {
                    new_node.Next = curr.Next;
                    curr.Next = new_node;
                    _count++;
                    break;
                }

                curr = curr.Next;
            }
        }

        
        public void Remove(int index)
        {
            // If the index is less than 0 and larger than the max index position of the list then throw an exception!
            if (index <= 0 || index > Length()) throw new ListIndexOutOfBoundsException(index, Length());

            Console.WriteLine($"Tar bort personen på index {index}: {GetValueAtIndex(index)}");

            Node<T>? curr = head;

            for (int i = 1; i <= index; i++)
            {
                if (i == index - 1)
                {
                    Node<T>? temp = curr.Next;
                    curr.Next = temp.Next;
                    _count--;
                    break;
                }

                curr = curr.Next;
            }
        }

        public void Clear()
        {
            head = null;
            _count = 0;
            Console.WriteLine("Listan har tömts");
        }

        
        public T? GetValueAtIndex(int index)
        {
            if (index <= 0 || index > Length()) throw new ListIndexOutOfBoundsException(index, Length());
            if (head != null && index == 1)
            {
                return head.Data;
            }
            else
            {
                int i = 1;
                Node<T> node = head;

                while (node != null && node.Next != null && i < index)
                {
                    node = node.Next;
                    i++;
                }

                if (node == null || node.Next == null && i < index) throw new InvalidOperationException("Can't get a value from an index that is unreachable!");
                return node == null ? default(T) : node.Data;
            }
               
        }


        private Node<T> GetLastNode()
        {
            Node<T> temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }

        
        public bool IsEmpty()
        {
            return _count == 0;
        }

        
        public int Length()
        {
            return _count;
        }

    }

}
