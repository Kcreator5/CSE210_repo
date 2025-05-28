using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;

class menu
{ 
    public static void RunMenu()
{
    bool running = true;

    while (running)
    {
        Console.WriteLine("\nWelcome back to your journal!");

        Console.WriteLine("What would you like to do?");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("[1] Write an entry");
        Console.WriteLine("[2] Start with a prompt");
        Console.WriteLine("[3] View past entries");
        Console.WriteLine("[4] Exit program");
        Console.WriteLine("-----------------------------------------");

        Console.Write("Enter your choice: ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                WriteEntry.WritingEntry();
                break;
            case "2":
                PromptEntry.PromptingEntry();
                break;
            case "3":
                LoadEntries.LoadEntriesByDate(); 
                break;
            case "4":
                running = false;
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid input. Try again.");
                break;
        }
    }
}
}



class PromptManager
{
    private static List<string> prompts = new List<string>()
    {
        "What are you grateful for today?",
        "What was your favorite part about today?",
        "Have you eaten any yummy foods this day?",
        "What song was your favorite to listen to today?",
        "Did you learn something new?",
        "What struggles did you have today? Did you overcome them?",
        "Did you improve on anything today?",
        "What is your +1% today?",
        "What scripture did you read today?"
    };

    public static string ShuffleingPrompts()
    {
        int index = ShuffleList.GetNextPromptIndex();
        return prompts[index];
    }

    private static Random rng = new Random();

    class ShuffleList // I've relized half of this dosn't really work because it dosn't save it's status between loads. But the random stil works so I an't touchin it.
    {
        public static List<int> past_prompts = new List<int>() { };
        public static List<int> next_prompts = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; // number of prompts

        private static Random rng = new Random(); // putting in random

        // gets the index of the next prompt to use
        public static int GetNextPromptIndex()
        {
            // If all prompts have been used, reset
            if (next_prompts.Count == 0)
            {
                Reset();
            }

            // choose random index from the remaining prompts
            int randomIndex = rng.Next(next_prompts.Count);
            int selected = next_prompts[randomIndex];

            // remove from next, add to past
            next_prompts.RemoveAt(randomIndex);
            past_prompts.Add(selected);

            return selected;
        }

        // resets the shuffle cycle but it dosn't work as exspected. 
        public static void Reset()
        {
            next_prompts = new List<int>(past_prompts);
            past_prompts.Clear();
        }
    }
}

class PromptEntry
{
    public static void PromptingEntry()
    {

        // this gets the next prompt from the PromptManager
        string prompt = PromptManager.ShuffleingPrompts();

        Console.Clear(); // This clears the terminal. 

        // this writes the prompt.
        Console.WriteLine(prompt);

        Console.WriteLine("\nWrite your journal entry below");
        Console.WriteLine("Type 'END' on a new line when you're done writing.\n");

        // Capture multi-line user input
        string entryText = "";
        string line;
        while ((line = Console.ReadLine()) != null && line.Trim().ToUpper() != "END")
        {
            entryText += line + "\n";
        }
        SaveEntry(prompt, entryText);
    }

    public static void SaveEntry(string prompt, string entryText)
    {
        // Defining the path for the journal. 
        string filePath = "../../../JournalEntries.text";

        // Format the entry with date and prompt
        string content = $"Date: {DateTime.Now}\n Question of the day: {prompt}\n\nEntry:\n{entryText}\n";
        content += "--------------------------\n"; // optional separator

        // Append the content to the file
        File.AppendAllText(filePath, content);

        Console.WriteLine($"Entry appended to: {filePath}");
        
    }

}

class WriteEntry
{
    public static void WritingEntry()
    {

        // this gets the next prompt from the PromptManager
        string prompt = PromptManager.ShuffleingPrompts();

        Console.Clear(); // clears the terminal. 

        Console.WriteLine("\nWrite your journal entry below");
        Console.WriteLine("Type 'END' on a new line when you're done writing.\n");

        // Capture multi-line user input
        string entryText = "";
        string line;
        while ((line = Console.ReadLine()) != null && line.Trim().ToUpper() != "END")
        {
            entryText += line + "\n";
        }
        SaveEntry(prompt, entryText);
    }

    public static void SaveEntry(string prompt, string entryText)
    {
        // Defining the path for the journal. 
        string filePath = "../../../JournalEntries.text";

        // Format the entry with date and prompt
        string content = $"Date: {DateTime.Now}\n Question of the day: {prompt}\n\nEntry:\n{entryText}\n";
        content += "--------------------------\n"; // optional separator

        // Append the content to the file
        File.AppendAllText(filePath, content);

        Console.WriteLine($"Entry appended to: {filePath}");
        
    }
    
}

class LoadEntries
{
    public static void LoadEntriesByDate()
{
    string filePath = "../../../JournalEntries.text";

    if (!File.Exists(filePath))
    {
        Console.WriteLine("No journal entries found.");
        return;
    }

    Console.Write("Enter the date to search for (format: MM-DD-YYYY): ");
    string targetDate = Console.ReadLine().Trim();

    string[] lines = File.ReadAllLines(filePath);
    bool entryFound = false;
    bool printing = false;

    Console.WriteLine($"\n Entries for {targetDate}:");
    Console.WriteLine("-----------------------------------------");

    foreach (string line in lines)
    {
        if (line.StartsWith("Date: "))
        {
            string datePart = line.Substring(6, 10); // Extracts "YYYY-MM-DD"
            if (DateTime.TryParse(datePart, out DateTime parsedDate))
            {
                string formattedDate = parsedDate.ToString("MM-dd-yyyy"); // Reformat to match user input
                printing = formattedDate == targetDate;

                if (printing)
                {
                    entryFound = true;
                    Console.WriteLine(); // spacing before entry
                    Console.WriteLine(line); // print the matching Date line
                }
            }
            else
            {
                printing = false;
            }
        }
        else if (printing)
        {
            Console.WriteLine(line);

            if (line.StartsWith("--------------------------"))
            {
                printing = false; // Stop after the entry separator
            }
        }
    }

    if (!entryFound)
    {
        Console.WriteLine("No entries found for that date.");
    }
    Console.WriteLine("-----------------------------------------");
}

}

class Program // this runs the program
{
    static void Main(string[] args)
    {
        menu.RunMenu();
    }
}

