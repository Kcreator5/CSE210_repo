using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;

class JournalManager
{
    // Path to the folder where journal entries will be stored
    private static string journalfolder = "JournalEntries";

    // This method saves a journal entry as a .txt file
    public static void SaveEntry(string prompt, string entryText)
    {
        // Automatically gets the current date and time
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

        // Create a filename using the timestamp
        string filename = Path.Combine(journalfolder, $"Entry_{timestamp}.txt");

        // Format the contents of the journal entry
        string content = $"Date: {DateTime.Now}\nPrompt: {prompt}\n\nEntry:\n{entryText}";

        // Write the content to the file
        File.WriteAllText(filename, content);

        Console.WriteLine($" Journal entry saved as: {filename}");
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
        "Did you improve in anything today?",
        "What is your +1% today?",
        "What scripture did you read today?"
    };

public static string ShuffleingPrompts()
{
    int index = ShuffleList.GetNextPromptIndex();
    return prompts[index];
}

    private static Random rng = new Random();

    class ShuffleList
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

        // resets the shuffle cycle
        public static void Reset()
        {
            next_prompts = new List<int>(past_prompts);
            past_prompts.Clear();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        // JournalManager.InitializeFolder(); // Make sure folder exists

        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Type 'END' on a new line when you're done writing.\n");

        // this gets the next prompt from the PromptManager
        string prompt = PromptManager.ShuffleingPrompts();

        // this writes the prompt
        Console.WriteLine("Question of the day:");
        Console.WriteLine(prompt);
        Console.WriteLine("\nStart your journal entry below:");

        // Capture multi-line user input
        string entryText = "";
        string line;
        while ((line = Console.ReadLine()) != null && line.Trim().ToUpper() != "END")
        {
            entryText += line + "\n";
        }
    }

    public static void SaveEntry(string prompt, string entryText)
    {
        // Defining the path for the journal. 
        string filePath = "prove/Develop02/JournalEntries.text";

        // Format the entry with date and prompt
        string content = $"Date: {DateTime.Now}\n Question of the day: {prompt}\n\nEntry:\n{entryText}\n";
        content += "--------------------------\n"; // optional separator

        // Append the content to the file
        File.AppendAllText(filePath, content);

        Console.WriteLine($"Entry appended to: {filePath}");
        
    }

    
}


