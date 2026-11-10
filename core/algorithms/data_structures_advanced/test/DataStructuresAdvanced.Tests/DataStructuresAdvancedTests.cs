namespace DataStructuresAdvanced.Tests;

public class DataStructuresAdvancedTests
{
    private const int NodeValue = 10;
    private const int LeftValue = 20;
    private const int RightValue = 30;
    private const int RootValue = 50;
    private const int LowerValue = 30;
    private const int HigherValue = 70;
    private const int MissingValue = 99;

    private const int LabelA = 10;
    private const int LabelB = 30;
    private const int LabelC = 50;
    private const int LabelD = 70;
    private const int MissingLabel = 99;
    private const int SecondMissingLabel = 98;

    [Fact]
    public void TestTreeNodeOperations()
    {
        RunCases(
        [
            ("create a tree node", () =>
            {
                var node = new TreeNode(NodeValue);

                AssertEqual(NodeValue, node.Value, "TreeNode", "create a tree node");
            }),
            ("absent initial links", () =>
            {
                var node = new TreeNode(NodeValue);

                AssertNull(node.Left, "TreeNode", "absent initial links");
                AssertNull(node.Right, "TreeNode", "absent initial links");
            }),
            ("link two children", () =>
            {
                var parent = new TreeNode(NodeValue);
                parent.Left = new TreeNode(LeftValue);
                parent.Right = new TreeNode(RightValue);

                AssertEqual(LeftValue, parent.Left!.Value, "TreeNode", "link two children");
                AssertEqual(RightValue, parent.Right!.Value, "TreeNode", "link two children");
            }),
            ("traverse each link", () =>
            {
                var parent = new TreeNode(NodeValue);
                parent.Left = new TreeNode(LeftValue);
                parent.Right = new TreeNode(RightValue);

                AssertEqual(LeftValue, parent.Left!.Value, "TreeNode", "traverse each link");
                AssertEqual(RightValue, parent.Right!.Value, "TreeNode", "traverse each link");
                AssertNull(parent.Left.Left, "TreeNode", "traverse each link");
                AssertNull(parent.Left.Right, "TreeNode", "traverse each link");
                AssertNull(parent.Right.Left, "TreeNode", "traverse each link");
                AssertNull(parent.Right.Right, "TreeNode", "traverse each link");
            }),
            ("unlink children", () =>
            {
                var parent = new TreeNode(NodeValue);
                parent.Left = new TreeNode(LeftValue);
                parent.Right = new TreeNode(RightValue);

                parent.Left = null;
                AssertNull(parent.Left, "TreeNode", "unlink children: clear left");
                AssertEqual(NodeValue, parent.Value, "TreeNode", "unlink children: clear left");
                AssertEqual(RightValue, parent.Right!.Value, "TreeNode", "unlink children: clear left");

                parent.Right = null;
                AssertNull(parent.Left, "TreeNode", "unlink children: clear right");
                AssertNull(parent.Right, "TreeNode", "unlink children: clear right");
                AssertEqual(NodeValue, parent.Value, "TreeNode", "unlink children: clear right");
            })
        ]);
    }

