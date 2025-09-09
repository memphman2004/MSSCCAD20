// ==========================
// Assignment 3.3.3: Count Spaces
// ==========================
// Goal: Ask the user to type a string, then count how many normal spaces (' ') are in it,
// and print a message like: "Your text" contains X spaces

using System; // Gives access to Console.ReadLine and Console.WriteLine

class Program
{
    static void Main()
    {
        // user types any sentence or phrase
        Console.Write("Please write a sentence (string): ");
        string? userText = Console.ReadLine(); // Could be null if user just presses Enter

        // Make sure we have a valid string to work with
        //    If it's null, treat it as an empty string
        if (userText == null)
        {
            userText = string.Empty;
        }

        // Count the spaces using our function
        int spaceCount = CountSpaces(userText);

        // Show the result in a friendly message
        //    Note: using quotes around the string, and correct singular/plural for "space/spaces"
        Console.WriteLine($"\"{userText}\" contains {spaceCount} {(spaceCount == 1 ? "space" : "spaces")}");
    }

    // This function loops through each character in the text and counts spaces (' ')
    static int CountSpaces(string text)
    {
        int count = 0; // Start at zero spaces
        for (int i = 0; i < text.Length; i++) // Look at each character by index
        {
            if (text[i] == ' ') // If this character is a regular space
            {
                count++; // Increase our counter
            }
        }
        return count; // Return how many spaces we found
    }
}

