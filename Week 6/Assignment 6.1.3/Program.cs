using System;

//
// Move Zeroes
// Read a line of integers
// Move all 0's to the end (in place)
// Keep the order of non-zero numbers


// User prompt
Console.WriteLine("Move Zeroes (In-Place) - Enter a list of integers(numbers).");
Console.Write("Enter integers separated by spaces (e.g., 0 1 0 3 10 0 16): ");

string? line = Console.ReadLine();

// If nothing was entered, stop early.
if (string.IsNullOrWhiteSpace(line))
{
    Console.WriteLine("No input provided.");
    return;
}

// Convert user input text → int[]
string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
int[] nums = new int[parts.Length];

for (int i = 0; i < parts.Length; i++)
{
    // TryParse: prevents crashes on bad input
    if (!int.TryParse(parts[i], out nums[i]))
    {
        Console.WriteLine($"Invalid number: '{parts[i]}'.");
        return;
    }
}

// 1) move from left to right and copy each non-zero to the next open slot (index 'write').
// 2) Fill the remaining slots with 0's.
MoveZeroes(nums);

// Show the result
Console.WriteLine("Output: [" + string.Join(", ", nums) + "]");


static void MoveZeroes(int[] a) // read: look at each item; 
                                // write: tells us where to place next non-zero
{
    int write = 0; // next position to place a non-zero

    // Move all non-zeros forward in the same order
    for (int read = 0; read < a.Length; read++)
    {
        if (a[read] != 0)
        {
            // If the non-zero is already at the right spot, just move on.
            if (read != write)
            {
                a[write] = a[read]; // move non-zero forward
                a[read] = 0;        // leave a zero behind
            }
                    write++;
                }
            }
        }
    
