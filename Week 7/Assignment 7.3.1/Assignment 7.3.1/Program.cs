//You are given the root of a binary search tree (BST) and an integer val.

//Find the node in the BST that the node's value equals val and 
//return the subtree rooted with that node. If such a node does 
//not exist, return null.

using System;

// Classes needed:
// - TreeNode: node with val, left, right
// - BinarySearchTree: Insert, search (returns subtree root), PrintInOrder
// - Program.Main: DEMO section to show usage

public class TreeNode
{
    public int val;            //value stored in this node
    public TreeNode? left;     // Object - left child  (values < val) ? means it can be null
    public TreeNode? right;    //right child (values > val) ? means it can be null

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
//-----------------------------------------------------------------------------//
// Binary Search Tree (BST) class with Insert and search methods
public class BinarySearchTree
{
    public TreeNode? Root;  //top of the tree (null if empty)

    //Insert a value into the BST (ignores duplicates)
    public void Insert(int val)
    {
        if (Root == null) //If tree is empty, create the root node
        {
            Root = new TreeNode(val); 
            return;
        }

        var cur = Root; //Start of root node of the BST
        while (true) //Loop until we either insert or decide to stop
        {
            if (val == cur.val) // If the value already exists at this node
            {                  // do nothing and exit

                return;
            }
            else if (val < cur.val)//If value is smaller than current node's value
            {                      //and there is no left child
                                   //create a new node here and exit
                return;                  
                if (cur.left == null)
                {
                    cur.left = new TreeNode(val);
                    return;
                }
                cur = cur.left;
            }
            else // If the value is larger than the current node's value 
                 // and there is no right child
                 // create a new node here and exit
            {
                if (cur.right == null)
                {
                    cur.right = new TreeNode(val);
                    return;
                }
                cur = cur.right;
            }
        }
    }

    // search(val): return the node whose value == val
    // node is the root of the subtree If not found, returns null.
    
    public TreeNode? search(int val)
    {
        var cur = Root;

        while (cur != null)
        {
            if (val == cur.val) return cur;  // the subtree root is found
            else
            if (val < cur.val) cur = cur.left;// move left if smaller
            else cur = cur.right;  // move right if larger
        }

        return null; // not found
    }

    // Print values from ANY subtree in sorted order
    public static void PrintInOrder(TreeNode? node)
    {
        if (node == null) return;
        PrintInOrder(node.left);
        Console.Write(node.val + " ");
        PrintInOrder(node.right);
    }
}
//-----------------------------------------------------------------------------//
// this is just a demo of how to use the BST class, modify as needed.

public class Program
{
    public static void Main()
    {

        var bst = new BinarySearchTree();

        // Build the BST
        bst.Insert(4);
        bst.Insert(2);
        bst.Insert(7);
        bst.Insert(1);
        bst.Insert(3);

        // Show the whole tree in sorted order
        Console.Write("Full tree (in-order): ");
        BinarySearchTree.PrintInOrder(bst.Root); // Output: 1 2 3 4 7
        Console.WriteLine();

        // Search for 2 and get the subtree rooted at 2 (includes 1 and 3)
        TreeNode? subRoot = bst.search(2);

        if (subRoot != null)
        {
            Console.Write("Subtree rooted at 2 (in-order): ");
            BinarySearchTree.PrintInOrder(subRoot); // Output: 1 2 3
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Value 2 not found.");
        }

        // Try a value that doesn't exist
        var missing = bst.search(5);
        Console.WriteLine(missing is null ? "Value 5 not found." : "Found 5.");
    }
}
