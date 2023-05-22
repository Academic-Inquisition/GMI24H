
using System;
using System.Text;

public class Tree<T>
{
    public Node<T> _root { get; set; }

    public Tree()
    {
    }

    public Node<T> AddRoot(T value)
    {
        if (_root != null)
        {
            return _root;
        }
        _root = new Node<T>(value);
        return _root;
    }

    public Node<T> AddChild(Node<T> Parent, T value)
    {
        if (Parent == null)
        {
            throw new ArgumentNullException("Parent Node cannot be null");
        }
        Node<T> child = new Node<T>(value);
        child.Parent = Parent;
        Parent.Children.Add(child);
        return child;
    }

    public void Remove(Node<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException("Node cannot be null");
        }
        if (node == _root)
        {
            _root = null;
        }
        else
        {
            node.Parent.Children.Remove(node);
        }
    }

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

    public void Print_Structure(Node<T> node, int level)
    {
        if (level == 0)
            Console.WriteLine($"|_" + node._value);
        else
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                sb.Append("   ");
            }
            sb.Append($"|_" + node._value);
            Console.WriteLine(sb.ToString());
        }
        foreach (Node<T> child in node.Children)
        {
            Print_Structure(child, level + 1);
        }
    }

    public void FindParent()
    {

    }

}