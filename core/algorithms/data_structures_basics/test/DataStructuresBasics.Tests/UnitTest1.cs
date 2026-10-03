using DataStructuresBasics;

namespace DataStructuresBasics.Tests;

public class DataStructuresBasicsTests
{
    private const int FirstNodeValue = 10;
    private const int SecondNodeValue = 20;
    private const int HeadValue = 5;
    private const int FirstListValue = 10;
    private const int SecondListValue = 20;
    private const int MissingValue = 99;
    private const int StackTopValue = 30;
    private const int ReusedStackValue = 40;
    private const int ReusedQueueValue = 40;
    private const int FailureValue = 0;

    [Fact]
    public void TestNodeOperations()
    {
        RunCases(
        [
            ("initialize and observe value and link", () =>
            {
                var firstNode = new Node(FirstNodeValue);

                AssertEqual(FirstNodeValue, firstNode.Value, "Node", "initialize and observe value and link");
                AssertNull(firstNode.Next, "Node", "initialize and observe value and link");
            }),
            ("initialize another node, link and traverse", () =>
            {
                var firstNode = new Node(FirstNodeValue);
                var secondNode = new Node(SecondNodeValue);
                firstNode.Next = secondNode;

                AssertEqual(SecondNodeValue, firstNode.Next!.Value, "Node", "initialize another node, link and traverse");
                AssertNull(secondNode.Next, "Node", "initialize another node, link and traverse");
            })
        ]);
    }

    [Fact]
    public void TestLinkedListOperations()
    {
        RunCases(
        [
            ("empty state", () =>
            {
                var list = new LinkedList();

                AssertTrue(list.IsEmpty(), "LinkedList", "empty state");
                AssertEqual(0, list.Size(), "LinkedList", "empty state");
                AssertEqual(FailureValue, list.HeadValue(), "LinkedList", "empty state");
            }),
            ("insert at both ends", () =>
            {
                var list = CreatePopulatedList();

                AssertEqual(4, list.Size(), "LinkedList", "insert at both ends");
                AssertEqual(HeadValue, list.HeadValue(), "LinkedList", "insert at both ends");
            }),
            ("delete first occurrence", () =>
            {
                var list = CreatePopulatedList();

                AssertTrue(list.Delete(FirstListValue), "LinkedList", "delete first occurrence");
                AssertEqual(3, list.Size(), "LinkedList", "delete first occurrence");
                AssertEqual(HeadValue, list.HeadValue(), "LinkedList", "delete first occurrence");
            }),
            ("absent value", () =>
            {
                var list = CreateListAfterFirstDeletion();

                AssertFalse(list.Delete(MissingValue), "LinkedList", "absent value");
                AssertEqual(3, list.Size(), "LinkedList", "absent value");
                AssertEqual(HeadValue, list.HeadValue(), "LinkedList", "absent value");
            }),
            ("empty the list", () =>
            {
                var list = CreateListAfterFirstDeletion();

                AssertTrue(list.Delete(HeadValue), "LinkedList", "empty the list");
                AssertEqual(SecondListValue, list.HeadValue(), "LinkedList", "empty the list");
                AssertTrue(list.Delete(SecondListValue), "LinkedList", "empty the list");
                AssertEqual(FirstListValue, list.HeadValue(), "LinkedList", "empty the list");
                AssertTrue(list.Delete(FirstListValue), "LinkedList", "empty the list");
                AssertTrue(list.IsEmpty(), "LinkedList", "empty the list");
                AssertEqual(0, list.Size(), "LinkedList", "empty the list");
                AssertEqual(FailureValue, list.HeadValue(), "LinkedList", "empty the list");
            })
        ]);
    }

