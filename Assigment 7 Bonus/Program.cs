class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        /* 
              50
           /     \
          30      70
         /  \    /  \
       20   40  60   80
       */
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(70);
        tree.Insert(60);
        tree.Insert(80);

        Console.WriteLine("Inorder traversal of the given tree");
        tree.InOrderTraversal();

        Console.WriteLine("\nDelete 20");
        tree.Remove(20);
        Console.WriteLine("Inorder traversal of the modified tree");
        tree.InOrderTraversal();

        Console.WriteLine("\nDelete 30");
        tree.Remove(30);
        Console.WriteLine("Inorder traversal of the modified tree");
        tree.InOrderTraversal();

        Console.WriteLine("\nDelete 50");
        tree.Remove(50);
        Console.WriteLine("Inorder traversal of the modified tree");
        tree.InOrderTraversal();

        Console.ReadKey();
    }
}

public class Node
{
    public int Value;
    public Node Left, Right;

    public Node(int item)
    {
        Value = item;
        Left = Right = null;
    }
}

public class BinaryTree
{
    public Node Root;
    
    public void Insert(int value)
    {
        Root = InsertRec(Root, value);
    }

    private Node InsertRec(Node root, int value)
    {
        if (root == null)
        {
            root = new Node(value);
            return root;
        }

        if (value < root.Value)
            root.Left = InsertRec(root.Left, value);
        else if (value > root.Value)
            root.Right = InsertRec(root.Right, value);

        return root;
    }

    // Method to remove an element
    public void Remove(int value)
    {
        Root = RemoveRec(Root, value);
    }

    private Node RemoveRec(Node root, int value)
    {
        if (root == null)
            return root;

        if (value < root.Value)
            root.Left = RemoveRec(root.Left, value);
        else if (value > root.Value)
            root.Right = RemoveRec(root.Right, value);
        else
        {
            if (root.Left == null)
                return root.Right;
            else if (root.Right == null)
                return root.Left;

            root.Value = MinValue(root.Right);

            root.Right = RemoveRec(root.Right, root.Value);
        }

        return root;
    }

    private int MinValue(Node root)
    {
        int minv = root.Value;
        while (root.Left != null)
        {
            minv = root.Left.Value;
            root = root.Left;
        }
        return minv;
    }

    // Method for inorder tree traversal (Inorder: Left, Root, Right)
    public void InOrderTraversal()
    {
        InOrderRec(Root);
    }

    private void InOrderRec(Node root)
    {
        if (root != null)
        {
            InOrderRec(root.Left);
            Console.Write(root.Value + " ");
            InOrderRec(root.Right);
        }
    }
}
