// TIP CALCULATOR with USER INPUT (Assignments 2.3.2)
// ------------------------------------------------------
// This program:
//  1) Asks for the bill total (money)
//  2) Asks for the tip percent (e.g., 18 for 18%)
//  3) Calculates tip amount and grand total
//  4) Displays results with currency and % formatting
//
// use decimal for money and CultureInfo for proper symbols.

using System;
using System.Globalization;

namespace TipCalculator_Input
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read the bill total as a non-negative decimal number.
            decimal bill = ReadDecimal("Enter bill total (e.g., 42.95): ", min: 0m);

            // Read the tip percent as a non-negative decimal number (allow 0–100+).
            // If you want to cap it at 100, set max: 100m.
            decimal tipPercent = ReadDecimal("Enter tip percent (e.g., 18 for 18%): ", min: 0m);

            // Convert percent (e.g., 18) → rate (0.18)
            decimal tipRate = tipPercent / 100m;

            // Calculate tip and grand total (rounded to cents for display)
            decimal tipAmount = Math.Round(bill * tipRate, 2);
            decimal grandTotal = bill + tipAmount;

            // Use the computer's current culture for $/£/€ and % formatting
            CultureInfo culture = CultureInfo.CurrentCulture;

            Console.WriteLine("\n--- Tip Summary ---");
            Console.WriteLine($"Bill:        {bill.ToString("C", culture)}");     // currency
            Console.WriteLine($"Tip rate:    {tipRate.ToString("P0", culture)}"); // percent, 0 decimals
            Console.WriteLine($"Tip amount:  {tipAmount.ToString("C", culture)}");
            Console.WriteLine($"Grand total: {grandTotal.ToString("C", culture)}");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }

        // -------- Beginner-safe input helper (decimal) --------
        // Keeps asking until user enters a valid decimal in the given range.
        static decimal ReadDecimal(string prompt, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string? s = Console.ReadLine();

                // TryParse: no exceptions if the user mistypes; just returns false.
                if (decimal.TryParse(s,
                                     NumberStyles.Number,
                                     CultureInfo.CurrentCulture,
                                     out decimal value)
                    && value >= min && value <= max)
                {
                    return value;
                }

                // Show a message and loop again.
                string range =
                    (min != decimal.MinValue || max != decimal.MaxValue)
                    ? $" between {min} and {max}"
                    : "";
                Console.WriteLine($"Please enter a valid number{range} (e.g., 12.34).");
            }
        }
    }
}
