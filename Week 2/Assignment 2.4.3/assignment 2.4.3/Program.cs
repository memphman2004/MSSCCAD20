// Quadrant Finder (no else-if version)
// ------------------------------------
// This beginner-friendly program asks for an (x, y) point and reports where it lies:
// - Origin (0,0)
// - On X-axis or Y-axis
// - First, Second, Third, or Fourth quadrant
//
// Important: We avoid "else if" by using early returns in a helper method.
// That makes each condition stand alone and easy to read.

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Quadrant Finder");

        // Read X and Y as integers (whole numbers).
        // We loop until the user types valid numbers.
        int x = ReadInt("Input the value for X coordinate : ");
        int y = ReadInt("Input the value for Y coordinate : ");

        // Determine where the point lies using a helper method.
        // This method uses only 'if' statements and early 'return'.
        string location = DescribePointLocation(x, y);

        // Print result in the requested style.
        Console.WriteLine($"\nThe coordinate point ({x},{y}) lies in the {location}.");
    }

    // Reads an integer from the console safely.
    // Keeps asking until the user enters something like -10, 0, 42, etc.
    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? text = Console.ReadLine();

            // int.TryParse returns true if conversion succeeds (no crash on bad input).
            if (int.TryParse(text, out int value))
            {
                return value; // success, return the parsed number
            }

            // If we see this displayed, the input was not a whole number.
            Console.WriteLine("Please enter a whole number (e.g., -3, 0, 7). Try again.\n");
        }
    }

    // Determine the location of a point (x, y) with early returns and plain 'if' statements.
    // Order does matters: handle edge cases first, then the normal quadrants.
    static string DescribePointLocation(int x, int y)
    {
        // Edge Case 1: Exactly at the origin (0,0)
        if (x == 0 && y == 0)
        {
            // We return immediately; no else/else-if needed.
            return "Origin";
        }

        // Edge Case 2: On one of the axes
        // If x is 0 (but y is not), the point lies on the Y-axis (vertical line).
        if (x == 0)
        {
            return "Y-axis";
        }

        // If y is 0 (but x is not), the point lies on the X-axis (horizontal line).
        if (y == 0)
        {
            return "X-axis";
        }

        // From here on, we know x != 0 AND y != 0.
        // So the point must be in exactly one of the four quadrants.

        // --- First quadrant: x > 0 and y > 0 ---
        if (x > 0 && y > 0)
        {
            return "First quadrant";
        }

        // --- Second quadrant: x < 0 and y > 0 ---
        if (x < 0 && y > 0)
        {
            return "Second quadrant";
        }

        // --- Third quadrant: x < 0 and y < 0 ---
        if (x < 0 && y < 0)
        {
            return "Third quadrant";
        }

        // --- Fourth quadrant: the only remaining case is x > 0 && y < 0 ---
        // We could check it explicitly, but since all other cases returned above,
        // reaching this line means it's definitely the Fourth quadrant.
        return "Fourth quadrant";
    }
}
