// A C# program that asks the user for up to 5 numbers,
// stores them in an array, then finds the largest number and its position.
// We do this using loops and if-statements (no LINQ, no Math.Max).

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Largest Value Finder (up to 5 numbers) ===\n");

        // Ask the user how many numbers they want to enter.
        // We only allow 1..5, because the assignment says "not more than 5".
        int n = ReadInt(
            "How many numbers will you enter (1 to 5)? ",
            min: 1,
            max: 5
        );

        // Create an array with exactly 'n' slots.
        // Arrays are zero-based in C#: first element is at index 0.
        int[] numbers = new int[n];

        // Fill the array by asking the user for each number.
        for (int i = 0; i < n; i++)
        {
            // i is 0-based, but humans usually count from 1,
            // so we show i+1 in the prompt with "1st", "2nd", etc.
            numbers[i] = ReadInt($"Input the {Ordinal(i + 1)} number: ");
        }

        // Find the largest value and its index (position)
        // Start by assuming the first element is the largest.
        int maxIndex = 0;           // where the current largest number lives (0-based)
        int maxValue = numbers[0];  // the current largest number we have seen

        // Look through the rest of the array and update when we find something bigger.
        for (int i = 1; i < n; i++)
        {
            // If the number at position i is larger than our current max,
            // remember its index and value.
            if (numbers[i] > maxValue)
            {
                maxValue = numbers[i];
                maxIndex = i;
            }
        }

        // results
        Console.WriteLine("\n=== Result ===");
        Console.WriteLine($"Largest value: {maxValue}");

        // Show both 0-based index (how arrays count) and 1-based position (how people count).
        Console.WriteLine($"Index (0-based): {maxIndex}");
        Console.WriteLine($"Position (1-based): {maxIndex + 1}");

        // Optional message similar to the sample text in assignment prompt:
        Console.WriteLine($"\nThe {Ordinal(maxIndex + 1)} number is the greatest among {n}.");
    }

    // ask the user for an integer until they give a valid one
    // enforce a minimum and/or maximum
    static int ReadInt(string prompt, int? min = null, int? max = null)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            // TryParse safely converts text to an int without crashing on bad input.
            // (This is for input safety; we're not using any helpers to find the max.)
            if (int.TryParse(input, out int value))
            {
                if (min.HasValue && value < min.Value)
                {
                    Console.WriteLine($"Please enter a number >= {min.Value}.\n");
                    continue;
                }
                if (max.HasValue && value > max.Value)
                {
                    Console.WriteLine($"Please enter a number <= {max.Value}.\n");
                    continue;
                }
                return value; // valid number within bounds
            }

            Console.WriteLine("That wasn't a whole number. Try again.\n");
        }
    }

    // Helper method: turn 1,2,3,... into "1st","2nd","3rd","4th",...
    // This is just for nicer prompts and messages.
    static string Ordinal(int n) // e.g. 1 -> "1st"
    {
        int tens = n % 100;
        if (tens >= 11 && tens <= 13) return n + "th";
        switch (n % 10)
        {
            case 1: return n + "st";
            case 2: return n + "nd";
            case 3: return n + "rd";
            default: return n + "th";
        }
    }
}
/* 
HasValue is a property on nullable value types in C# (types written like int?, double?, DateTime?).
It tells you whether the variable currently contains a real value or is null.

Why it exists
Value types (like int) can’t be null. Wrapping them in Nullable<T> (shorthand T?) lets you represent “no value.”
HasValue is just a convenient way to ask: “Is there a value here?”
*/