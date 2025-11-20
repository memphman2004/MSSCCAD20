using System;
using System.Collections.Generic;

namespace RemoveDuplicatesInString
{
    class Program
    {
        // Function to remove adjacent duplicates
        static string RemoveDuplicates(string s)
        {
            // We'll use a stack to keep track of the letters
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                // If the stack is not empty and the top is equal to current char, pop it (remove duplicate)
                if (stack.Count > 0 && stack.Peek() == c)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            // Now build the string from the stack (reverse order)
            char[] result = new char[stack.Count];
            int i = stack.Count - 1;
            foreach (char c in stack)
            {
                result[i--] = c;
            }
            return new string(result);
        }

        static void Main(string[] args)
        {
            // Example 1
            string input1 = "abbaca";
            Console.WriteLine($"Input: s = \"{input1}\"");
            string output1 = RemoveDuplicates(input1);
            Console.WriteLine($"Output: \"{output1}\"");
            // Should print "ca"

            // Example 2
            string input2 = "azxxzy";
            Console.WriteLine($"\nInput: s = \"{input2}\"");
            string output2 = RemoveDuplicates(input2);
            Console.WriteLine($"Output: \"{output2}\"");
            // Should print "ay"

            // You can test your own examples here
            Console.WriteLine("\nType your own string and press Enter:");
            string input3 = Console.ReadLine();
            string output3 = RemoveDuplicates(input3);
            Console.WriteLine($"Output: \"{output3}\"");

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
