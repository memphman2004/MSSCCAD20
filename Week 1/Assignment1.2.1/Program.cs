// Assignment1.2.1

//Write a C# Sharp program to accept two integers and check whether they are equal or not.
//Test Data :
//Input 1st number: 5
//Input 2nd number: 5
//Expected Output :
//5 and 5 are equal
//Test Data :
//Input 1st number: 5
//Input 2nd number: 15
//Expected Output :
//5 and 15 are not equal

class Program
{
    static void Main()
    {
        Console.Write("Input 1st number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input 2nd number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        if (num1 == num2)
        {
            Console.WriteLine(num1 + " and " + num2 + " are equal");
        }
        else
        {
            Console.WriteLine(num1 + " and " + num2 + " are not equal");
        }
    }
}

