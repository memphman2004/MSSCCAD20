using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

class Program
{
    // Fixed 6 subjects
    static readonly string[] Subjects = { "English", "Math", "Science", "Literature", "Recess", "Lunch" };

    static void Main()
    {
        // Save file in the *project* folder (same place as the .cs files during Debug) =====
        // AppContext.BaseDirectory → bin/Debug/netX/
        // Go up three folders to reach the project folder.
        string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string filePath = Path.Combine(projectDir, "grades.txt");
        // File.AppendAllText(filePath, line + Environment.NewLine); writes beside the code.

        // Prompt for grader ID first
        int graderId = ReadInt("Enter YOUR (grader) ID: ", 1);

        var students = new List<StudentRecord>();

        while (true)
        {
            // Enter one student record
            Console.Write("\n Enter Student Information ");
            var s = new StudentRecord // Create a new instance of StudentRecord for each student 
            // "s" is a local variable that represents the StudentRecord object passed in when you call the method
            {
                GraderId = graderId,
                StudentId = ReadInt("Student ID: ", 1),
                First = ReadNonEmpty("First name: "),
                Last = ReadNonEmpty("Last  name: "),
                DOB = ReadDate("DOB (MM/dd/yyyy): ", "MM/dd/yyyy"),
                Grades = new int[Subjects.Length] // allocate array for 6 subjects chose this because
                                                 //  If the subjects list changes at anytime (e.g., add/remove a subject), the grades 
                                                 // array will automatically be created with the matching size.
            };

            Console.Write("\nEnter grades (1–100):");
            for (int i = 0; i < Subjects.Length; i++)
                s.Grades[i] = ReadInt($"  {Subjects[i]}: ", 1, 100);

            // Average + GPA (simple scale: avg% of 4.0; clamp to [0..4])
            int sum = 0; foreach (var g in s.Grades) sum += g;
            s.Average = sum / (double)Subjects.Length;
            s.GPA = Math.Clamp(Math.Round((s.Average / 100.0) * 4.0, 2), 0.0, 4.0);// Math.Clamp is used her because we need to ensure that 
                                                                                  // the GPA value remains within the valid range of 0.0 to 4.0.
                                                                                // This prevents any potential issues if the average calculation 
                                                                                // somehow exceeds these bounds.

            // Class rank + percentile (out of 250), based on rule: top person gets 100% & 4.0
            const int classSize = 250;

            // Percentile scales linearly with GPA: 4.0 → 100%, 0.0 → 0%
            s.Percentile = Math.Round((s.GPA / 4.0) * 100.0, 1);

            // Rank 1 is top. Map GPA to rank: 4.0 → 1, 0.0 → 250.
            s.Rank = classSize - (int)Math.Round((s.GPA / 4.0) * (classSize - 1));
            if (s.Rank < 1) s.Rank = 1; if (s.Rank > classSize) s.Rank = classSize;

            // Append to grades.txt (creates if missing)
            File.AppendAllText(filePath, BuildReportBlock(s));
            Console.WriteLine($"\nSaved to: {filePath}");

            students.Add(s);
            PrintSessionSummary(students, filePath);

            // End menu; repeat or exit
            int choice = ReadInt("\nMenu: 1) Add more student  2) Exit  : ", 1, 2);
            if (choice == 2) break;
        }

        Console.WriteLine("\nDone. Press Enter to exit...");
        Console.ReadLine();
    }

