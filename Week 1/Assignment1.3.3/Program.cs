// Assignment 1.3.3 Read N numbers from the user, store in an array,
// then print in reverse.

        // Ask the user how many numbers they would like to input
        Console.WriteLine("Input the number of elements to store in the array :");
        int n = Convert.ToInt32(Console.ReadLine()); // converts the text input to an int

        // Create an int array with size n (so it can hold n numbers).
        int[] arr = new int[n];

        // Prompt to type the numbers one by one.
        Console.WriteLine("Input the " + n + " number elements in the array :");
        for (int i = 0; i < n; i++) // loop from 0 up to n-1
        {
            Console.Write("element - " + i + " : "); // show which index we are filling
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Print the values as they were stored (forward order).
        Console.WriteLine();
        Console.WriteLine("The values store into the array are:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(arr[i]);           // print the number at index i
            if (i < n - 1) Console.WriteLine(" "); // add a space between numbers, but not after the last
        }

        // Print the values in reverse order (from the last index down to 0).
        Console.WriteLine();
        Console.WriteLine("The values store into the array in reverse are :");
        for (int i = n - 1; i >= 0; i--)
        {
            Console.WriteLine(arr[i]);
            if (i > 0) Console.WriteLine(" "); // add a space between numbers, but not before the first
        }


        Console.WriteLine(); // add a blank line at the end