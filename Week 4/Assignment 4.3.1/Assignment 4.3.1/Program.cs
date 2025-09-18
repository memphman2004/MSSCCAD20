using System;

namespace Assignment4_3_1
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Input:");
            Console.Write("Customer IDNO : ");
            string? id = Console.ReadLine();

            Console.Write("Customer Name : ");
            string? name = Console.ReadLine();

            Console.Write("unit Consumed : ");
            if (!int.TryParse(Console.ReadLine(), out int units) || units < 0)
            {
                Console.WriteLine("Invalid units.");
                return;
            }

            decimal rate = GetRate(units);
            decimal amount = units * rate;
            decimal surcharge = amount > 400m ? amount * 0.15m : 0m;
            decimal net = amount + surcharge;

            Console.WriteLine();
            Console.WriteLine($"Customer IDNO :{id}");
            Console.WriteLine($"Customer Name :{name}");
            Console.WriteLine($"unit Consumed :{units}");
            Console.WriteLine($"Amount Charges @$ {rate:0.00} per unit : {amount:0.00}");
            Console.WriteLine($"Surcharge Amount : {surcharge:0.00}");
            Console.WriteLine($"Net Amount Paid By the Customer : {net:0.00}");
        }

        private static decimal GetRate(int units)
        {
            if (units <= 199) return 1.20m;
            if (units < 400)  return 1.50m; // 200–399
            if (units < 600)  return 1.80m; // 400–599
            return 2.00m;                    // 600+
        }
    }
}
