// Assignment 1.3.1: Write a program in C# to calculate area of triangle, square and rectangle.
// Write 3 different functions for each shape to take dimensions of figure and display the area.
// You may create menus.

// menu loop so the user can pick an option
while (true)
        {
            Console.WriteLine("Area Calculator");
            Console.WriteLine("1) Triangle");
            Console.WriteLine("2) Square");
            Console.WriteLine("3) Rectangle");
            Console.WriteLine("4) Exit");
            Console.WriteLine("Choose an option (1-4): ");

            string? choice = Console.ReadLine(); 

            if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break; // exit the while loop and end the program
            }

    // Call different methods depending on the user's choice
    // When C# reaches a break keyword (break, return, goto, or throw), it breaks out of the switch block.
    switch (choice)
    {
        case "1":
            AreaOfTriangle();  // asks for base & height
            break;
        case "2":
            AreaOfSquare();    // asks for side length
            break;
        case "3":
            AreaOfRectangle(); // asks for length & width
            break;
        default:
            Console.WriteLine("Invalid option. Please enter 1, 2, 3, or 4.");
            break;
    }
        }
    
    // method to safely read a non-negative number from the user.
    // Type Casting and User Input
    static double ReadNonNegativeDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? text = Console.ReadLine();

        // TryParse converts text to a number without crashing if input is bad.
        // is used here to safely turn the user’s text into a number without crashing
        // If it succeeds, it puts the parsed number into the variable after out (here: value).
        // If it fails(blank text, letters, etc.), it returns false and your code can ask again.
        if (double.TryParse(text, out double value) && value >= 0)
            return value;

            Console.WriteLine("Please enter a valid non-negative number (like 3 or 4.5).");
        }
    }

    // methods with no return value are 'void')
    static void AreaOfTriangle()
    {
        // Formula: 1/2 * base * height
        double b = ReadNonNegativeDouble("Enter base: ");
        double h = ReadNonNegativeDouble("Enter height: ");
        double area = 0.5 * b * h;
        Console.WriteLine($"Area of Triangle = {area}");
    }

    static void AreaOfSquare()
    {
        // Formula: Two sides (side^2)
        double side = ReadNonNegativeDouble("Enter side length: ");
        double area = side * side;
        Console.WriteLine($"Area of Square = {area}");
    }

    static void AreaOfRectangle()
    {
        // Formula: length * width
        double length = ReadNonNegativeDouble("Enter length: ");
        double width = ReadNonNegativeDouble("Enter width: ");
        double area = length * width;
        Console.WriteLine($"Area of Rectangle = {area}");
    }


