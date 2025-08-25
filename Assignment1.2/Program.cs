{
    int num1;
    int num2;
    int sum;

    Console.WriteLine("Enter your first number: ");
    num1 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Enter your second number: ");
    num2 = Convert.ToInt32(Console.ReadLine());

    sum = num1 + num2;

    Console.WriteLine($"The sum of {num1} and {num2} is: {sum}.");

}