using System;

class Program
{
    static void Main()
    {
        // Ask the user for the amount of elements the array will have
        // must be a valid whole number >= 0
        int n = ReadInt("Input the number of elements to be stored in the array : ", min: 0);

        Console.WriteLine($"\nInput {n} elements in the array :");

        // Create an array of size n to store the elements
        int[] arr = new int[n];

        // Read each element from the user and store it
        for (int i = 0; i < n; i++)
        {
            // Example prompt: "element - 0 : "
            arr[i] = ReadInt($"element - {i} : ");
        }

        // Compute the sum of all elements in the array using a for loop.
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
        }

        // Print the result in the exact format from the assignment
        Console.WriteLine($"\nSum of all elements stored in the array is : {sum}");
    }

    // read a whole number (int) with optional minimum value.
    // keep asking until the user types a valid integer (>= 0).
    static int ReadInt(string prompt, int min = int.MinValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string? text = Console.ReadLine();

            if (int.TryParse(text, out int value) && value >= min)
            {
                return value; // success: return the parsed number
            }

            // If we get here, the input was invalid; explain and loop again.
            if (min == int.MinValue)
                Console.WriteLine("Please enter a valid whole number (e.g., 2).");
            else
                Console.WriteLine($"Please enter a valid whole number (>= {min}).");
        }
    }
}