    [Fact]
    public void TestStackOperations()
    {
        RunCases(
        [
            ("empty state and failed removal", () =>
            {
                var stack = new Stack();

                AssertTrue(stack.IsEmpty(), "Stack", "empty state and failed removal");
                AssertEqual(0, stack.Size(), "Stack", "empty state and failed removal");
                AssertEqual(FailureValue, stack.Peek(), "Stack", "empty state and failed removal");
                AssertEqual(FailureValue, stack.Pop(), "Stack", "empty state and failed removal");
            }),
            ("LIFO and non-mutating peek", () =>
            {
                var stack = CreatePopulatedStack();

                AssertEqual(StackTopValue, stack.Peek(), "Stack", "LIFO and non-mutating peek");
                AssertEqual(3, stack.Size(), "Stack", "LIFO and non-mutating peek");
            }),
            ("removal and reuse", () =>
            {
                var stack = CreatePopulatedStack();

                AssertEqual(StackTopValue, stack.Pop(), "Stack", "removal and reuse");
                stack.Push(ReusedStackValue);
                AssertEqual(ReusedStackValue, stack.Pop(), "Stack", "removal and reuse");
                AssertEqual(SecondListValue, stack.Pop(), "Stack", "removal and reuse");
                AssertEqual(FirstListValue, stack.Pop(), "Stack", "removal and reuse");
                AssertTrue(stack.IsEmpty(), "Stack", "removal and reuse");
                AssertEqual(0, stack.Size(), "Stack", "removal and reuse");
            }),
            ("empty after removal", () =>
            {
                var stack = new Stack();

                AssertEqual(FailureValue, stack.Pop(), "Stack", "empty after removal");
                AssertTrue(stack.IsEmpty(), "Stack", "empty after removal");
            })
        ]);
    }

    [Fact]
    public void TestQueueOperations()
    {
        RunCases(
        [
            ("empty state and failed removal", () =>
            {
                var queue = new Queue();

                AssertTrue(queue.IsEmpty(), "Queue", "empty state and failed removal");
                AssertEqual(0, queue.Size(), "Queue", "empty state and failed removal");
                AssertEqual(FailureValue, queue.Peek(), "Queue", "empty state and failed removal");
                AssertEqual(FailureValue, queue.Dequeue(), "Queue", "empty state and failed removal");
            }),
            ("FIFO and non-mutating peek", () =>
            {
                var queue = CreatePopulatedQueue();

                AssertEqual(FirstListValue, queue.Peek(), "Queue", "FIFO and non-mutating peek");
                AssertEqual(3, queue.Size(), "Queue", "FIFO and non-mutating peek");
            }),
            ("removal and reuse", () =>
            {
                var queue = CreatePopulatedQueue();

                AssertEqual(FirstListValue, queue.Dequeue(), "Queue", "removal and reuse");
                queue.Enqueue(ReusedQueueValue);
                AssertEqual(SecondListValue, queue.Dequeue(), "Queue", "removal and reuse");
                AssertEqual(StackTopValue, queue.Dequeue(), "Queue", "removal and reuse");
                AssertEqual(ReusedQueueValue, queue.Dequeue(), "Queue", "removal and reuse");
                AssertTrue(queue.IsEmpty(), "Queue", "removal and reuse");
                AssertEqual(0, queue.Size(), "Queue", "removal and reuse");
            }),
            ("empty after removal", () =>
            {
                var queue = new Queue();

                AssertEqual(FailureValue, queue.Dequeue(), "Queue", "empty after removal");
                AssertTrue(queue.IsEmpty(), "Queue", "empty after removal");
            })
        ]);
    }

    private static LinkedList CreatePopulatedList()
    {
        var list = new LinkedList();
        list.InsertTail(FirstListValue);
        list.InsertTail(SecondListValue);
        list.InsertHead(HeadValue);
        list.InsertTail(FirstListValue);
        return list;
    }

    private static LinkedList CreateListAfterFirstDeletion()
    {
        var list = CreatePopulatedList();
        list.Delete(FirstListValue);
        return list;
    }

    private static Stack CreatePopulatedStack()
    {
        var stack = new Stack();
        stack.Push(FirstListValue);
        stack.Push(SecondListValue);
        stack.Push(StackTopValue);
        return stack;
    }

    private static Queue CreatePopulatedQueue()
    {
        var queue = new Queue();
        queue.Enqueue(FirstListValue);
        queue.Enqueue(SecondListValue);
        queue.Enqueue(StackTopValue);
        return queue;
    }

    private static void RunCases((string Name, Action Verify)[] cases)
    {
        foreach (var testCase in cases)
        {
            testCase.Verify();
        }
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
