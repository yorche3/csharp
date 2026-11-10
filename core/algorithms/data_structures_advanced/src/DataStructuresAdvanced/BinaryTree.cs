namespace DataStructuresAdvanced;

public sealed class BinaryTree
{
    private TreeNode? _root;
    private int _count;

    public bool Insert(int value)
    {
        if (_root is null)
        {
            _root = CreateNode(value);
            return true;
        }
        TreeNode current = _root;
        while (true)
        {
            if (value == current.Value)
            {
                return true;   // duplicado idempotente
            }
            if (value < current.Value)
            {
                if (current.Left is null)
                {
                    current.Left = CreateNode(value);
                    return true;
                }
                current = current.Left;
            }
            else
            {
                if (current.Right is null)
                {
                    current.Right = CreateNode(value);
                    return true;
                }
                current = current.Right;
            }
        }
    }

    private TreeNode CreateNode(int value)
    {
        _count++;
        return new TreeNode(value);
    }

    public bool Contains(int value)
    {
        TreeNode? current = _root;
        while (current is not null)
        {
            if (value == current.Value) return true;
            current = value < current.Value ? current.Left : current.Right;
        }
        return false;
    }

    public bool IsEmpty => _count == 0;
    public int Size => _count;
}
