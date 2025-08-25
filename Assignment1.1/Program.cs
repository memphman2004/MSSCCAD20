{
        string name;
        int age;
        string address;
    Console.Write("Enter you name: ");
    name = Console.ReadLine();

    Console.Write("Enter your age: ");
    age = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter your address: ");
    address = Console.ReadLine();

    Console.WriteLine($"Hello, {name}. You are {age} years old and live at {address}.");

}