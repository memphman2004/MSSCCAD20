// Program.cs
// -------------------------------------------------------------
// I/O DEMO FILE 
//
// WHAT THIS PROGRAM SHOWS
// - How to write text to a file (overwrite + append)
// - How to read the whole file at once
// - How to read a file line-by-line
// - How to build file paths safely on Windows/macOS/Linux
//
// HOW TO RUN
// 1) Visual Studio → Create a new project → "Console App (.NET)"
// 2) Replace the default Program.cs contents with this file.
// 3) Press ▶ Run. Then open the printed folder path to see the file.
//
// WHY WE USE System.IO:
// - It gives us classes like File, Directory, StreamWriter, StreamReader, Path
// -------------------------------------------------------------

using System;
using System.IO; // <- Required for file & folder helpers

namespace IoForNewbies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------------------------------
            // 0) PICK A FOLDER TO SAVE INTO
            // ---------------------------------------------------------
            // We'll put our file in the user's Documents folder inside a
            // subfolder "FileIoDemo". This is nicer than writing into the
            // bin/Debug output folder because it’s easy to find later.
            //
            // Environment.SpecialFolder.MyDocuments gives an OS-safe path.
            // Path.Combine builds paths safely (don’t hand-type slashes).

            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string demoFolder      = Path.Combine(documentsFolder, "FileIoDemo");
            Directory.CreateDirectory(demoFolder); // OK if it already exists

            // Build the full file path:  e.g. C:\Users\You\Documents\FileIoDemo\myFile.txt
            // or /Users/You/Documents/FileIoDemo/myFile.txt on macOS.
            string filePath = Path.Combine(demoFolder, "myFile.txt");

            // ---------------------------------------------------------
            // 1) WRITE: CREATE/OVERWRITE A FILE (quick helper method)
            // ---------------------------------------------------------
            // File.WriteAllText will CREATE the file if it doesn’t exist,
            // or OVERWRITE it if it does. Use Environment.NewLine for a
            // cross-platform newline.

            string firstContent =
                "Hello, this is a test line." + Environment.NewLine +
                "Another line here.";
            File.WriteAllText(filePath, firstContent);
            Console.WriteLine($"[WRITE] Created or overwrote: {filePath}");

            // ---------------------------------------------------------
            // 2) WRITE: APPEND MORE TEXT (StreamWriter example)
            // ---------------------------------------------------------
            // StreamWriter gives more control (append, buffering, etc.).
            // The 'using' block AUTOMATICALLY CLOSES the file at the end.
            // The 2nd parameter 'true' means "append" instead of overwrite.

            using (StreamWriter sw = new StreamWriter(filePath, append: true))
            {
                sw.WriteLine("This line is appended."); // WriteLine adds a newline
                sw.WriteLine($"Timestamp: {DateTime.Now}");
            }
            Console.WriteLine("[APPEND] Added two more lines.");

            // ---------------------------------------------------------
            // 3) READ: WHOLE FILE AT ONCE (quick helper method)
            // ---------------------------------------------------------
            // File.ReadAllText loads the entire file into a string.
            // Simple and great for small/medium files.

            if (File.Exists(filePath)) // good to check if it exists first
            {
                string allText = File.ReadAllText(filePath);
                Console.WriteLine("\n== CONTENT: ReadAllText ==");
                Console.WriteLine(allText);
            }
            else
            {
                Console.WriteLine($"\nFile not found: {filePath}");
            }

            // ---------------------------------------------------------
            // 4) READ: LINE BY LINE (StreamReader example)
            // ---------------------------------------------------------
            // StreamReader is memory-friendly for large files and lets
            // you process each line as you go. The 'using' closes it.

            if (File.Exists(filePath))
            {
                Console.WriteLine("== CONTENT: StreamReader (line-by-line) ==");
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null) // null when end-of-file
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            // ---------------------------------------------------------
            // 5) WHERE DID MY FILE GO?
            // ---------------------------------------------------------
            // We printed the full path earlier. You can copy/paste it into
            // File Explorer (Windows) or Finder (macOS).
            
            Console.WriteLine($"\nYour file lives here:\n{filePath}");

            // Keep the console open so you can read the output.
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

/*
- using System.IO; – gives you File, Directory, StreamReader, StreamWriter, and Path.
    ** Path.Combine(...) – builds paths safely on Windows/macOS/Linux. Don’t hand-type slashes.
    ** Directory.CreateDirectory(...) – creates the folder if needed (no error if it already exists).
    ** File.WriteAllText – simplest way to create/overwrite a file with text.
    ** StreamWriter(..., append: true) – lets you append and controls when to write. The using block closes the file for you (very important).
    ** File.ReadAllText – fast and simple for small files.
    ** StreamReader.ReadLine() – reads line-by-line, better for large files or when you need to process lines as you go.

- Environment.NewLine – the correct newline character(s) for the OS.
*/