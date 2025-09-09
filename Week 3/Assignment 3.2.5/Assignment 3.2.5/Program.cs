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

    // Using the BCL helper
    public static int SearchBuiltIn(int[] arr, int item) =>
        Array.IndexOf(arr, item);
}

