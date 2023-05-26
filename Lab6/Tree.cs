using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab6 
{
    public class Tree<T>
    {
        public Node<T>? _root { get; set; }

        public Tree() { }

        public Node<T> AddRoot(T value)
        {
            if (_root != null) // if a root already exist then simply return the root.
            {
                return _root;
            }

            _root = new Node<T>(value);
            return _root;
        }

        public Node<T> AddChild(Node<T> Parent, T value)
        {
            if (Parent == null) throw new ArgumentNullException("Parent Node cannot be null");

            Node<T> child = new Node<T>(value);
            child.Parent = Parent; // We need to assign the child a parent.
            Parent.Children.Add(child);

            return child;
        }

        public void Remove(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException("Node cannot be null");

            if (node == _root)
            {
                _root = null;
            }
            else
            {
                node.Parent.Children.Remove(node); // remove a children first then set the parent to null so it becomes empty.
                node.Parent = null;
            }
        }

        [ExcludeFromCodeCoverage]
        public void Print()
        {
            if (_root == null)
            {
                Console.WriteLine("Tree is empty");
            }
            else
            {
                Print_Structure(_root, 0);
            }
        }

        [ExcludeFromCodeCoverage]
        public void Print_Structure(Node<T> node, int level)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < level; i++) sb.Append("   "); // Build a string that prints the values of all nodes. 
            sb.Append($"|_" + node._value);
            Console.WriteLine(sb.ToString());
            foreach (Node<T> child in node.Children)
            {
                Print_Structure(child, level + 1);
            }
        }

        public Node<T> FindParent(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node cannot be null");
            }
            else if (node == _root)
            {
                return _root; // If you don´t check the root you might end up with an infinite loop if the user wants the rootvalue.
            }
            else
            {
                return node.Parent;
            }
        }

        public Node<T>? FindNode(T value)
        {
            if (_root == null) return null; // If there´s no root, then there´s no tree so return null
            return FindNode(_root, value);
        }

        private Node<T> FindNode(Node<T> node, T value)
        {
            if (node._value.Equals(value))
            {
                return node;
            }

            foreach (Node<T> child in node.Children) // Search through all the children until the correct value is found
            {
                if (FindNode(child, value) != null)
                {
                    return FindNode(child, value);

                }
            }

            return null;
        }

    }
}

