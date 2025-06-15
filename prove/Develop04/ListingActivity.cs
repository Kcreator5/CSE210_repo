using System;
using System.Collections.Generic;
using System.Threading;

class listing_activity
{
    
    private int duration;
    private Random rng = new Random();
    private List<string> items = new List<string>();

    private List<string> prompts = new List<string>()
    {
    "What are things in your life that make you smile?",
    "What are achievements you're proud of, big or small?",
    "What cool things have you learned recently?",
    "What are some moments from today or this week that have brought you peace?",
    "What are places where you feel most comfortable?",
    "What hobbies or activities have you enjoyed this week so far?",
    "What kind things others have done for you lately?",
    "What do you love about yourself?",
    "Any goals that you are excited to work toward?"
    };

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine("Listing Activity");
        Console.WriteLine("----------------");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.Write("\nHow long would you like to do this activity? (in seconds): ");

        string input = Console.ReadLine();
        while (!int.TryParse(input, out duration) || duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
            input = Console.ReadLine();
        }

        Console.WriteLine("\nGet ready...");
        breathing_activity.ShowSpinner(3);
    }
    
    // private ShuffleList promptPicker;
    public void Run()
    {
        Console.Clear();

        string prompt = prompts[rng.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("You will have a moment to think, then begin listing.\n");

        breathing_activity.ShowSpinner(5); // Think time

        Console.WriteLine("Start listing! Press Enter after each item.");

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }
    }

    public void EndActivity()
    {
        Console.WriteLine($"\nWell done! You listed {items.Count} items.");
        Console.WriteLine($"You have completed the Listing Activity for {duration} seconds.");
        breathing_activity.ShowSpinner(3);
    }
}
