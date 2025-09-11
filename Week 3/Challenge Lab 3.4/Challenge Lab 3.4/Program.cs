// =============================================================
// Lab#4: Remove "AB" / "CD" repeatedly to minimize length
// =============================================================
// Goal: Given an uppercase string s, repeatedly remove any occurrence of "AB" or "CD".
// After each removal, the string closes up (concatenates), possibly forming new "AB"/"CD" pairs.
// Keep going until no more "AB" or "CD" appear. Output the minimal possible length.
// Hint suggests: use string.Replace and loop until nothing changes.


using System;

class Program
{
    static void Main()
    {
        // Ask the user for an uppercase letter
        // (convert whatever they type to uppercase just in case.  s = s.ToUpperInvariant();)
        Console.Write("Enter an uppercase string (A-Z only): ");
        string? s = Console.ReadLine(); // Read one line of input as a string (could be null)

        // If the user pressed Enter without typing anything (null or only spaces),
        // there is nothing to remove, so the minimum length is 0.
        if (string.IsNullOrWhiteSpace(s))
        {
            Console.WriteLine("Minimum possible length after removals: 0");
            return; // End the program early
        }

        // If the user types a letter convert the string to uppercase so that "ab" and "cd" also match "AB" and "CD".
        // Since strings are IMMUTABLE (cannot change after it’s created) in C#, Replace/ToUpper create NEW strings.
        s = s.ToUpperInvariant();

        // Call our function that keeps removing "AB" and "CD" until no more are found.
        int minLen = MinLengthAfterRemovals(s);

        // Print the final minimal length.
        Console.WriteLine($"Minimum possible length after removals: {minLen}");

        // Examples of inputs
        // Input:  ABFCACDB  -> Output: 2 (final string would be "FC")
        // Input:  ACBBD     -> Output: 5 (no removable pairs)
    }

    // This function repeatedly removes "AB" and "CD" from the string.
    // It stops when an entire pass makes no changes (meaning no more "AB"/"CD" exist).
    static int MinLengthAfterRemovals(string s)
    {
        string current = s;

        // Loop until a pass makes no changes
        while (true)
        {
            // Remove all "AB" then all "CD" in this pass
            string next = current.Replace("AB", "").Replace("CD", "");

            // If strings are identical, nothing was removed → we're done
            // (Note: for strings, '==' compares contents in C#.)
            if (next == current)
                break;

            // Otherwise, continue with the new (shorter) string
            current = next;
        }

        return current.Length;
    }
}


/* A do-while loop runs its body AT LEAST ONCE, then checks the condition. It works here as it compares compares previous length vs current length
        // we want to attempt removal at least one time.
    do
        {
            // Remember how long the string is before we start this pass.
        prevLen = s.Length;

            // Replace ALL occurrences of "AB" with "" (remove them),
            // then do the same for "CD".
            // Important: Replace returns a NEW string (original is unchanged),
            // so we assign the result back to s.
        s = s.Replace("AB", "").Replace("CD", "");

            // After replacement, the string "closes up" (concatenates),
            // which might create NEW "AB" or "CD" pairs. That’s why we loop.
        }
             // Keep looping while the length CHANGED during the pass.
            // If the length stays the same, nothing was removed → we are done.
        while (s.Length != prevLen);
*/