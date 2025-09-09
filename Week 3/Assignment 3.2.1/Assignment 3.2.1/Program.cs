using System;

class Program
{
    static void Main()
    {
        // Example 2D array (2 rows x 3 columns)
        int[,] matrix = {
            { 2,  3,  4 },
            { 1,  4,  6 }
        };

        PrintMatrix(matrix);
    }

    // Prints a 2D array in matrix format with aligned columns:
    // |  2 |  3 |  4 |
    // |  1 |  4 |  6 |
    static void PrintMatrix(int[,] m)
    {
        int rows = m.GetLength(0);
        int cols = m.GetLength(1);

        // Find the widest number (in characters) to align columns
        int width = 0;
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                width = Math.Max(width, m[r, c].ToString().Length);

        // Print each row with vertical bars and padded values
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                // Right-align each value to the computed width
                Console.Write($"| {m[r, c].ToString().PadLeft(width)} ");
            }
            Console.WriteLine("|");
        }
    }
}
