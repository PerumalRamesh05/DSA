using System;
using System.Collections.Generic;
using NUnit.Framework;

public interface INode<T>
{
    INode<T> RightNode { get; set; }
    INode<T> LeftNode { get; set; }
    T Value { get; set; }
}
public class Node<T> : INode<T>
{

    public Node(T value)
    {
        Value = value;
    }
    public Node() {}
    public INode<T> LeftNode { get; set; }
    public INode<T> RightNode { get; set; }

    public T Value { get; set; }

}

public class Tree<T>
{
    public INode<T> Root;

    //This is  Level Order Technique of traversal and loading a tree from an array . 
    //The key is 2*i+1 and 2*1 +2 which basically moves every node to its left and right by 2 points (its binary after all !)
    public INode<int?> LevelOrderTreeLoad(int?[] arr, INode<int?> root, int index)
    {
        if (index < arr.Length)
        {
            INode<int?> temp = new Node<int?>(arr[index]);
            root = temp;

           root.LeftNode = LevelOrderTreeLoad(arr, root.LeftNode, (2 * index) + 1);
           root.RightNode= LevelOrderTreeLoad(arr, root.RightNode, (2 * index) + 2);

        }
        return root;
    }

    public IList<IList<int?>> LevelOrderReading(INode<int?> root)
    {
        IList<IList<int?>> final = new List<IList<int?>>();

        if (root != null)
        {
            final.Add(new List<int?>() { root.Value });
        }

        final.Add(LevelOrderRead(root.LeftNode));
        final.Add(LevelOrderRead(root.RightNode));
    
        return final;

    }

    IList<int?> LevelOrderRead(INode<int?> node)
    {
        List<int?> final = new List<int?>();

        final.AddRange(LevelOrderRead(node.LeftNode));
        final.AddRange(LevelOrderRead(node.RightNode));

        return final;
    }
}


[TestFixture]
public class TreeLoading_Tests
{

    public int?[] input = null;

    [SetUp]
    public void SetupInput()
    {
        input = new int?[] { 3, 9, 20, null, null, 15, 17 };
    }

    [Test]
    public void LevelOrderTreeLoad_test()
    {
        Tree<int?> tree = new Tree<int?>();
        tree.Root = tree.LevelOrderTreeLoad(input , tree.Root, 0);
        Assert.That(tree.Root != null && tree.Root.LeftNode.Value ==3 && tree.Root.RightNode.Value ==20, "Worked");
    }

}