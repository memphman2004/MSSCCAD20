// Assignment 1.4.2 
//Write a class: “Student” with private data members: StudentId(int), StudentFname(string), StudentLname(string), 
//StudentGrade(char) and public properties for each data member.Instantiate the class and assign data to properties. 
//Display the data back on console.

// A class is a blueprint for objects. It can hide data (private fields)
// and expose it safely through public properties (get/set).
class Student
{
    // Private data members (fields)
    // Only code that is inside the Student class can directly access these.
    private int studentId;
    private string studentFname;
    private string studentLname;
    private char studentGrade;

    // Public properties
    // Code that is outside the class can get/set values using these properties.
    public int StudentId
    {
        get { return studentId; }
        set { studentId = value; }
    }

    public string StudentFname
    {
        get { return studentFname; }
        set { studentFname = value; }
    }

    public string StudentLname
    {
        get { return studentLname; }
        set { studentLname = value; }
    }

    public char StudentGrade
    {
        get { return studentGrade; }
        set { studentGrade = value; }
    }
}

class Program
{
    static void Main()
    {
        // Create (instantiate) a Student object
        Student s1 = new Student();

        // Assign values using the PUBLIC PROPERTIES (not the private fields)
        Console.WriteLine("Enter Student ID (number): ");
        s1.StudentId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter First Name: ");
        s1.StudentFname = Console.ReadLine();

        Console.WriteLine("Enter Last Name: ");
        s1.StudentLname = Console.ReadLine();

        Console.WriteLine("Enter Grade (single letter like A/B/C): ");
        s1.StudentGrade = Convert.ToChar(Console.ReadLine());

        // Display the data back to the console via the properties
        Console.WriteLine("Student Information");
        Console.WriteLine("ID: " + s1.StudentId);
        Console.WriteLine("First Name: " + s1.StudentFname);
        Console.WriteLine("Last Name: " + s1.StudentLname);
        Console.WriteLine("Grade: " + s1.StudentGrade);
    }
}


// private fields hold the actual data, while public properties provide controlled access. This is called encapsulation.