    // Display the user inputs
    static void PrintSessionSummary(List<StudentRecord> students, string filePath)
    {
        Console.WriteLine("\n SUMMARY OF ALL STUDENTS ENTERED THIS SESSION ");
        Console.WriteLine($"Saved file: {filePath}\n");

        foreach (var s in students) // Loop through each student in the list since we are able to input more than 1 student
        {
            Console.WriteLine(new string('-', 48));
            Console.WriteLine($"Student ID : {s.StudentId}");
            Console.WriteLine($"Name       : {s.First} {s.Last}");
            Console.WriteLine($"DOB        : {s.DOB:MM/dd/yyyy}");
            Console.WriteLine("\nSubjects (Numeric → Letter):");
            
            for (int i = 0; i < Subjects.Length; i++) // Loop through each subject to print the corresponding grade and letter
            Console.WriteLine($"  {Subjects[i],-12} {s.Grades[i],3}  →  {LetterFromNumeric(s.Grades[i])}");
            Console.WriteLine($"\nAverage (%) : {s.Average:F2}");
            Console.WriteLine($"GPA (0–4.0) : {s.GPA:F2}");
            Console.WriteLine($"Class Rank  : {s.Rank} out of 250");
            Console.WriteLine($"Percentile  : {s.Percentile:F1}%");
        }
    }

    // Text block for file
    static string BuildReportBlock(StudentRecord s) // BuildReportBlock takes a StudentRecord object as a parameter and 
    // constructs a formatted string that represents the student's report block. BuildReportBlock would be our method here
    {
        var sb = new StringBuilder();
        sb.AppendLine(new string('=', 56));
        sb.AppendLine($"Timestamp : {DateTime.Now}");
        sb.AppendLine($"Grader ID : {s.GraderId}");
        sb.AppendLine($"Student ID: {s.StudentId}");
        sb.AppendLine($"Name      : {s.First} {s.Last}");
        sb.AppendLine($"DOB       : {s.DOB:MM/dd/yyyy}");
        sb.AppendLine("Subjects  :");

        for (int i = 0; i < Subjects.Length; i++)
        sb.AppendLine($"  {Subjects[i],-12} {s.Grades[i],3}  ({LetterFromNumeric(s.Grades[i])})");
        sb.AppendLine($"Average   : {s.Average:F2}%");
        sb.AppendLine($"GPA       : {s.GPA:F2}");
        sb.AppendLine($"Rank      : {s.Rank} / 250");
        sb.AppendLine($"Percentile: {s.Percentile:F1}%");
        return sb.ToString();
    }

    // Helpers - reusable functions that do one simple job—so the same code is not repeated everywhere
    static string LetterFromNumeric(int g)
    {
        if (g >= 90) return "A";
        if (g >= 80) return "B";
        if (g >= 70) return "C";
        if (g >= 60) return "D";
        return "F"; // anything 59 and below
    }

    static string ReadNonEmpty(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
            Console.WriteLine("  Please enter something.");
        }
    }
    static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            if (int.TryParse(Console.ReadLine(), out int v) && v >= min && v <= max) return v;
            Console.WriteLine($"  Enter a whole number{(min != int.MinValue || max != int.MaxValue ? $" between {min} and {max}" : "")}.");
        }
    }
    static DateTime ReadDate(string prompt, string format)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                return dt;
            Console.WriteLine($"  Use format {format} (e.g., 09/03/2025).");
        }
    }

    // Data Model/Student Record class
    class StudentRecord
    {
        public int GraderId { get; set; }
        public int StudentId { get; set; }
        public string First { get; set; } = "";
        public string Last { get; set; } = "";
        public DateTime DOB { get; set; }
        public int[] Grades { get; set; } = Array.Empty<int>();//returns a shared, zero-length int[]; No null and so it loops like foreach 
                                                            // will work without null checks
        public double Average { get; set; }
        public double GPA { get; set; }
        public double Percentile { get; set; }
        public int Rank { get; set; }
    }
}


/* Difference between 
TryParse
Converts a string into a value type (like int, double, DateTime, decimal, etc.) using general parsing rules.
It accepts a variety of valid formats depending on the type and the current culture.

TryParseExact
Converts a string into a value type but requires it to exactly match a specified format (usually for DateTime or TimeSpan).
Much stricter than TryParse. If the string doesn’t match the given format(s), parsing fails.
*/