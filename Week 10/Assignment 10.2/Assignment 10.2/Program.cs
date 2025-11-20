using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExamples
{
    // Simple Employee class for Question 2
    class Employee
    {
        public string Name { get; set; }   // Employee name
        public int Age { get; set; }       // Employee age
        public decimal Salary { get; set; } // Employee salary
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Call each question one by one
            Question1_PositiveNumbers();
            Question2_EmployeesFilter();
            Question3_CityStartsAndEndsWith();
            Question4_NumbersGreaterThan80();

            Console.WriteLine();
            Console.WriteLine("All questions are done. Press any key to exit.");
            Console.ReadKey();
        }

        // ---------------------------------------------------------------------
        // 1. Find positive numbers using LINQ where
        // Input: { 2, -1, 3, -3, 10, -200 }
        // Expected output: { 2, 3, 10 }
        // ---------------------------------------------------------------------
        static void Question1_PositiveNumbers()
        {
            Console.WriteLine("=== Question 1: Positive Numbers with LINQ ===");

            int[] numbers = { 2, -1, 3, -3, 10, -200 };

            // LINQ query to select only positive numbers (greater than 0)
            var positiveNumbers =
                from n in numbers
                where n > 0
                select n;

            Console.Write("Input numbers: { ");
            Console.Write(string.Join(", ", numbers));
            Console.WriteLine(" }");

            Console.Write("Positive numbers: { ");
            Console.Write(string.Join(", ", positiveNumbers));
            Console.WriteLine(" }");

            Console.WriteLine(); // blank line for spacing
        }

        // ---------------------------------------------------------------------
        // 2. Create a list of employees and show those with:
        //    salary > 5000 and age < 30
        // ---------------------------------------------------------------------
        static void Question2_EmployeesFilter()
        {
            Console.WriteLine("=== Question 2: Employees with Salary > 5000 and Age < 30 ===");

            // Hard-coded list of employees
            List<Employee> employees = new List<Employee>()
            {
                new Employee { Name = "John",  Age = 25, Salary = 6000 },
                new Employee { Name = "Sara",  Age = 32, Salary = 7000 },
                new Employee { Name = "Mike",  Age = 28, Salary = 4500 },
                new Employee { Name = "Anna",  Age = 27, Salary = 5200 },
                new Employee { Name = "David", Age = 30, Salary = 8000 }
            };

            // LINQ query: salary greater than 5000 AND age less than 30
            var filteredEmployees =
                from emp in employees
                where emp.Salary > 5000 && emp.Age < 30
                select emp;

            Console.WriteLine("Employees with salary more than $5000 and age < 30:");
            foreach (Employee emp in filteredEmployees)
            {
                Console.WriteLine("Name: " + emp.Name +
                                  ", Age: " + emp.Age +
                                  ", Salary: " + emp.Salary);
            }

            Console.WriteLine(); // blank line for spacing
        }

        // ---------------------------------------------------------------------
        // 3. Find a string (city) that starts and ends with specific characters
        //
        // Cities:
        // 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH',
        // 'NEW DELHI','AMSTERDAM','ABU DHABI','PARIS'
        //
        // Example:
        // Start: A
        // End:   M
        // Output: AMSTERDAM
        // ---------------------------------------------------------------------
        static void Question3_CityStartsAndEndsWith()
        {
            Console.WriteLine("=== Question 3: City Starts and Ends with Specific Characters ===");

            string[] cities = {
                "ROME","LONDON","NAIROBI","CALIFORNIA",
                "ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI","PARIS"
            };

            Console.WriteLine("The cities are:");
            Console.WriteLine(string.Join(", ", cities));

            Console.Write("Input starting character for the string : ");
            string startInput = Console.ReadLine();
            char startChar = startInput[0];   // get first character

            Console.Write("Input ending character for the string : ");
            string endInput = Console.ReadLine();
            char endChar = endInput[0];

            // LINQ query to find city that starts with startChar and ends with endChar
            var cityQuery =
                from city in cities
                where city.StartsWith(startChar.ToString(), StringComparison.OrdinalIgnoreCase)
                   && city.EndsWith(endChar.ToString(), StringComparison.OrdinalIgnoreCase)
                select city;

            // Take the first match (if any)
            string foundCity = cityQuery.FirstOrDefault();

            if (foundCity != null)
            {
                Console.WriteLine("The city starting with " + startChar +
                                  " and ending with " + endChar +
                                  " is : " + foundCity);
            }
            else
            {
                Console.WriteLine("No city found with those starting and ending characters.");
            }

            Console.WriteLine(); // blank line for spacing
        }

        // ---------------------------------------------------------------------
        // 4. Create a list of numbers and display numbers greater than 80
        //
        // Test Data:
        // 55 200 740 76 230 482 95
        //
        // Expected Output:
        // 200
        // 740
        // 230
        // 482
        // 95
        // ---------------------------------------------------------------------
        static void Question4_NumbersGreaterThan80()
        {
            Console.WriteLine("=== Question 4: Numbers Greater Than 80 ===");

            List<int> numbers = new List<int> { 55, 200, 740, 76, 230, 482, 95 };

            Console.WriteLine("The members of the list are:");
            Console.WriteLine(string.Join(" ", numbers));

            // LINQ query to select numbers greater than 80
            var numbersGreaterThan80 =
                from n in numbers
                where n > 80
                select n;

            Console.WriteLine("The numbers greater than 80 are:");
            foreach (int num in numbersGreaterThan80)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(); // blank line for spacing
        }
    }
}
