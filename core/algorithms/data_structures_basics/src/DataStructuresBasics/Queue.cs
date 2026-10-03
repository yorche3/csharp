namespace DataStructuresBasics;

public sealed class Queue
{
    private Node? _front;
    private Node? _rear;
    private int _count;

    public Queue()
    {
        _front = null;
        _rear = null;
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

    public void Enqueue(int value)
    {
        Node newNode = new Node(value);
        if (_rear == null)
        {
            _front = newNode;
            _rear = newNode;
        }
        else
        {
            _rear.Next = newNode;
            _rear = newNode;
        }
        _count++;
    }

    public int Peek()
    {
        if (_front == null)
        {
            return -1;
        }
        return _front.Value;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            return -1;
        }
        int value = _front.Value;
        _front = _front.Next;
        if (_front == null)
        {
            _rear = null;
        }
        _count--;
        return value;
    }
}