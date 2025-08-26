// Assignment 1.2.2

//Write a C# Sharp program to find the sum of first 10 natural numbers.
//Expected Output :
//The first 10 natural number is :
//1 2 3 4 5 6 7 8 9 10
//The Sum is : 55


int sum = 0;

Console.WriteLine("The first 10 natural number is :");
for (int i = 1; i <= 10; i++)
{
    Console.Write(i + " ");
    sum = sum + i;
}

Console.WriteLine();
Console.WriteLine("The Sum is : " + sum);
    
