namespace DataStructuresBasics;

public sealed class Stack
{
    private Node? _top;
    private int _count;
    
    public Stack()
    {
        _top = null;
        _count = 0;
    }

    public bool IsEmpty()
    {
        return _count == 0;
    }

    public int Size()
    {
        return _count;
    }

    public void Push(int value)
    {
        Node newNode = new Node(value) { Next = _top };
        _top = newNode;
        _count++;
    }

    public int Pop()
    {
        if (_top == null)
        {
            return -1;
        }
        int value = _top.Value;
        _top = _top.Next;
        _count--;
        return value;
    }

    public int Peek()
    {
        if (_top == null)
        {
            return -1;
        }
        return _top.Value;
    }
}