using System;        // Lets us use Console.WriteLine (for testing)
using System.Text;   // Gives us access to the StringBuilder class

class Program
{
    // This Main method is just here so you can run and test the code quickly.
    // If you're submitting only the method, you can remove Main and the Program class.
    static void Main()
    {
        string result = ReturnEvenNumbers();
        Console.WriteLine(result);
        // Expected:
        // 2 4 6 8 10 12 14 16 18 20 22 24 26 28 30 32 34 36 38 40 42 44...
    }

    // Write a method that returns a string of even numbers greater than 0 and less than 100.
    // Use StringBuilder to efficiently "build" that string piece by piece.
    public static string ReturnEvenNumbers()
    {
        // StringBuilder is better than repeatedly doing: result = result + "something"
        // because it avoids creating lots of temporary string objects in memory.
        var sb = new StringBuilder();

        // We want even numbers > 0 and < 100.
        // The first positive even number is 2, and the last one under 100 is 98.
        // If we start at 2 and add 2 each time, we will visit all even numbers: 2, 4, 6, ..., 98.
        for (int i = 2; i < 100; i += 2)
        {
            // We need spaces between numbers, but we DON'T want an extra space at the very end.
            // add a space BEFORE each number EXCEPT the first one.
            // We can detect the "first time" by checking if nothing has been added to the StringBuilder yet.
            if (sb.Length > 0)
            {
                sb.Append(' '); // add one space before the next number
            }

            // Now add the actual even number (i) to the StringBuilder.
            sb.Append(i);
        }

        // Convert the StringBuilder into a regular string and return it.
        return sb.ToString();
    }
}

