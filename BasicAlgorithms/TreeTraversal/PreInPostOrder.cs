using System;
using System.Collections.Generic;
using NUnit.Framework;

public class PreInPostOrderer
{

    //nlr
    public void PrintPreOrder<T>(INode<T> root)
    {
        if (root != null)
            Console.Write(root.Value+ " | ");
        if(root.LeftNode !=null)
           Console.Write(root.LeftNode.Value);
          if(root.RightNode != null )
            Console.Write( " | "+root.RightNode.Value+"\n");

        if (root.LeftNode != null)
            PrintPreOrder<T>(root.LeftNode);

        if (root.RightNode != null)
            PrintPreOrder<T>(root.RightNode);

    }

    //lnr
    public void PrintInOrder<T>(INode<T> root)
    {
         if(root.LeftNode !=null)
           Console.Write(root.LeftNode.Value+" | ");
          if (root != null)
            Console.Write(root.Value);
          if(root.RightNode != null )
            Console.Write( " | "+root.RightNode.Value+"\n");

        if (root.LeftNode != null)
            PrintInOrder<T>(root.LeftNode);

        if (root.RightNode != null)
            PrintInOrder<T>(root.RightNode);

    }

      //lrn
    public void PrintPostOrder<T>(INode<T> root)
    {

        if (root.LeftNode != null)
            PrintPostOrder<T>(root.LeftNode);

        if (root.RightNode != null)
            PrintPostOrder<T>(root.RightNode);

          if (root != null)
            Console.WriteLine(root.Value);

    }
}

[TestFixture]
public class Tree_PreInPostOrder_Test
{
    [Test]
    public void Tree_PreOrder_Test()
    {
        Tree<int?> t = new Tree<int?>();
        t.Root = t.LevelOrderTreeLoad(new int?[] { 3, 9, 20, null, null, 17, 22 }, 0);
        new PreInPostOrderer().PrintPreOrder<int?>(t.Root);
        Assert.That(true);
    }

    [Test]
    public void Tree_InOrder_Test() 
    {
        Tree<int?> t = new Tree<int?>();
        t.Root = t.LevelOrderTreeLoad(new int?[] {3,9,20,null,null,17,22},0) ;
        new PreInPostOrderer().PrintInOrder<int?>(t.Root);
        Assert.That(true);
    }
}
