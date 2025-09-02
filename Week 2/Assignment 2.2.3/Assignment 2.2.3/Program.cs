// File: Program.cs
// PURPOSE: Ask the user to choose a shape and enter values. Calculate area.
// Concepts: abstract class, inheritance, overriding, polymorphism, input validation.

using System;

// ---------------- Base abstract class ----------------
// "abstract" = you cannot make a plain Shape; you must make a child (Circle/Square).
abstract class Shape
{
    // Simple common properties every shape will have:
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Color { get; set; } = "";

    // Abstract method = no body here; children MUST implement their own area logic.
    public abstract double CalculateArea();
}

// ---------------- Circle ----------------
class Circle : Shape
{
    public double Radius { get; set; } // specific to circles

    // Area formula: π * r^2
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// ---------------- Square ----------------
class Square : Shape
{
    public double Side { get; set; } // specific to squares

    // Area formula: side * side
    public override double CalculateArea()
    {
        return Side * Side;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Shape Area Calculator ===");
        Console.WriteLine("Choose a shape:");
        Console.WriteLine("1) Circle");
        Console.WriteLine("2) Square");
        Console.Write("Enter 1 or 2: ");
        string? choice = Console.ReadLine();

        // Read the shared (base) properties once
        int id = ReadInt("Enter shape Id (whole number): ");
        string name = ReadNonEmpty("Enter shape Name: ");
        string color = ReadNonEmpty("Enter shape Color: ");

        // We'll store the created object in a Shape variable (polymorphism)
        Shape shape;

        switch (choice)
        {
            case "1":
                // Build a Circle object and set its properties
                var circle = new Circle();
                circle.Id = id;
                circle.Name = name;
                circle.Color = color;
                circle.Radius = ReadDouble("Enter radius (e.g., 3.5): ", min: 0);
                shape = circle; // store as base type
                break;

            case "2":
                // Build a Square object and set its properties
                var square = new Square();
                square.Id = id;
                square.Name = name;
                square.Color = color;
                square.Side = ReadDouble("Enter side length (e.g., 4): ", min: 0);
                shape = square; // store as base type
                break;

            default:
                Console.WriteLine("Invalid choice. Exiting.");
                return;
        }

        // This calls the correct override based on the real object type.
        double area = shape.CalculateArea();

        Console.WriteLine("\n--- Result ---");
        Console.WriteLine($"Id:    {shape.Id}");
        Console.WriteLine($"Name:  {shape.Name}");
        Console.WriteLine($"Color: {shape.Color}");
        Console.WriteLine($"Area:  {area:F2}"); // F2 = show 2 decimal places

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }

    // -------- Input helpers: loop until valid --------

    static string ReadNonEmpty(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
            Console.WriteLine("Please enter some text.");
        }
    }

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

    static double ReadDouble(string prompt, double min = double.NegativeInfinity, double max = double.PositiveInfinity)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();
            if (double.TryParse(s, out double value))
            {
                if (value < min) { Console.WriteLine($"Please enter >= {min}."); continue; }
                if (value > max) { Console.WriteLine($"Please enter <= {max}."); continue; }
                return value;
            }
            Console.WriteLine("Please enter a number (e.g., 3.5).");
        }
    }
}

