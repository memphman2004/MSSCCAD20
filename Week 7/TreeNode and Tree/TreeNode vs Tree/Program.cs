// A tree is a way to store data that has a hierarchical 
//structure; like a family tree or an organization chart.
//It’s made up of nodes that connect to each other like branches.

//A TreeNode represents one item in the tree.
//Each node can:
// 1. Store data (like a name or number).
// 2. Know who its children are (other TreeNodes under it).
//Think of it like this:
// 1. Each TreeNode is a “box” holding a value and a list of 
//smaller boxes inside it (its children).

using System;
using System.Collections.Generic;

namespace BeginnerTrees
{
    // A single node in our tree.
    // Each node has:
    //  - a Value (string we store)
    //  - a list of Children (other nodes below this one)
    public class TreeNode
    {
        public string Value;                 // what this node stores
        public List<TreeNode> Children;      // nodes under this node

        // Constructor: create a node with a value and an empty children list
        public TreeNode(string value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }

        // Add a child with a value and return the new node (so we can keep building)
        public TreeNode AddChild(string value)
        {
            TreeNode child = new TreeNode(value);
            Children.Add(child);
            return child;
        }

        // Print this node and everything under it (preorder), with indentation
        // level = how deep we are (used for spaces)
        public void Print(int level = 0)
        {
            // create some spaces so deeper nodes are indented
            string indent = new string(' ', level * 2);
            Console.WriteLine(indent + "- " + Value);

            // print all children, one by one, going deeper each time
            foreach (TreeNode child in Children)
            {
                child.Print(level + 1);
            }
        }

        // Find the first node whose Value matches the text (simple depth-first search)
        public TreeNode Find(string text)
        {
            // Check this node first
            if (Value == text)
                return this;

            // Otherwise check each child (and their children)
            foreach (TreeNode child in Children)
            {
                // Also nullable here
                TreeNode? found = child.Find(text);
                if (found is not null)
                    return found;
            }

            // Not found
            return null;
        }

        // Count how many nodes are in this subtree (this node + all descendants)
        public int CountNodes()
        {
            int count = 1; // count myself
            foreach (TreeNode child in Children)
            {
                count += child.CountNodes(); // add each child's count
            }
            return count;
        }

        // Height = number of edges on the longest path from this node down to a leaf.
        // A leaf (no children) has height 0.
        public int Height()
        {
            if (Children.Count == 0)
                return 0;

            int maxChildHeight = 0;
            foreach (TreeNode child in Children)
            {
                int h = child.Height();
                if (h > maxChildHeight)
                    maxChildHeight = h;
            }
            return 1 + maxChildHeight;
        }
    }

    // The Tree just holds the root and gives us easy helper methods.
    public class Tree
    {
        public TreeNode Root;

        public Tree(string rootValue)
        {
            Root = new TreeNode(rootValue);
        }

        public void Print()
        {
            Root.Print();
        }

        public TreeNode Find(string text)
        {
            return Root.Find(text);
        }

        public int CountNodes()
        {
            return Root.CountNodes();
        }

        public int Height()
        {
            return Root.Height();
        }
    }
}
