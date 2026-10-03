namespace DataStructuresBasics;

public sealed class Node
{

    public Node(int value)
    {
        Value = value;
        Next = null;
    }

    public int Value { get; }

    public Node? Next { get; set; }
}
