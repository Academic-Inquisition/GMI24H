using System;

public class Node<T>
{
    public T? _value { get; set; }
    public Node<T>? Parent { get; set; }
    public List<Node<T>?> Children { get; set; }

    public Node(T value)
    {
        _value = value;
        Children = new List<Node<T>>();
    }
    
}