    [Fact]
    public void TestBinaryTreeOperations()
    {
        RunCases(
        [
            ("create empty", () =>
            {
                var tree = new BinaryTree();

                AssertTrue(tree.IsEmpty, "BinaryTree", "create empty");
                AssertEqual(0, tree.Size, "BinaryTree", "create empty");
                AssertFalse(tree.Contains(RootValue), "BinaryTree", "create empty");
            }),
            ("insert the root", () =>
            {
                var tree = new BinaryTree();

                AssertTrue(tree.Insert(RootValue), "BinaryTree", "insert the root");
                AssertEqual(1, tree.Size, "BinaryTree", "insert the root");
                AssertFalse(tree.IsEmpty, "BinaryTree", "insert the root");
                AssertTrue(tree.Contains(RootValue), "BinaryTree", "insert the root");
            }),
            ("insert lower and higher", () =>
            {
                var tree = new BinaryTree();

                AssertTrue(tree.Insert(RootValue), "BinaryTree", "insert lower and higher: root");
                AssertTrue(tree.Insert(LowerValue), "BinaryTree", "insert lower and higher: lower");
                AssertTrue(tree.Insert(HigherValue), "BinaryTree", "insert lower and higher: higher");
                AssertEqual(3, tree.Size, "BinaryTree", "insert lower and higher");
                AssertContainsAll(tree, [RootValue, LowerValue, HigherValue], "insert lower and higher");
            }),
            ("multilevel branches", () =>
            {
                var tree = new BinaryTree();
                int[] values = [RootValue, 30, HigherValue, 20, 40];

                AssertInsertAll(tree, values, "multilevel branches");
                AssertContainsAll(tree, values, "multilevel branches");
                AssertEqual(5, tree.Size, "BinaryTree", "multilevel branches");
            }),
            ("missing value in nonempty tree", () =>
            {
                var tree = new BinaryTree();
                tree.Insert(RootValue);

                AssertFalse(tree.Contains(MissingValue), "BinaryTree", "missing value in nonempty tree");
                AssertEqual(1, tree.Size, "BinaryTree", "missing value in nonempty tree");
                AssertTrue(tree.Contains(RootValue), "BinaryTree", "missing value in nonempty tree");
            }),
            ("idempotent duplicate", () =>
            {
                var tree = new BinaryTree();
                int[] values = [RootValue, 30, HigherValue, 30];

                AssertInsertAll(tree, values, "idempotent duplicate");
                AssertEqual(3, tree.Size, "BinaryTree", "idempotent duplicate");
                AssertContainsAll(tree, [RootValue, 30, HigherValue], "idempotent duplicate");
            }),
            ("ordered insertions", () =>
            {
                var tree = new BinaryTree();
                int[] values = [20, 30, 40, RootValue, HigherValue];

                AssertInsertAll(tree, values, "ordered insertions");
                AssertEqual(5, tree.Size, "BinaryTree", "ordered insertions");
                AssertContainsAll(tree, values, "ordered insertions");
                AssertFalse(tree.Contains(MissingValue), "BinaryTree", "ordered insertions");
            })
        ]);
    }

