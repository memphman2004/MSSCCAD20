// =======================================================
//Assignment 3.1.4: Replace First Consecutive 1s with 0s in an Array
// =======================================================
// Goal: Ask the user to enter an array of integers (comma-separated).
// Find the FIRST occurrence of two consecutive 1s (1,1) and change both to 0.
// Example:
//   Input:  0,2,1,1,9,1,1
//   Output: 0,2,0,0,9,1,1

using System; // For Console and basic types

class Program
{
    static void Main()
    {
        // Ask the user for a list of integers separated by commas
        //    Example input: 0,2,1,1,9,1,1  (no brackets needed)
        Console.Write("Enter an array of integers separated by commas (e.g., 0,2,1,1,9,1,1): ");
        string? numbersText = Console.ReadLine(); // Read the user's input

        // Convert that text into an int[] (array of integers)
        //    If parsing fails, show a message and stop the program
        int[]? numbers = TryParseIntArray(numbersText);
        if (numbers == null)
        {
            Console.WriteLine("Invalid input. Please enter numbers separated by commas like: 0,2,1,1,9,1,1");
            return; // Stop here because we can't continue without a valid array
        }

        // Show the original array before changes
        Console.WriteLine($"Original: [{string.Join(",", numbers)}]");

        // Replace the first pair of consecutive 1s with 0s
        ReplaceFirstConsecutiveOnesWithZeros(numbers);

        // Show the result after modification
        Console.WriteLine($"Output:   [{string.Join(",", numbers)}]");
    }

    // This function looks for the FIRST occurrence of two 1s next to each other (1,1).
    // When found, it sets both to 0 and then stops (so only the first pair is changed).
    static void ReplaceFirstConsecutiveOnesWithZeros(int[] arr)
    {
        // We check pairs: arr[i] and arr[i + 1]
        // So we loop up to the second-to-last index (arr.Length - 2 is the last valid i)
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] == 1 && arr[i + 1] == 1)
            {
                // Found the first pair of consecutive 1s
                arr[i] = 0;       // Change the first 1 to 0
                arr[i + 1] = 0;   // Change the second 1 to 0
                break;            // Stop after changing the first pair only
            }
        }
    }

    // Helper function:
    // Tries to parse a comma-separated string of integers into an int[].
    // Returns null if any piece isn't a valid integer.
    static int[]? TryParseIntArray(string? input)
    {
        // If the input is empty or whitespace, we can't parse it
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        // Split on commas, and remove empty entries (e.g., if user typed ",,")
        string[] parts = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

        // Create a result array to hold the parsed integers
        int[] result = new int[parts.Length];

        // Try to parse each piece (like " 2 " -> 2)
        for (int i = 0; i < parts.Length; i++)
        {
            string piece = parts[i].Trim(); // Remove spaces around the number text
            bool ok = int.TryParse(piece, out int number);
            if (!ok)
            {
                // If any number fails to parse, we return null to signal invalid input
                return null;
            }
            result[i] = number; // Save the number into the array
        }

        return result; // All good—return the array of integers
    }
}
