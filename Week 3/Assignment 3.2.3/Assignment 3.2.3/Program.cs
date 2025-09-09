using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Circle Area + and - with Operator Overloading ===");

        // Ask the user for two radii (must be non-negative numbers)
        double r1 = ReadNonNegativeDouble("Enter radius for Circle 1: ");
        double r2 = ReadNonNegativeDouble("Enter radius for Circle 2: ");

        // Create circle objects
        var c1 = new Circle(r1);
        var c2 = new Circle(r2);

        // Use overloaded operators:
        //  - '+' returns the SUM of the two areas (double)
        //  - '-' returns the DIFFERENCE of the two areas (double), signed: area(c1) - area(c2)
        double sumArea  = c1 + c2;
        double diffArea = c1 - c2;
        double absDiff  = Math.Abs(diffArea); // often useful to see absolute difference too

        // Show individual areas and results
        Console.WriteLine();
        Console.WriteLine($"Area(Circle 1) = {c1.Area:F4}");
        Console.WriteLine($"Area(Circle 2) = {c2.Area:F4}");
        Console.WriteLine($"Sum of areas (c1 + c2) = {sumArea:F4}");
        Console.WriteLine($"Difference of areas (c1 - c2) = {diffArea:F4}  (absolute: {absDiff:F4})");
    }

    // Helper method: read a non-negative double from the console with validation
    static double ReadNonNegativeDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();

            if (double.TryParse(s, out double value) && value >= 0)
                return value;

            Console.WriteLine("Please enter a non-negative number (e.g., 0, 2.5, 10).");
        }
    }
}

// Circle class that knows how to compute its Area
// and overloads + and - to work on AREAS.
public class Circle
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");
        Radius = radius;
    }

    // Area formula: πr²
    public double Area => Math.PI * Radius * Radius;

    // Operator '+' returns the SUM of the two AREAS
    public static double operator +(Circle a, Circle b)
        => a.Area + b.Area;

    // Operator '-' returns the (signed) DIFFERENCE of the two AREAS: area(a) - area(b)
    public static double operator -(Circle a, Circle b)
        => a.Area - b.Area;
}

