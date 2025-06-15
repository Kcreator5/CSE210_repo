using System;
using System.Collections.Generic;
using System.Threading;

class reflection_activity
{

    private int duration;
    private Random rng = new Random();

    private List<string> prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this that applies to other situations?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("-------------------");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");
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

    public void Run()
    {
        Console.Clear();

        string prompt = prompts[rng.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("Think about this prompt as you answer the following questions.\n");

        int timePassed = 0;

        while (timePassed < duration)
        {
            string question = questions[rng.Next(questions.Count)];
            Console.WriteLine($"> {question}");
            breathing_activity.ShowSpinner(5); // let them think

            timePassed += 5;
        }
    }

    public void EndActivity()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You have completed the Reflection Activity for {duration} seconds.");
        breathing_activity.ShowSpinner(3);
    }

    
}
