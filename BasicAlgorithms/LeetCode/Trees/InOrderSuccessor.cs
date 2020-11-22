using System;
using System.Collections.Generic;
using NUnit.Framework;

public class TNode
{
    public int value;
    public TNode left;
    public TNode right;
    public TNode parent;
}
public class InOrderSuccessorSln
{


    public static TNode findInOrderSuccessor(TNode inputNode)
    {
        if (inputNode == null)
            return null;

        TNode topMostNode = GoToRoot(inputNode);

        Stack<TNode> stack = new Stack<TNode>();
        HashSet<TNode> seens = new HashSet<TNode>();

        stack.Push(topMostNode);
        while (stack.Count > 0)
        {
            TNode n = stack.Pop();

            if (!seens.Contains(n))
                seens.Add(n);

            if (n.left != null && !seens.Contains(n.left))
                stack.Push(n.left);
            if (n.right != null && !seens.Contains(n.right))
                stack.Push(n.right);
        }
        var enumerator1 = seens.GetEnumerator();
        while (enumerator1.MoveNext())
        {
            Console.WriteLine(enumerator1.Current.value.ToString());
        }

        return null;
    }

    public static void findInOrderSuccessor1(TNode n)
    {
        HashSet<TNode> h = new HashSet<TNode>();

        DoInOrderTraverse(h, n);
    }

    private static void DoInOrderTraverse(HashSet<TNode> h, TNode n)
    {
        if (n.left != null)
            DoInOrderTraverse(h, n.left);

        if (!h.Contains(n))
        {
            h.Add(n);
        }

        if (n.right != null)
            DoInOrderTraverse(h, n.right);

    }

    private static TNode GoToRoot(TNode input)
    {
        TNode p = input.parent;
        while (p != null)
        {
            p = input.parent;

        }
        return p == null ? input : p;
    }
}

[TestFixture]
public class InOrderSuccessor_Test
{
    TNode root = null;

    [SetUp]
    public void SetupData()
    {
        TNode n1 = new TNode();
        n1.left = null;
        n1.right = new TNode();
        n1.parent = null;

        n1.value = 5;
        n1.right.value = 9;

        TNode n2 = n1.right;
        n2.left = new TNode();
        n2.right = new TNode();
        n2.left.value = 12;
        n2.right.value = 20;
        n2.parent = n1;

        TNode n3 = n2.left;
        n3.left = new TNode();
        n3.right = new TNode();
        n3.left.value = 11;
        n3.right.value = 14;
        n3.parent = n2;

        root = n1;
    }

    [Test]
    public void InOrderSuccessor_Test1()
    {
        // InOrderSuccessorSln.findInOrderSuccessor(root);
        InOrderSuccessorSln.findInOrderSuccessor1(root);
    }

}

