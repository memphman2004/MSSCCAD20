using System;

class Program
{
    static void Main()
    {
        // Read size of the square matrix (must be 1..4)
        int n = ReadSize("Input the size of the square matrix (less than 5): ");

        // Read both matrices from user
        int[,] first  = new int[n, n];
        int[,] second = new int[n, n];

        Console.WriteLine("\nInput elements in the first matrix :");
        ReadMatrix(first);

        Console.WriteLine("\nInput elements in the second matrix :");
        ReadMatrix(second);

        // Compute sum: C = A + B
        int[,] sum = AddMatrices(first, second);

        // Print results in the requested format
        Console.WriteLine("\nThe First matrix is:");
        PrintMatrix(first);

        Console.WriteLine("\nThe Second matrix is :");
        PrintMatrix(second);

        Console.WriteLine("\nThe Addition of two matrix is :");
        PrintMatrix(sum);
    }

    // Reads a valid size 1..4
    static int ReadSize(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0 && n < 5)
                return n;
            Console.WriteLine("Please enter a whole number between 1 and 4.");
        }
    }

    // Reads elements into the given matrix with prompts like: element - [i],[j] : value
    static void ReadMatrix(int[,] m)
    {
        int rows = m.GetLength(0), cols = m.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                while (true)
                {
                    Console.Write($"element - [{i}],[{j}] : ");
                    if (int.TryParse(Console.ReadLine(), out int val))
                    {
                        m[i, j] = val;
                        break;
                    }
                    Console.WriteLine("Please enter a valid integer.");
                }
            }
        }
    }

    // Adds two same-sized matrices
    static int[,] AddMatrices(int[,] a, int[,] b)
    {
        int n = a.GetLength(0), m = a.GetLength(1);
        int[,] c = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                c[i, j] = a[i, j] + b[i, j];
        return c;
    }

    // Prints a matrix with numbers separated by a single space per row
    static void PrintMatrix(int[,] m)
    {
        int rows = m.GetLength(0), cols = m.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (j > 0) Console.Write(" ");
                Console.Write(m[i, j]);
            }
            Console.WriteLine();
        }
    }
}

