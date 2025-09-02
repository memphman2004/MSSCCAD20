
// PURPOSE: Demonstrate METHOD OVERLOADING with a simple menu.
// NOTE: We name the class "FunNumbers" (NOT "Math") to 
//avoid clashing with System.Math.

using System;

public static class FunNumbers
{
    // Overload #1: Add two INTS
    public static int Add(int a, int b)
    {
        // returns the sum as an int
        return a + b;
    }

    // Overload #2: Add three DECIMALS
    public static decimal Add(decimal a, decimal b, decimal c)
    {
        // decimal is good for precise decimal math
        return a + b + c;
    }

    // Overload #3: Multiply two FLOATS
    public static float Multiply(float x, float y)
    {
        return x * y;
    }

    // Overload #4: Multiply three FLOATS
    public static float Multiply(float x, float y, float z)
    {
        return x * y * z;
    }
}

class Program
{
    static void Main()
    {
        // Endless (sort of) menu; we 'return' to exit.
        while (true)
        {
            Console.WriteLine("\n=== Overloading Demo ===");
            Console.WriteLine("1) Add two INTs");
            Console.WriteLine("2) Add three DECIMALs");
            Console.WriteLine("3) Multiply two FLOATs");
            Console.WriteLine("4) Multiply three FLOATs");
            Console.WriteLine("5) Exit");
            Console.Write("Choose 1-5: ");
            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    {
                        // Calls Add(int,int)
                        int a = ReadInt("Enter first int: ");
                        int b = ReadInt("Enter second int: ");
                        int result = FunNumbers.Add(a, b);
                        Console.WriteLine($"Result: {a} + {b} = {result} (int)");
                        break;
                    }
                case "2":
                    {
                        // Calls Add(decimal,decimal,decimal)
                        decimal x = ReadDecimal("Enter first decimal (e.g., 12.5): ");
                        decimal y = ReadDecimal("Enter second decimal: ");
                        decimal z = ReadDecimal("Enter third decimal: ");
                        decimal result = FunNumbers.Add(x, y, z);
                        Console.WriteLine($"Result: {x} + {y} + {z} = {result} (decimal)");
                        break;
                    }
                case "3":
                    {
                        // Calls Multiply(float,float)
                        float x = ReadFloat("Enter first float (e.g., 3.14): ");
                        float y = ReadFloat("Enter second float: ");
                        float result = FunNumbers.Multiply(x, y);
                        Console.WriteLine($"Result: {x} * {y} = {result} (float)");
                        break;
                    }
                case "4":
                    {
                        // Calls Multiply(float,float,float)
                        float x = ReadFloat("Enter first float: ");
                        float y = ReadFloat("Enter second float: ");
                        float z = ReadFloat("Enter third float: ");
                        float result = FunNumbers.Multiply(x, y, z);
                        Console.WriteLine($"Result: {x} * {y} * {z} = {result} (float)");
                        break;
                    }
                case "5":
                    Console.WriteLine("Goodbye!");
                    return; // end program
                default:
                    Console.WriteLine("Please choose a valid option (1-5).");
                    break;
            }
        }
    }

    // ---- Input helpers (loop until valid) ----
    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();
            if (int.TryParse(s, out int value)) return value;
            Console.WriteLine("Please enter a whole number (e.g., 12).");
        }
    }

    static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();
            if (decimal.TryParse(s, out decimal value)) return value;
            Console.WriteLine("Please enter a decimal number (e.g., 12.5).");
        }
    }

    static float ReadFloat(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();
            if (float.TryParse(s, out float value)) return value;
            Console.WriteLine("Please enter a floating-point number (e.g., 3.14).");
        }
    }
}
