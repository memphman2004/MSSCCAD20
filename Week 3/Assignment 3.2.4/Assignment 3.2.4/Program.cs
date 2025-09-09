using System;

class Program
{
    static void Main()
    {
        // Ask the user for 4 numbers (you can enter whole numbers or decimals)
        double n1 = ReadNumber("Enter the First number: ");
        double n2 = ReadNumber("Enter the Second number: ");
        double n3 = ReadNumber("Enter the third number: ");
        double n4 = ReadNumber("Enter the fourth number: ");

        // Call our function:
        // - 'params' lets us pass the numbers like regular arguments
        // - 'out' returns both total and average back to Main
        CalcTotalAndAverage(out double total, out double average, n1, n2, n3, n4);

        // Print results (format matches the sample)
        Console.WriteLine($"The average of {n1} , {n2} , {n3} , {n4} is: {average}");
        Console.WriteLine($"The total is {total}");
    }

    // Reads a double from the console with a prompt; keeps asking until valid
    static double ReadNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double value))
                return value;

            Console.WriteLine("Please enter a valid number (e.g., 10 or 18.75).");
        }
    }

    // Calculates total and average.
    // NOTE: 'params' MUST be the last parameter; 'out' returns multiple results.
    static void CalcTotalAndAverage(out double total, out double average, params double[] nums)
    {
        total = 0;
        for (int i = 0; i < nums.Length; i++)
            total += nums[i];

        average = nums.Length > 0 ? total / nums.Length : 0;
    }
}

