//Assignment 1.3.2 Show ways to create and use arrays.
//Write a console application in C# to explore different ways in which array is declared
// and initialized and explore different properties and methods of Array class.

        Console.WriteLine("Array Declarations & Initializations");

        // Create an int array with a fixed size of 3.
        // New int arrays start with all elements set to 0.
        int[] num1 = new int[3];  // [0, 0, 0]
        Console.WriteLine("num1.Length = " + num1.Length); // Length tells how many items

        // Create an int array with starting values.
        // The size is automatically the number of values in { }.
        int[] num2 = [3, 1, 2];

        // Print num2 using a for loop (arrays are 0-based: first index is 0).
        Console.WriteLine("num2 = ");
        for (int i = 0; i < num2.Length; i++)
        {
            Console.WriteLine(num2[i]);               // write the element
            if (i < num2.Length - 1) Console.Write(", "); // add comma between items
        }
        Console.WriteLine(); // move to the next line

// Another way: explicit 'new' with

int[] num3 = [10, 20, 30];

// Print num3 using a loop.
Console.WriteLine("num3 = ");
for (int i = 0; i < num3.Length; i++)
{
    Console.WriteLine(num3[i]);
    if (i < num3.Length - 1) Console.WriteLine(", ");
}
Console.WriteLine();

// One Array method example: Sort (reorders from smallest to largest).
Array.Sort(num2); // num2 becomes [1, 2, 3]

// Print num2 again to show it changed after sorting.
Console.WriteLine("num2 after Sort = ");
for (int i = 0; i < num2.Length; i++)
{
    Console.WriteLine(num2[i]);
    if (i < num2.Length - 1) Console.WriteLine (", ");
}
Console.WriteLine();

Console.WriteLine("Done.");
    

