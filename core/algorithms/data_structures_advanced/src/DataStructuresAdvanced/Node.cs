namespace DataStructuresAdvanced;

public abstract class Node
{
    protected Node(int value) => Value = value;

    public int Value { get; }
}
