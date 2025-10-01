using System;
// This demo shows enqueue, iterate, peek, and dequeue operations.
// using a Linked List to implement a call queue.

// A "queue" is First-In-First-Out (FIFO): first person added is the first served.
// implement a queue using C#'s LinkedList<T>

Console.WriteLine(" Call Queue (Linked List)");
Console.WriteLine("This demo shows enqueue, iterate, and dequeue operations.\n");

// Create our call queue object (which uses a LinkedList internally).
var queue = new CallQueue();

// ADD callers to the end of the queue in order
// This calls LinkedList.AddLast(...) to put each caller at the END.
queue.Enqueue("The Rock");    // ADD (enqueue) at the BACK
queue.Enqueue("Hulk Hogan");  // ADD (enqueue) at the BACK
queue.Enqueue("Chuck Norris");  // ADD (enqueue) at the BACK
queue.Enqueue("Little Debbie"); // ADD (enqueue) at the BACK
queue.Enqueue("John Devries");    // ADD (enqueue) at the BACK

// ITERATE to see all callers
// This prints callers from BEGINING to the END by using a foreach loop over the LinkedList.

Console.WriteLine("Current queue (front to back):");
queue.PrintAll();  // ITERATION happens inside PrintAll() using foreach over the LinkedList

// Allows the user to add another caller to the BACK of the queue.
Console.Write("\nEnter a caller name to the end of the queue (enqueue): ");
string? name = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(name))
{
    queue.Enqueue(name.Trim()); //ENQUEUE: add to the BACK using LinkedList.AddLast(...)
    Console.WriteLine($"Enqueued: {name}");
}
else
{
    Console.WriteLine("No name entered. Skipping enqueue.");
}

// Show queue again after the new enqueue operation.
Console.WriteLine("\nQueue after enqueue:");
queue.PrintAll();  //ITERATION again to show current order

// PEEK: who’s next?
// Peek shows who is next/head of the LinkedList without removing them.
var next = queue.Peek();
Console.WriteLine(next is null
    ? "\nNo one is waiting (queue is empty)."
    : $"\nNext caller (peek): {next}");

// DEQUEUE (serve next)
// REMOVES the FRONT caller using LinkedList.RemoveFirst().
var served = queue.Dequeue();   // DEQUEUE: remove from the FRONT (head)
Console.WriteLine(served is null
    ? "Dequeue did nothing (queue is empty)."
    : $"Dequeued (served): {served}");

// Final view of the queue after one dequeue.
Console.WriteLine("\nQueue after one dequeue:");
queue.PrintAll();  // ITERATION

Console.WriteLine($"\nTotal waiting: {queue.Count}");
Console.WriteLine("\nDone. Press Enter to exit.");
Console.ReadLine();

// queue implementation using a LinkedList<string>

// NOTE: C# already has Queue<T>, but I am using LinkedList<T> 
// so I can SEE where items are added/removed.
class CallQueue
{
    // This LinkedList actually stores the callers in order.
    private readonly LinkedList<string> _list = new();

    // Number of callers currently waiting.
    public int Count => _list.Count;

    // Quick check: is the queue empty?
    public bool IsEmpty => _list.Count == 0;

    // ENQUEUE: add a caller to the BACK of the queue
   
    public void Enqueue(string caller)
    {
        // KEY LINE (ADD): LinkedList<T>.AddLast(...) puts the node (chain of boxes) at the TAIL (END).
        _list.AddLast(caller);  // ENQUEUE here
    }

    // DEQUEUE: remove and return the FRONT of the queue (pointer)
    public string? Dequeue()
    {
        if (_list.Count == 0)
            return null; // nothing to remove

        // The FRONT of the queue is the HEAD of the LinkedList (First).
        var value = _list.First!.Value; // looks at the front value

        _list.RemoveFirst();// DEQUEUE here

        return value; // return the caller we just removed/served
    }

    // PEEK: look at (but do not remove) the FRONT (head)
    public string? Peek()
    {
        // First?.Value is the FRONT caller; null if empty.
        return _list.First?.Value;
    }

    // ITERATE: print everyone from in order from FRONT to BACK
    public void PrintAll()
    {
        if (_list.Count == 0)
        {
            Console.WriteLine("(empty)");
            return;
        }

        // foreach loop is used to walk the LinkedList from HEAD (beginning) to TAIL (end) in order.
        foreach (var caller in _list)
        {
            Console.WriteLine($"- {caller}");
        }
    }
}

// Keywords/Terms to remember for queue operations:
// - Enqueue  = add caller to the END (tail) of the queue
// - Dequeue  = remove caller from the FRONT (head) of the queue
// - Peek     = look at the front caller without removing
// - Iterate  = walk through everyone waiting, in order (front -> back)
// - Count    = how many callers are waiting
// - LinkedList = stores the callers in order