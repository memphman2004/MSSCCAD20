using System;

class Program
{
    static void Main()
    {
        // Ask the user for the number
        Console.WriteLine("Enter a number: ");
        string? numberText = Console.ReadLine();

        // Try to convert the text to an integer (e.g., "6" -> 6).
        // If parsing fails, exit with a message.
        if (!int.TryParse(numberText, out int number))
        {
            Console.WriteLine("Please enter a valid whole number (e.g., 6).");
            return;
        }

        // Ask for the starting width (how many times to repeat on the first line)
        Console.WriteLine("Enter the desired width: ");
        string? widthText = Console.ReadLine();

        if (!int.TryParse(widthText, out int width) || width < 1)
        {
            Console.WriteLine("Please enter a whole number >= 1 for the width.");
            return;
        }

        // Turn the number into text once, so it also works for multi-digit numbers (e.g., 12).
        string token = number.ToString();

        // Printing the triangle
        // start from 'width'(input by User) and go down to 1.
        // To match the challenge exactly, print a blank line before each row.
        for (int w = width; w >= 1; w--)
        {
            Console.WriteLine(); // blank line (matches the challenge formatting)

            // Print the token 'w' times on one line
            for (int i = 0; i < w; i++)
            {
                Console.Write(token);
            }

            Console.WriteLine(); // end the line
        }
    }
}

