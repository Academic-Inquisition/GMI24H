using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLab1
{
    public class SingleReferencedLinkedList<T> : ListInterface<T>
    {
        private class Node<Type>
        {
            internal Type? Data { get; set; }
            internal Node<Type>? Next { get; set; }
        }

        private Node<T>? head;

        public SingleReferencedLinkedList()
        {
            head = null;
        }

        public void Add(T item)
        {
            if (Program.IsDebug) Console.WriteLine($"Added new Node with Data {item}");
            AddLast(item);
        }

        public void AddFirst(T item)
        {
            if (Program.IsDebug) Console.WriteLine($"Added new Head Node with Data {item}");
            Node<T> new_node = new() { Data = item };
            if (head == null)
            {
                head = new_node;
                return;
            }
            new_node.Next = head;
            head = new_node;
        }

        public void AddLast(T item)
        {
            if (Program.IsDebug) Console.WriteLine($"Added new Tail Node with Data {item}");
            Node<T> new_node = new() { Data = item };
            if (head == null)
            {
                head = new_node;
                return;
            }
            Node<T> lastNode = GetLastNode();
            lastNode.Next = new_node;
        }

        public void RemoveFirst()
        {
            Node<T> node = head;
            if (node == null)
            {
                if (Program.IsDebug) Console.WriteLine("Error: Can't remove head if no head exists!");
                else throw new InvalidOperationException("Can't remove head if no head exists!");
            }
            if (node.Next != null) node = node.Next;
            else node = null;
        }

        public void RemoveLast()
        {
            if (GetLastNode() == head) RemoveFirst();
            Node<T> node = head;
            while (node.Next != null) node = node.Next;
            node.Next = null;
        }

        public void Remove(T item)
        {
            Node<T> node = head;
            if (node == null) return;
            if (EqualityComparer<T>.Default.Equals(node.Data, item)) RemoveFirst();
            while (EqualityComparer<T>.Default.Equals(node.Next.Data, item)) node = node.Next;
            node.Next = null;
        }

        public void Clear()
        {
            head = null;
        }

        public T? GetValueAtIndex(int index)
        {
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

        public void SetValueAtIndex(int index, T value)
        {
            if (head != null && index == 0) head.Data = value;
            int i = 0;
            Node<T> node = head;
            while (node != null && node.Next != null && i < index)
            {
                node = node.Next;
                i++;
            }
            node.Data = value;
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

        public override String ToString()
        {
            Node<T> temp = head;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(temp.Data.ToString());
            while (temp.Next != null)
            {
                builder.AppendLine(temp.Next.Data.ToString());
                temp = temp.Next;
            }
            return builder.ToString();
        }
    }

    public interface ListInterface<T>
    {
        public void Add(T item);
        public void AddFirst(T item);
        public void AddLast(T item);
        public void RemoveFirst();
        public void RemoveLast();
        public void Remove(T item);
        public void Clear();
        public T? GetValueAtIndex(int index);
        public void SetValueAtIndex(int index, T value);
    }

}
