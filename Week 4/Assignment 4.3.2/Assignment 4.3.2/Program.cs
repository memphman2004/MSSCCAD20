using System;

class Program
{
    static void Main()
    {
        // Ask how many numbers the user will enter
        Console.Write("Input the number of elements to be stored in the array : ");
        int n = int.Parse(Console.ReadLine() ?? "0"); // (assumes the user types a valid whole number)

        // Create array to hold the numbers
        int[] numbers = new int[n];

        // Array will read the numbers input by the user, one by one.
        Console.WriteLine($"Input {n} elements in the array :");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"element - {i} : ");
            numbers[i] = int.Parse(Console.ReadLine() ?? "0");
        }

        // print each number only once.
        // visited[i] = true means "we already counted/printed numbers[i]"
        bool[] visited = new bool[n];

        Console.WriteLine("\nFrequency of all elements of array :");

// Nested loops to count occurrences of each number
        // Outer loop: pick a number at position i
        for (int i = 0; i < n; i++)
        {
            // If position was already counted as a duplicate of an earlier number, skip it
            if (visited[i]) continue;

            // Start with a count of 1 for numbers[i]
            int count = 1;

            // Inner loop: compare numbers[i] with the elements after it (i+1 ... n-1)
            for (int j = i + 1; j < n; j++)
            {
                // If we find the same number again, increase the count
                // and mark that j position as visited so we don't print it later
                if (numbers[j] == numbers[i])
                {
                    count++;
                    visited[j] = true;
                }
            }

            // Print the result for this number
            Console.WriteLine($"{numbers[i]} occurs {count} {(count == 1 ? "time" : "times")}");
        }
    }
}
