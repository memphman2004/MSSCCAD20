using System; // Lets us use Console.ReadLine and Console.WriteLine

class Program
{
    static void Main()
    {
        // Ask the user to type a year.
        Console.Write("Enter a year (e.g., 2004): ");

        // Read what the user typed as a string (it could be null if user just hits Enter).
        string? text = Console.ReadLine();

        // Try to convert the text into an integer (like "2016" -> 2016).
        // int.TryParse returns true if conversion worked, false if it failed.
        if (int.TryParse(text, out int year) && year > 0)
        {
            // Call method to check if the year is a leap year.
            bool isLeap = IfYearIsLeap(year);

            // Print "true" or "false" to match the expected output style.
            Console.WriteLine(isLeap ? "true" : "false");

            Console.WriteLine($"{year} is {(isLeap ? "" : "not ")}a leap year.");
        }
        else
        {
            // If the user didn't type a valid positive whole number, show a helpful message.
            Console.WriteLine("Invalid input. Please enter a positive whole-number year (e.g., 2016).");
        }
    }

    // ================================
    // Method: IfYearIsLeap
    // Input: an integer 'year' (e.g., 2004)
    // Output: true if 'year' is a leap year, otherwise false
    //
    // Leap year rules (Gregorian calendar):
    // 1) If the year is divisible by 400 -> LEAP year (true)
    // 2) Else if the year is divisible by 100 -> NOT a leap year (false)
    // 3) Else if the year is divisible by 4   -> LEAP year (true)
    // 4) Otherwise                           -> NOT a leap year (false)
    //
    // '%' is the modulo operator (remainder). If (year % 4 == 0) means
    // "year divides evenly by 4".
    // ================================
    public static bool IfYearIsLeap(int year)
    {
        // Guard: for this exercise, treat non-positive as not leap.
        if (year <= 0) return false;

        // Rule #1: divisible by 400 -> leap year
        if (year % 400 == 0)
        {
            return true;
        }

        // Rule #2: divisible by 100 (but not by 400) -> NOT a leap year
        if (year % 100 == 0)
        {
            return false;
        }

        // Rule #3: divisible by 4 (but not by 100) -> leap year
        if (year % 4 == 0)
        {
            return true;
        }

        // Rule #4: otherwise, not a leap year
        return false;
    }
}


// shorter more concise version of the same this above

/* using System;

Console.Write("Enter a year: ");
if (int.TryParse(Console.ReadLine(), out var y) && y > 0)
{
    bool leap = (y % 400 == 0) || (y % 4 == 0 && y % 100 != 0);
    Console.WriteLine($"{y} is{(leap ? "" : " not")} a leap year.");
}
else
{
    Console.WriteLine("Invalid year.");
}
*/