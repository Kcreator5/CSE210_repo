using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;

class JournalManager
{
    // Path to the folder where journal entries will be stored
    private static string journalfolder = "JournalEntries";

    // This ensures the folder exists; if not, it creates it
    public static void InitializeFolder()
    {
        if (!Directory.Exists(journalfolder))
        {
            Directory.CreateDirectory(journalfolder);
        }
    }

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

        Console.WriteLine($"✅ Journal entry saved as: {filename}");
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

