namespace DataStructuresAdvanced;

public sealed class Graph
{
    private GraphNode? _vertices;
    private int _vertexTotal;
    private int _edges;

    public Graph() { }

    private GraphNode? FindVertex(int label)
    {
        GraphNode? current = _vertices;
        while (current is not null)
        {
            if (current.Value == label) return current;
            current = current.NextVertex;
        }
        return null;
    }

    public bool AddVertex(int label)
    {
        if (FindVertex(label) is not null) return true;   // duplicado conserva

        var node = new GraphNode(label) { NextVertex = _vertices };
        _vertices = node;
        _vertexTotal++;
        return true;
    }

    public bool AddEdge(int u, int v)
    {
        GraphNode? source = FindVertex(u);
        if (source is null) return false;
        if (FindVertex(v) is null) return false;

        var neighbors = source.Neighbors;
        int position = 0;
        while (position < neighbors.Count && neighbors[position] < v)
            position++;

        if (position < neighbors.Count && neighbors[position] == v)
            return true;                                  // arista duplicada

        neighbors.Insert(position, v);
        _edges++;
        return true;
    }

    public bool HasEdge(int u, int v)
    {
        GraphNode? source = FindVertex(u);
        if (source is null) return false;
        return source.Neighbors.Contains(v);
    }

    public int[]? GetNeighbors(int u)
    {
        GraphNode? source = FindVertex(u);
        if (source is null) return null;
        return source.Neighbors.ToArray();                // copia independiente
    }

    public bool IsEmpty     => _vertexTotal == 0;
    public int VertexCount  => _vertexTotal;
    public int EdgeCount    => _edges;
}