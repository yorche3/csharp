namespace DataStructuresAdvanced;

public sealed class TreeNode : Node
{
    public TreeNode(int value) : base(value) { }

    public TreeNode? Left  { get; set; }
    public TreeNode? Right { get; set; }
}