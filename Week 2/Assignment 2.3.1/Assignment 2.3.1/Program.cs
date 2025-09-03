// Program.cs
// This console app demonstrates simple file operations in C#.
// It does three things:
//  1) Prompts for user info and APPENDS it to a text file (users.txt)
//  2) Reads and prints everything in the file
//  3) Exits
//
// ---------------- APPEND EXPLAINED ----------------
// We use File.AppendAllText(filePath, text).
//  - If the file exists: it ADDS the text at the END (does NOT erase).
//  - If the file does not exist: it CREATES the file and then writes.
// If we used File.WriteAllText instead, it would OVERWRITE the whole file.
// --------------------------------------------------

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "users.txt";  // The file where we save data
        char delimiter = '$';           // We separate fields using a simple character. can be whatever you want / > < | , etc.

        while (true)
        {
            // Simple menu
            Console.WriteLine("User File Demo");
            Console.WriteLine("1) Add user (append to file)");
            Console.WriteLine("2) List users (read file)");
            Console.WriteLine("3) Exit");
            Console.WriteLine("Choose 1, 2, or 3: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // --- user input ---
                Console.WriteLine("userId: ");
                string userId = Console.ReadLine();

                Console.WriteLine("firstName: ");
                string firstName = Console.ReadLine();

                Console.WriteLine("lastName: ");
                string lastName = Console.ReadLine();

                Console.WriteLine("age: ");
                string age = Console.ReadLine(); // keeping as string instead on int to stay simple

                Console.WriteLine("address: ");
                string address = Console.ReadLine();

                // Build one line of text with a delimiter so we can split later.
                // Example line: u001|Rickey|Bobby|36|123 Main St
                string line = $"{userId}{delimiter}{firstName}{delimiter}{lastName}{delimiter}{age}{delimiter}{address}";

                // ---- THE APPEND STEP ----
                // Adds 'line' + newline to the END of users.txt (will create it if missing)
                File.AppendAllText(filePath, line + Environment.NewLine);

                Console.WriteLine("Saved (appended)!\n");
            }
            else if (choice == "2")
            {
                // --- Read and print out the file contents ---
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No file yet. Add a user first.\n");
                    continue;
                }

                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    Console.WriteLine("File is empty.\n");
                    continue;
                }

                Console.WriteLine("\n--- Users ---");
                foreach (string l in lines)
                {
                    if (string.IsNullOrWhiteSpace(l)) continue;

                    // split the line back into fields.
                    string[] parts = l.Split(delimiter);

                    // If it looks like 5 (or the number of inputs the user was asked for) parts, print nicely; otherwise print the raw line.
                    if (parts.Length == 5)
                    {
                        Console.WriteLine(
                            $"userId: {parts[0]}, firstName: {parts[1]}, lastName: {parts[2]}, age: {parts[3]}, address: {parts[4]}");
                    }
                    else
                    {
                        Console.WriteLine(l);
                    }
                }
                Console.WriteLine("-------------\n");
            }
            else if (choice == "3")
            {
                // Exit the program
                Console.WriteLine("Goodbye!");
                return;
            }
            else
            {
                Console.WriteLine("Please choose 1, 2, or 3.\n");
            }
        }
    }
}


/* using method extraction approach to clean up Main

using System;
using System.IO;

class Program
{
    // every method can use these
    private const string FilePath = "users.txt";
    private const char Delimiter = '|';

    // Entry point now just calls a method that runs the whole app loop.
    static void Main() => RunMenuLoop();

    // Runs the main menu until the user exits.
    static void RunMenuLoop()
    {
        while (true)
        {
            ShowMenu();
            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1":
                    AddUser();      // collect input + APPEND to file
                    break;
                case "2":
                    ListUsers();    // read file + print
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;         // exit Main
                default:
                    Console.WriteLine("Please choose 1, 2, or 3.\n");
                    break;
            }
        }
    }

    // Prints the menu text aking the user to add to list or view list
    static void ShowMenu()
    {
        Console.WriteLine("==== User File Demo ====");
        Console.WriteLine("1) Add user (append to file)");
        Console.WriteLine("2) List users (read file)");
        Console.WriteLine("3) Exit");
        Console.Write("Choose 1, 2, or 3: ");
    }

    // Collects user info and APPENDS one line to users.txt
    static void AddUser()
    {
        Console.Write("userId: ");
        string userId = Console.ReadLine() ?? "";

        Console.Write("firstName: ");
        string firstName = Console.ReadLine() ?? "";

        Console.Write("lastName: ");
        string lastName = Console.ReadLine() ?? "";

        Console.Write("age: ");
        string age = Console.ReadLine() ?? "";  // keeping it simple as a string

        Console.Write("address: ");
        string address = Console.ReadLine() ?? "";

        // Build a single delimited line we can split later.
        string line = $"{userId}{Delimiter}{firstName}{Delimiter}{lastName}{Delimiter}{age}{Delimiter}{address}";

        // ===================== APPEND (important) =====================
        // File.AppendAllText:
        // - If the file exists, it ADDS this line at the END (does NOT erase).
        // - If the file does not exist, it CREATES it, then writes the line.
        // Contrast: File.WriteAllText would overwrite the whole file.
        File.AppendAllText(FilePath, line + Environment.NewLine);
        // =============================================================

        Console.WriteLine("Saved (appended)!\n");
    }

    // Reads users.txt and prints each saved row (if present).
    static void ListUsers()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("No file yet. Add a user first.\n");
            return;
        }

        string[] lines = File.ReadAllLines(FilePath);

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.\n");
            return;
        }

        Console.WriteLine("\n--- Users ---");
        foreach (string l in lines)
        {
            if (string.IsNullOrWhiteSpace(l)) continue;

            string[] parts = l.Split(Delimiter);

            if (parts.Length == 5)
            {
                Console.WriteLine(
                    $"userId: {parts[0]}, firstName: {parts[1]}, lastName: {parts[2]}, age: {parts[3]}, address: {parts[4]}");
            }
            else
            {
              
                Console.WriteLine(l);
            }
        }
        Console.WriteLine("-------------\n");
    }
}
*/