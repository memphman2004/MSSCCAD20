using System;
using System.Collections.Generic;

namespace Assignment4_3_3
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Input the number of elements to be stored in the array :");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
            {
                Console.WriteLine("Invalid size.");
                return;
            }

            int[] arr = new int[n];
            Console.WriteLine($"Input {n} elements in the array :");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"element - {i} : ");
                while (!int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    Console.Write("Please enter a valid integer: ");
                }
            }

            var freq = new Dictionary<int, int>();
            foreach (var x in arr)
            {
                freq[x] = freq.TryGetValue(x, out int c) ? c + 1 : 1;
            }

            Console.WriteLine("The unique elements found in the array are :");
            bool any = false;
            var seen = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int x = arr[i];
                if (freq[x] == 1 && seen.Add(x))
                {
                    Console.WriteLine(x);
                    any = true;
                }
            }

            if (!any) Console.WriteLine("(none)");
        }
    }
}
