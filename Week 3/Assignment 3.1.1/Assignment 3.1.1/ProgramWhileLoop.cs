public static string ReturnEvenNumbers_While()
{
   
    var sb = new StringBuilder();

    // Start at 2 because it's the first positive even number
    int i = 2;

    // Keep looping as long as i is less than 100
    while (i < 100)
    {
        // Add a space BEFORE each number EXCEPT the very first one
        // Trick: if sb has something in it already (length > 0), we add a space
        if (sb.Length > 0)
        {
            sb.Append(' ');
        }

        // Add the current even number
        sb.Append(i);

        // Move to the next even number (add 2 each time)
        i += 2;
    }

    // Turn the StringBuilder into a normal string and return it
    return sb.ToString();
}

// for: best when you know (or control) the iteration count or an index.
// while: best when you loop until something happens (count unknown up front). Reach 100 in this case

//Why a while loop works nicely here
//A while loop says: “Do this while a condition holds.”
//We’re not looping a fixed number of times; we’re looping until i reaches the boundary.
//Functionally, this is equivalent to a for loop like for (int i = 2; i < 100; i += 2), 
//but while makes the condition and increment more visibly separate for learning.