    [Fact]
    public void TestGraphOperations()
    {
        RunCases(
        [
            ("create empty", () =>
            {
                var graph = new Graph();

                AssertTrue(graph.IsEmpty, "Graph", "create empty");
                AssertEqual(0, graph.VertexCount, "Graph", "create empty");
                AssertEqual(0, graph.EdgeCount, "Graph", "create empty");
                AssertFalse(graph.HasEdge(LabelA, LabelB), "Graph", "create empty");
                AssertNull(graph.GetNeighbors(LabelA), "Graph", "create empty");
            }),
            ("isolated vertex", () =>
            {
                var graph = new Graph();

                AssertTrue(graph.AddVertex(LabelA), "Graph", "isolated vertex");
                AssertFalse(graph.IsEmpty, "Graph", "isolated vertex");
                AssertEqual(1, graph.VertexCount, "Graph", "isolated vertex");
                AssertEqual(0, graph.EdgeCount, "Graph", "isolated vertex");
                AssertSequence([], graph.GetNeighbors(LabelA), "Graph", "isolated vertex");
            }),
            ("nonconsecutive labels and directed edge", () =>
            {
                var graph = new Graph();
                graph.AddVertex(LabelA);
                graph.AddVertex(LabelD);

                AssertTrue(graph.AddEdge(LabelA, LabelD), "Graph", "nonconsecutive labels and directed edge");
                AssertTrue(graph.HasEdge(LabelA, LabelD), "Graph", "nonconsecutive labels and directed edge: forward");
                AssertFalse(graph.HasEdge(LabelD, LabelA), "Graph", "nonconsecutive labels and directed edge: reverse");
                AssertEqual(2, graph.VertexCount, "Graph", "nonconsecutive labels and directed edge");
                AssertEqual(1, graph.EdgeCount, "Graph", "nonconsecutive labels and directed edge");
            }),
            ("duplicate vertex preserves adjacency", () =>
            {
                var graph = new Graph();
                AssertTrue(graph.AddVertex(LabelA), "Graph", "duplicate vertex preserves adjacency: first vertex");
                AssertTrue(graph.AddVertex(LabelB), "Graph", "duplicate vertex preserves adjacency: second vertex");
                AssertTrue(graph.AddEdge(LabelA, LabelB), "Graph", "duplicate vertex preserves adjacency: edge");
                AssertTrue(graph.AddVertex(LabelA), "Graph", "duplicate vertex preserves adjacency: duplicate");

                AssertEqual(2, graph.VertexCount, "Graph", "duplicate vertex preserves adjacency");
                AssertEqual(1, graph.EdgeCount, "Graph", "duplicate vertex preserves adjacency");
                AssertSequence([LabelB], graph.GetNeighbors(LabelA), "Graph", "duplicate vertex preserves adjacency");
            }),
            ("duplicate edge", () =>
            {
                var graph = new Graph();
                graph.AddVertex(LabelA);
                graph.AddVertex(LabelB);

                AssertTrue(graph.AddEdge(LabelA, LabelB), "Graph", "duplicate edge: first");
                AssertTrue(graph.AddEdge(LabelA, LabelB), "Graph", "duplicate edge: second");
                AssertEqual(2, graph.VertexCount, "Graph", "duplicate edge");
                AssertEqual(1, graph.EdgeCount, "Graph", "duplicate edge");
                AssertSequence([LabelB], graph.GetNeighbors(LabelA), "Graph", "duplicate edge");
            }),
            ("missing endpoint without mutation", () =>
            {
                var graph = new Graph();
                graph.AddVertex(LabelA);
                graph.AddVertex(LabelB);
                graph.AddEdge(LabelA, LabelB);

                AssertFalse(graph.AddEdge(LabelA, MissingLabel), "Graph", "missing endpoint: missing target");
                AssertFalse(graph.AddEdge(MissingLabel, LabelA), "Graph", "missing endpoint: missing source");
                AssertFalse(graph.AddEdge(SecondMissingLabel, MissingLabel), "Graph", "missing endpoint: both missing");
                AssertFalse(graph.AddEdge(MissingLabel, MissingLabel), "Graph", "missing endpoint: missing loop");

                AssertEqual(2, graph.VertexCount, "Graph", "missing endpoint without mutation");
                AssertEqual(1, graph.EdgeCount, "Graph", "missing endpoint without mutation");
                AssertSequence([LabelB], graph.GetNeighbors(LabelA), "Graph", "missing endpoint without mutation");
                AssertSequence([], graph.GetNeighbors(LabelB), "Graph", "missing endpoint without mutation");
                AssertFalse(graph.HasEdge(LabelA, MissingLabel), "Graph", "missing endpoint without mutation");
                AssertFalse(graph.HasEdge(MissingLabel, LabelA), "Graph", "missing endpoint without mutation");
                AssertFalse(graph.HasEdge(SecondMissingLabel, MissingLabel), "Graph", "missing endpoint without mutation");
                AssertFalse(graph.HasEdge(MissingLabel, MissingLabel), "Graph", "missing endpoint without mutation");
                AssertNull(graph.GetNeighbors(SecondMissingLabel), "Graph", "missing endpoint without mutation");
                AssertNull(graph.GetNeighbors(MissingLabel), "Graph", "missing endpoint without mutation");
            }),
            ("sorted neighbours and counts", () =>
            {
                var graph = new Graph();
                foreach (int label in new[] { LabelA, LabelB, LabelC, LabelD })
                {
                    graph.AddVertex(label);
                }

                AssertTrue(graph.AddEdge(LabelA, LabelD), "Graph", "sorted neighbours and counts: (10,70)");
                AssertTrue(graph.AddEdge(LabelA, LabelB), "Graph", "sorted neighbours and counts: (10,30)");
                AssertTrue(graph.AddEdge(LabelA, LabelC), "Graph", "sorted neighbours and counts: (10,50)");
                AssertTrue(graph.AddEdge(LabelB, LabelC), "Graph", "sorted neighbours and counts: (30,50)");

                AssertSequence([LabelB, LabelC, LabelD], graph.GetNeighbors(LabelA), "Graph", "sorted neighbours and counts");
                AssertSequence([LabelC], graph.GetNeighbors(LabelB), "Graph", "sorted neighbours and counts");
                AssertSequence([], graph.GetNeighbors(LabelC), "Graph", "sorted neighbours and counts");
                AssertSequence([], graph.GetNeighbors(LabelD), "Graph", "sorted neighbours and counts");
                AssertEqual(4, graph.VertexCount, "Graph", "sorted neighbours and counts");
                AssertEqual(4, graph.EdgeCount, "Graph", "sorted neighbours and counts");
            }),
            ("missing-edge query", () =>
            {
                var graph = new Graph();
                graph.AddVertex(LabelA);
                graph.AddVertex(LabelB);

                AssertFalse(graph.HasEdge(LabelA, LabelB), "Graph", "missing-edge query");
                AssertEqual(2, graph.VertexCount, "Graph", "missing-edge query");
                AssertEqual(0, graph.EdgeCount, "Graph", "missing-edge query");
                AssertFalse(graph.IsEmpty, "Graph", "missing-edge query");
            }),
            ("neighbours of missing vertex", () =>
            {
                var graph = new Graph();
                graph.AddVertex(LabelA);

                AssertNull(graph.GetNeighbors(MissingLabel), "Graph", "neighbours of missing vertex");
                AssertSequence([], graph.GetNeighbors(LabelA), "Graph", "neighbours of missing vertex: empty differs from failure");
                AssertEqual(1, graph.VertexCount, "Graph", "neighbours of missing vertex");
                AssertEqual(0, graph.EdgeCount, "Graph", "neighbours of missing vertex");
            }),
            ("self-loop and duplicate", () =>
            {
                var graph = new Graph();
                graph.AddVertex(LabelA);

                AssertTrue(graph.AddEdge(LabelA, LabelA), "Graph", "self-loop and duplicate: first");
                AssertTrue(graph.AddEdge(LabelA, LabelA), "Graph", "self-loop and duplicate: second");
                AssertTrue(graph.HasEdge(LabelA, LabelA), "Graph", "self-loop and duplicate");
                AssertSequence([LabelA], graph.GetNeighbors(LabelA), "Graph", "self-loop and duplicate");
                AssertEqual(1, graph.VertexCount, "Graph", "self-loop and duplicate");
                AssertEqual(1, graph.EdgeCount, "Graph", "self-loop and duplicate");
            }),
            ("neighbour-result isolation", () =>
            {
                var graph = new Graph();
                graph.AddVertex(LabelA);
                graph.AddVertex(LabelB);
                graph.AddVertex(LabelC);
                graph.AddEdge(LabelA, LabelB);

                int[]? saved = graph.GetNeighbors(LabelA);
                int[]? copy = graph.GetNeighbors(LabelA);
                Assert.NotNull(copy);
                copy![0] = MissingLabel;

                AssertSequence([LabelB], graph.GetNeighbors(LabelA), "Graph", "neighbour-result isolation: changing the copy");

                graph.AddEdge(LabelA, LabelC);

                AssertSequence([LabelB], saved, "Graph", "neighbour-result isolation: saved result");
                AssertSequence([LabelB, LabelC], graph.GetNeighbors(LabelA), "Graph", "neighbour-result isolation: fresh query");
                AssertEqual(3, graph.VertexCount, "Graph", "neighbour-result isolation");
                AssertEqual(2, graph.EdgeCount, "Graph", "neighbour-result isolation");
            })
        ]);
    }

