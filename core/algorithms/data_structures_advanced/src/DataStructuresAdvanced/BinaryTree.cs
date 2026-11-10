namespace DataStructuresAdvanced;

public sealed class BinaryTree
{
    private TreeNode? _root;
    private int _count;

    public BinaryTree() { }

    public bool Insert(int value)
    {
        if (_root is null)
        {
            _root = new TreeNode(value);
            _count++;
            return true;
        }
        TreeNode current = _root;
        while (true)
        {
            if (value < current.Value)
            {
                if (current.Left is null)
                {
                    current.Left = new TreeNode(value);
                    _count++;
                    return true;
                }
                current = current.Left;
            }
            else if (value > current.Value)
            {
                if (current.Right is null)
                {
                    current.Right = new TreeNode(value);
                    _count++;
                    return true;
                }
                current = current.Right;
            }
            else
            {
                return true;   // duplicado idempotente
            }
        }
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
    public int Size     => _count;
}