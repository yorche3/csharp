namespace DataStructuresAdvanced;

internal sealed class GraphNode : Node
{
    internal GraphNode(int label) : base(label) { }

    internal List<int> Neighbors { get; } = new();
    internal GraphNode? NextVertex { get; set; }
}