    private static void RunCases((string Name, Action Verify)[] cases)
    {
        foreach (var testCase in cases)
        {
            testCase.Verify();
        }
    }

    private static void AssertInsertAll(BinaryTree tree, int[] values, string caseName)
    {
        foreach (int value in values)
        {
            AssertTrue(tree.Insert(value), "BinaryTree", $"{caseName}: insert {value}");
        }
    }

    private static void AssertContainsAll(BinaryTree tree, int[] values, string caseName)
    {
        foreach (int value in values)
        {
            AssertTrue(tree.Contains(value), "BinaryTree", $"{caseName}: contains {value}");
        }
    }

    private static void AssertSequence(int[] expected, int[]? actual, string subject, string caseName)
    {
        Assert.True(
            actual is not null && expected.SequenceEqual(actual),
            $"{subject} should match the expected sequence for {caseName}; expected [{string.Join(",", expected)}], actual {(actual is null ? "failure (null)" : $"[{string.Join(",", actual)}]")}.");
    }

    private static void AssertEqual<T>(T expected, T actual, string subject, string caseName)
    {
        Assert.True(
            EqualityComparer<T>.Default.Equals(expected, actual),
            $"{subject} should match the expected value for {caseName}; expected '{expected}', actual '{actual}'.");
    }

    private static void AssertTrue(bool actual, string subject, string caseName)
    {
        AssertEqual(true, actual, subject, caseName);
    }

    private static void AssertFalse(bool actual, string subject, string caseName)
    {
        AssertEqual(false, actual, subject, caseName);
    }

    private static void AssertNull(object? actual, string subject, string caseName)
    {
        Assert.True(
            actual is null,
            $"{subject} should use native absence for {caseName}; expected null, actual '{actual}'.");
    }
}
