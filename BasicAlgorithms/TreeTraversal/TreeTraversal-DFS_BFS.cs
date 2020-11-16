using System.Collections.Generic;

public interface INode<T>
{
    INode<T> RightNode { get; set; }
    INode<T> LeftNode { get; set; }
    T Value { get; set; }
}
public class Node<T> : INode<T>
{

    public INode<T> LeftNode { get; set; }
    public INode<T> RightNode { get; set; }

    public T Value { get; set; }

}

public class TreeTraversal
{
    public void LoadTestData()
    {
        IDictionary<string, string[]> data = new Dictionary<string, string[]>();

        AddSyntheticHRData(data);

        Node<string> tree = BuildTreeStruct(data);

        DoDepthFirst(tree);

        DoBreadthFirst(tree);
    }

    #region "Load Synthetic Data"
    public void AddSyntheticHRData(IDictionary<string, string[]> data)
    {
        data.Add("Kalai", new string[2] { "Anand", "Vikas" });
        data.Add("Anand", new string[2] { "Ram", "Mathieu" });
        data.Add("Ram", new string[2] { "Nagendran", "Faheem" });
        data.Add("Mathieu", new string[2] { "Kamel", "Nagendran" });
        data.Add("Vikas", new string[] { "Nithy", "Karthi" });
    }
    public Node<string> BuildTreeStruct(IDictionary<string, string[]> data)
    {
        IEnumerator<KeyValuePair<string, string[]>> enumerator = data.GetEnumerator();
        Node<string> tree = null;
        while (enumerator.MoveNext())
        {
            KeyValuePair<string, string[]> currentItem = enumerator.Current;
            tree = AddTestNode(new Node<string>() { Value = currentItem.Key }, currentItem.Value, data);
            break;
        }

        return tree;
    }
    public Node<string> AddTestNode(Node<string> n, string[] nodes, IDictionary<string, string[]> dict)
    {
        if (nodes == null)
            return n;

        n.LeftNode = AddTestNode(new Node<string>() { Value = nodes[0] }, dict.ContainsKey(nodes[0]) ? dict[nodes[0]] : null, dict);
        n.RightNode = AddTestNode(new Node<string>() { Value = nodes[1] }, dict.ContainsKey(nodes[1]) ? dict[nodes[1]] : null, dict);

        return n;
    }

    #endregion

    #region "Do Depth First"

    public void DoDepthFirst(Node<string> tree)
    {
        Stack<INode<string>> stack = new Stack<INode<string>>();

        ISet<INode<string>> seens = new HashSet<INode<string>>();

        stack.Push(tree);

        while (stack.Count > 0)
        {
            INode<string> curr = stack.Pop();

            if (!seens.Contains(curr))
            { seens.Add(curr); System.Console.WriteLine(curr.Value); }

            //Note Process all adjacencies . For examples if you store adjancies as node[] then loop them all
            if (curr.LeftNode != null && !seens.Contains(curr.LeftNode))
                stack.Push(curr.LeftNode);

            if (curr.RightNode != null && !seens.Contains(curr.RightNode))
                stack.Push(curr.RightNode);

        }
        System.Console.WriteLine("Depth First -- done !! ");
    }
    #endregion

    #region "Do Breadth First"

    public void DoBreadthFirst(Node<string> tree)
    {
        Queue<INode<string>> queue = new Queue<INode<string>>();
        ISet<INode<string>> seens = new HashSet<INode<string>>();

        queue.Enqueue(tree);

        while (queue.Count > 0)
        {
            INode<string> curr = queue.Dequeue();

            if (!seens.Contains(curr))
            { seens.Add(curr); System.Console.WriteLine(curr.Value); }

            //Now process adjacencies 
            if (curr.LeftNode != null && !seens.Contains(curr.LeftNode))
                queue.Enqueue(curr.LeftNode);

            if (curr.RightNode != null && !seens.Contains(curr.RightNode))
                queue.Enqueue(curr.RightNode);

        }
        System.Console.WriteLine("Breadth First -- done !! ");
    }
    #endregion
}
