// Micro-Project 1 - Tell A Story
// This program tells a story using variables and string interpolation.

using System;                 // for Console
using System.Linq;                 // for ToList()
using System.Collections.Generic;  // for List<T>


// OvierView
// This is a single character story (Jake FromStateFarm) and prints a
// short story. Some values are hard-coded; the user then fills in the rest once prompted.
//
// CODE BREAKDOWN
// - Class to hold the character data (data model). The chacter is the data we are modeling
// - Class with properties (get/set).
// - Backing field + custom setter with an 'if' check (validation).
// - Array property + a loop to print it.
// - A menu that uses if/else (YES: this is an alternative to switch/case).


//Character "data model" class - stores the fields and keeps them consistent
//Character – what we are modeling (creating)
//data model – a class whose job is to hold the data (and maybe tiny validation) for that creation (chacter in this case).
//class – the C# blueprint used to create objects

class CharacterInfo
{
    // BACKING FIELD: private storage for the Age. A backing field is the private variable that actually stores a property’s value.
    //it exposes a property(public get/set) for outside code. The property reads/writes the backing field internally.
    //This allows logic to be added (validation, logging, etc.) when getting/setting, while still keeping the real storage private.
    private int _age;

    // PROPERTY with custom set validation:
    // If someone tries to set a negative age, fix it to 0 and explain why.
    public int Age
    {
        get { return _age; }   // return the age
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Age cannot be negative. Setting Age to 0.");
                _age = 0;
            }
            else
            {
                _age = value;
            }
        }
    }

    // These are hard-coded in Main().
    public string Name { get; set; } = "";   // e.g., "Jake FromStateFarm"
    public string Job { get; set; } = "";   // e.g., "Insurance Agent"

    // Height is left for the user to enter (inches, to keep it simple)
    public int HeightInInches { get; set; } = 0;

    // At least one property must be an ARRAY — store favorite activities here.
    public string[] FavoriteActivities { get; set; } = Array.Empty<string>();
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Character Builder - Tell A Story");

        // Create (instantiate) the character object. 
        var c = new CharacterInfo();

        //Hard-code the details specified for Jake FromStateFarm.
        //    We still assign via public properties (encapsulation).
        c.Name = "Jake FromStateFarm";
        c.Age = 31;                    // goes through custom setter above
        c.Job = "Insurance Agent";
        c.FavoriteActivities = new[]
        {
            "selling insurance",
            "wearing red"
        };

        // keeps looping with a switch.
        while (true) // exits only on case "4", "5", or when auto-tell triggers
        {
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Enter height (inches)");
            Console.WriteLine("2) Add more favorite activities");
            Console.WriteLine("3) Show current values");
            Console.WriteLine("4) Tell the story now");
            Console.WriteLine("5) Exit");
            Console.Write("Choose 1-5: ");

            string? choice = Console.ReadLine();

            switch (choice) // 'case' labels only exist inside a 'switch' in C#
            {
                case "1":
                    // Ask user for height; stay in the loop afterward
                    c.HeightInInches = ReadInt("Enter height in inches (whole number): ");
                    break;

                case "2":
                    // Using List<string> to avoid resizing arrays
                    // Build a list from the current array once, add items to the list,
                    // then convert back to an array when done.
                    var list = c.FavoriteActivities.ToList();

                    Console.WriteLine("Enter activities (blank line to finish):");
                    while (true)
                    {
                        Console.WriteLine("  Activity: ");
                        string? activity = Console.ReadLine();

                        // stop adding when user just hits Enter or types only spaces
                        if (string.IsNullOrWhiteSpace(activity))
                            break;

                        list.Add(activity); // Lists grow automatically
                    }

                    c.FavoriteActivities = list.ToArray(); // convert back to array once
                    Console.WriteLine("Activities updated.");
                    break;

                case "3":
                    // Preview current values; keep looping afterward
                    ShowCurrentValues(c);
                    break;

                case "4":
                    // Tell now and finish
                    Console.WriteLine("\nTelling your complete story now...\n");
                    ShowCurrentValues(c); // show EVERYTHING first
                    TellStory(c);
                    return; // leave Main()

                case "5":
                    Console.WriteLine("Goodbye!");
                    return; // leave Main()

                default:
                    Console.WriteLine("Please choose a valid option (1–5).");
                    break;
            }

            // TELL THE STORY ONCE ***ALL*** INPUTS ARE PRESENT
            // Required: Name, Age, Job, at least 1 activity, and Height (> 0).
            if (AllInputsPresent(c))
            {
                Console.WriteLine("All inputs collected. Here is a summary of EVERYTHING (including hard-coded values):");
                ShowCurrentValues(c);        // shows Name, Age, Job, Height, Activities

                Console.WriteLine("Now telling your complete story...");
                TellStory(c);                // uses the same values again in narrative form
                return;                      // finish after telling story
            }
        }
    }

    // print a summary of the character so far
    static void ShowCurrentValues(CharacterInfo c)
    {
        Console.WriteLine("\n--- Current Character ---");
        Console.WriteLine($"Name:   {c.Name}");
        Console.WriteLine($"Age:    {c.Age}");
        Console.WriteLine($"Job:    {c.Job}");
        Console.WriteLine($"Height: {c.HeightInInches} inches");

        Console.WriteLine("Favorites: ");
        if (c.FavoriteActivities.Length == 0)
            Console.WriteLine("(none)");
        else
            Console.WriteLine(string.Join(", ", c.FavoriteActivities));
    }

    // Story method: uses string interpolation and a loop to print the activities array
    static void TellStory(CharacterInfo c)
    {
        Console.WriteLine("Your Character Story: Meet Jake FromStateFarm!");

        // String interpolation: $"Hello {name}" inserts variables directly.
        Console.WriteLine(
            $"This is {c.Name}. " +
            $"{c.Name} is {c.Age} years old, " +
            $"{c.HeightInInches} inches tall, " +
            $"and works as an {c.Job.ToLower()}.");

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

    // ReadInt: to read a whole number
    // Uses int.TryParse just in case the user puts in a bad input and doesn't crash
    static int ReadInt(string prompt)
    {
        while (true) // keep asking until we get a good number
        {
            Console.Write(prompt);
            string? text = Console.ReadLine(); // 'string?' means it may be null (no input)

            if (int.TryParse(text, out int value))
                return value;

            Console.WriteLine("Please enter a whole number (like 68).");
        }
    }

    // Returns true only when EVERY required field is complete
    // This ensures the summary + story include *all* the data
    static bool AllInputsPresent(CharacterInfo c)
    {
        // Name must not be blank, Age must be >= 0,
        // Job must not be blank, Height must be > 0,
        // and there must be at least one favorite activity.
        return
            !string.IsNullOrWhiteSpace(c.Name) &&
            c.Age >= 0 &&
            !string.IsNullOrWhiteSpace(c.Job) &&
            c.HeightInInches > 0 &&
            c.FavoriteActivities != null &&
            c.FavoriteActivities.Length > 0;
    }
}