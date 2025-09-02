//Assignment 1.4.1
//Create a structure named “Point” and 2 data members: X and Y coordinate. 
//Declare 2 points: P1 and P2. Determine if P2 is to the right or left of P1 or 
//on same axis , by comparing the x xoordinates. ( if p1.x is more than p2.x , it is 
//to the right )


// in this problem, a Point has an X (left/right) and Y (up/down) coordinate.
struct Point
{
    public int X; // X coordinate (bigger X = more to the RIGHT)
    public int Y; // Y coordinate (up/down)
}

class Program
{
    static void Main()
    {
        // two points declared: P1 and P2
        Point P1, P2;

        // Read P1 from the user input
        Console.WriteLine("Enter P1.X: ");
        P1.X = Convert.ToInt32(Console.ReadLine()); // Convert possible text into int
        Console.WriteLine("Enter P1.Y: ");
        P1.Y = Convert.ToInt32(Console.ReadLine());

        // Read P2 from the user input
        Console.WriteLine("Enter P2.X: ");
        P2.X = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter P2.Y: ");
        P2.Y = Convert.ToInt32(Console.ReadLine());

        // Compare the X values to decide left/right position.
        // Note: If the X value is larger then it means the point is more to the RIGHT.
        // Decide and exit right away so we don't print multiple lines
if (P2.X > P1.X)
{
    Console.WriteLine("P2 is to the RIGHT of P1");
    return; // Exit Main at this point. better controled flow (what lines run, and when)
        } //Once we’ve decided “RIGHT” (or “LEFT”), there’s no need to check 
        // anything else or run later lines.

        if (P2.X < P1.X)
{
    Console.WriteLine("P2 is to the LEFT of P1");
    return; // Exit Main at this point
}

        // will only reach this point when X's are equal
        // The only way to get past both if blocks (no returns taken) is if both 
        // comparisons are false: Not greater and Not less
⇒       //therefore they must be equal, so we print “SAME vertical axis”.
        Console.WriteLine("P2 is on the SAME vertical axis as P1");
       
    }
}

// Console.ReadLine() reads text. Convert.ToInt32() and Convert.ToChar() 
//change that text into numbers/characters.

// This problem could also be done using a switch statement

// int sign = Math.Sign(P2.X - P1.X); // 1 if right, -1 if left, 0 if same

//switch (sign)
//{
  //  case 1:
//        Console.WriteLine("P2 is to the RIGHT of P1");
//        break;
    //case -1:
     //   Console.WriteLine("P2 is to the LEFT of P1");
    //   break;
   // case 0:
    //    Console.WriteLine("P2 is on the SAME vertical axis as P1");
    //    break;
//}
