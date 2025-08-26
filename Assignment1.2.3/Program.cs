// Assignment 1.2.3

        // Have the calculator run over and over until the user chooses Exit
        // while(true) creates an endless loop that will break (exit) if/when the user picks 5
        while (true)
        {
            // Start menu
            Console.WriteLine("=== Calculator ===");
            Console.WriteLine("1) Addition");        // add two numbers
            Console.WriteLine("2) Subtraction");     // subtract second from first
            Console.WriteLine("3) Multiplication");  // multiply two numbers
            Console.WriteLine("4) Division");        // divide first by second
            Console.WriteLine("5) Exit");            // leave the program
            Console.Write("Choose (1-5): ");

            // Read the user's input as text, then convert it to an integer (1..5).
            // if the user types letters instead of numbers, this will error.
            int choice = Convert.ToInt32(Console.ReadLine());

            // If the user picks 5, "goodbye" will display because the loop was broken
            if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
                break; // exits the while(true) loop
            }

            // Ask for the two numbers we will use for the calculation.
            Console.WriteLine("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine()); // read first number

            Console.WriteLine("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine()); // read second number

            // Based on the user's menu choice, do the right calculation.
            if (choice == 1)
            {
                // Addition: add a and b
                Console.WriteLine("Result: " + (a + b));
            }
            else if (choice == 2)
            {
                // Subtraction: subtract b from a
                Console.WriteLine("Result: " + (a - b));
            }
            else if (choice == 3)
            {
                // Multiplication: multiply a and b
                Console.WriteLine("Result: " + (a * b));
            }
            else if (choice == 4)
            {
                // Division: divide a by b
                // First, make sure we are not dividing by zero (which is not allowed).
                if (b == 0)
                {
                    Console.WriteLine("Cannot divide by zero.");
                }
                else
                {
                    // NOTE: a and b are ints, so this is INTEGER division.
                    // Example: 7 / 2 = 3 (the .5 is dropped).
                    Console.WriteLine("Result: " + (a / b));

                }
            }
            else
            {
                // If the choice was not 1-5, tell the user it's invalid.
                Console.WriteLine("Invalid option.");
            }

            // Prints a blank line to make the next output easier to read.
            Console.WriteLine();
        }
