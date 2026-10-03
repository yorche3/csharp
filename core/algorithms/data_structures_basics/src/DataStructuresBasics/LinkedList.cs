namespace DataStructuresBasics;

public sealed class LinkedList
{
    private Node? _head;
    private Node? _tail;
    private int _count;

    public LinkedList()
    {
        _head = null;
        _tail = null;
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

    public int HeadValue()
    {
        if (_head == null)
        {
            return -1;
        }
        return _head.Value;
    }

    public void InsertHead(int value)
    {
        Node newNode = new Node(value) { Next = _head };
        _head = newNode;
        if (_tail == null)
        {
            _tail = newNode;
        }
        _count++;
    }

    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }
        _count++;
    }

    public bool Delete(int value)
    {
        Node? previous = null;
        Node? current = _head;
        while (current != null)
        {
            if (current.Value == value)
            {
                if (previous == null)
                {
                    _head = current.Next;
                    if (_head == null)
                    {
                        _tail = null;
                    }
                }
                else
                {
                    previous.Next = current.Next;
                    if (previous.Next == null)
                    {
                        _tail = previous;
                    }
                }
                _count--;
                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false;
    }
}
