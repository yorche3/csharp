namespace DataStructuresAdvanced;

public abstract class Node
{
    private readonly int _value;

    protected Node(int value) => _value = value;

    public int Value => _value;
}