
using System;

public class Program
{
    static void Main(string[] args)
    {
        // Tree Example
        var tree = new Tree<int>();
        // Add the root node
        tree.AddRoot(1);

        // Add some child nodes
        Console.WriteLine("After adding child 2 and 3 to root 1");
        var node2 = tree.AddChild(tree._root, 2);
        var node3 = tree.AddChild(tree._root, 3);
        tree.Print();
        Console.WriteLine();

        // Add some grandchildren
        Console.WriteLine("After adding child 4 and 5 to node 2");
        var node4 = tree.AddChild(node2, 4);
        var node5 = tree.AddChild(node2, 5);
        tree.Print();
        Console.WriteLine();

        Console.WriteLine("After adding child 6 and 7 to node 3");
        var node6 = tree.AddChild(node3, 6);
        var node7 = tree.AddChild(node3, 7);
        tree.Print();
        Console.WriteLine();

        // Remove node2
        Console.WriteLine("After removing node2 and all it's children");
        tree.Remove(node2);
        tree.Print();
        Console.WriteLine();

        // Find Node with Value 7
        var node72 = tree.FindNode(7);
        Console.WriteLine($"Found node with value {node72._value}: With Parent: {node72.Parent._value}, With {node72.Children.Count} Children");
    }
}
