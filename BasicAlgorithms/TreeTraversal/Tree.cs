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
    public Node() { }
    public INode<T> LeftNode { get; set; }
    public INode<T> RightNode { get; set; }

    public T Value { get; set; }

}

public class Tree<T>
{
    public INode<T> Root;

    //This is  Level Order Technique of traversal and loading a tree from an array . 
    //The key is 2*i+1 and 2*1 +2 which basically moves every node to its left and right by 2 points (its binary after all !)
    public INode<int?> LevelOrderTreeLoad(int?[] arr, int index)
    {
        if (index < arr.Length)
        {
            INode<int?> temp = new Node<int?>(arr[index]);

            temp.LeftNode = LevelOrderTreeLoad(arr, (2 * index) + 1);
            temp.RightNode = LevelOrderTreeLoad(arr, (2 * index) + 2);
            return temp;
        }
        return null;
    }

    public IList<IList<int?>> LevelOrderReading(INode<int?> root)
    {
        List<IList<int?>> final = new List<IList<int?>>();

        if (root != null)
        {
            final.Add(new List<int?>() { root.Value });
        }
        //no recursion -> just read children.Value before recursing
        final.Add(ReadNodeLeftRightValue(root));

        IList<IList<int?>> candidates = LevelOrderRead(root); //now start recurse 
        if (candidates.Count > 0)
            final.AddRange(candidates);
        return final;

    }

    IList<IList<int?>> LevelOrderRead(INode<int?> node)
    {
        List<IList<int?>> final = new List<IList<int?>>();
        if (node == null)
            return final;

        List<int?> results = new List<int?>();

        //no recursion -> just read children.Value before recursing
        if (node.LeftNode != null)
            results.AddRange(ReadNodeLeftRightValue(node.LeftNode));
        if (node.RightNode != null)
            results.AddRange(ReadNodeLeftRightValue(node.RightNode));

        if (results.Count > 0)
            final.Add(results);

        IList<IList<int?>> candidates = LevelOrderRead(node.LeftNode); //now recurse
        if (candidates.Count > 0)
            final.AddRange(candidates);

        candidates = LevelOrderRead(node.RightNode); //now recurse
        if (candidates.Count > 0)
            final.AddRange(LevelOrderRead(node.RightNode));

        return final;
    }
    IList<int?> ReadNodeLeftRightValue(INode<int?> node)
    {
        IList<int?> final = new List<int?>();

        if (node != null)
        {
            if (node.LeftNode != null)
                final.Add(node.LeftNode.Value);

            if (node.RightNode != null)
                final.Add(node.RightNode.Value);

        }
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
        tree.Root = tree.LevelOrderTreeLoad(input, 0);
        Assert.That(tree.Root != null && tree.Root.LeftNode.Value == 9 && tree.Root.RightNode.Value == 20, "Worked");
    }

    [Test]
    public void LevelOrderRead_test()
    {
        Tree<int?> tree = new Tree<int?>();
        tree.Root = tree.LevelOrderTreeLoad(input,  0);
        IList<IList<int?>> results = tree.LevelOrderReading(tree.Root);
        Assert.That(results != null, "Worked");
    }

     
}