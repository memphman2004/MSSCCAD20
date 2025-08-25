{
    int dividend;
    int divisor;
    int quotient;
    int remainder;

    Console.WriteLine("Enter the dividend: ");
    dividend = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Enter your second number: ");
    divisor = Convert.ToInt32(Console.ReadLine());

    quotient = dividend / divisor;
    remainder = dividend % divisor;

    Console.WriteLine("Quotient = " + quotient);
    Console.WriteLine("Remainder = " + remainder);

}