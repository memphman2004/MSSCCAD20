// this is for an alternate User input version of the Tell A Story micro-project
// It is not used in the main project, but is provided for reference.
// It is not referenced in the .csproj file.

using System;


class CharacterInfo
{
    // BACKING FIELD: private storage for the Age. A backing field is the private variable that actually stores a property’s value.
    //it exposes a property(public get/set) for outside code. The property reads/writes the backing field internally.
    //This allows logic to be added (validation, logging, etc.) when getting/setting, while still keeping the real storage private.
    private int _age;

    // PROPERTY with validation in the setter:
    // If a negative age is assigned, we correct it to 0 and explain why.
    public int Age
    {
        get { return _age; }   // give (return) the age
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Age cannot be negative. Setting Age to 0.");
                _age = 0;
            }
            else
            {
                _age = value;  // normal path
            }
        }
    }

    // Simple auto-properties (no extra logic needed)
    public string Name { get; set; } = "";      // full name of the character
    public string Job { get; set; } = "";      // job title / role

    // Height in inches (kept simple). We’ll validate at input time.
    public int HeightInInches { get; set; }

    // An ARRAY property to hold favorite activities
    public string[] FavoriteActivities { get; set; } = Array.Empty<string>();
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Character Builder (All Inputs From User) - Tell A Story");

        // Create the character object (instance from the class blueprint)
        var c = new CharacterInfo();

        // Collect ALL inputs from the user
        c.Name = ReadNonEmptyString("Enter character name: ");
        c.Age = ReadInt("Enter age (whole number, >= 0): ", min: 0);
        c.Job = ReadNonEmptyString("Enter job title: ");
        c.HeightInInches = ReadInt("Enter height in INCHES (whole number, > 0): ", min: 1);

        // Ask how many activities the user wants to enter (at least 1)
        int count = ReadInt("How many favorite activities do you want to add? (at least 1): ", min: 1);

        // Allocate an array of the requested size and fill it
        c.FavoriteActivities = new string[count];
        for (int i = 0; i < count; i++)
        {
            c.FavoriteActivities[i] = ReadNonEmptyString($"  Activity #{i + 1}: ");
        }

        // Show a full summary (displays everything the user entered)
        Console.WriteLine("Summary of ALL Input");
        ShowCurrentValues(c);

        // Tell the story using those values
        Console.WriteLine("\nNow telling your complete story...\n");
        TellStory(c);

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }

    //print a summary

    static void ShowCurrentValues(CharacterInfo c)
    {
        Console.WriteLine($"Name:   {c.Name}");
        Console.WriteLine($"Age:    {c.Age}");
        Console.WriteLine($"Job:    {c.Job}");
        Console.WriteLine($"Height: {c.HeightInInches} inches");

        Console.Write("Favorites: ");
        if (c.FavoriteActivities.Length == 0)
        {
            Console.WriteLine("(none)");
        }
        else
        {
            Console.WriteLine(string.Join(", ", c.FavoriteActivities));
        }
    }


    // uses string interpolation + loop

    static void TellStory(CharacterInfo c)
    {
        Console.WriteLine("Your Character Story");
        Console.WriteLine(
            $"Meet {c.Name}! {c.Name} is {c.Age} years old, " +
            $"{c.HeightInInches} inches tall, and works as a(n) {c.Job}.");

        if (c.FavoriteActivities.Length == 0)
        {
            Console.WriteLine($"{c.Name} hasn't listed any favorite activities yet.");
        }
        else
        {
            Console.WriteLine($"{c.Name} enjoys:");
            foreach (string activity in c.FavoriteActivities)
            {
                Console.WriteLine($" - {activity}");
            }
        }
    }

    // ------------------------------------------------
    // INPUT HELPERS (loop until valid) - SAFEGAURDS
    // ------------------------------------------------

    // Reads a non-empty line of text (trims spaces)
    static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();

            // string? means it may be null; we treat null/empty/whitespace as invalid
            if (!string.IsNullOrWhiteSpace(s))
                return s.Trim();

            Console.WriteLine("Please enter some text (not empty).");
        }
    }

    // Reads an integer >= min (optionally <= max if user pass one)
    static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string? text = Console.ReadLine();

            if (int.TryParse(text, out int value))
            {
                if (value < min)
                {
                    Console.WriteLine($"Please enter a number >= {min}.");
                    continue;
                }

                if (value > max)
                {
                    Console.WriteLine($"Please enter a number <= {max}.");
                    continue;
                }

                return value; // valid number in range
            }

            Console.WriteLine("Please enter a whole number (e.g., 25).");
        }
    }
}

