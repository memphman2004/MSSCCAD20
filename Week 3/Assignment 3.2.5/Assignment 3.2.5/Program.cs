using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(Search(new[] { 1, 5, 3 }, 5)); // 1
        Console.WriteLine(Search(new[] { 9, 8, 3 }, 3)); // 2
        Console.WriteLine(Search(new[] { 1, 2, 3 }, 4)); // -1

        // Built-in alternative:
        Console.WriteLine(SearchBuiltIn(new[] { 1, 5, 3 }, 5)); // 1
    }

    // Manual linear search
    public static int Search(int[] arr, int item)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == item)
                return i;
        return -1;
    }

    // Using the Base Class Library (BCL) helper
    public static int SearchBuiltIn(int[] arr, int item) => // SearchBuiltIn is a wrapper that uses the built-in .NET 
                                                           // function to find an item in an array.
     Array.IndexOf(arr, item);
}

// search vs searchbuiltIn
// search is a manual implementation of a linear search algorithm, 
// while searchBuiltIn uses the built-in Array.IndexOf method provided by the .NET framework.