using System;
using System.Threading;

class breathing_activity
{
    private int duration;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("------------------");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");
        Console.Write("\nHow long would you like breath? (in seconds) don't worry you can still breath afterward :P \n : ");

        string input = Console.ReadLine();
        while (!int.TryParse(input, out duration) || duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
            input = Console.ReadLine();
        }

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3); // Short pause
    }

    public void Run()
    {
        int timePassed = 0;

        while (timePassed < duration)
        {
            Console.Write("\nBreathe in... ");
            Countdown(6);
            timePassed += 3;

            if (timePassed >= duration) break;

            Console.Write("Breathe out... ");
            Countdown(6);
            timePassed += 3;
        }
    }

    public void EndActivity()
    {
        Console.WriteLine("\n\nWell done!");
        Console.WriteLine($"You have completed the Breathing Activity for {duration} seconds.");
        ShowSpinner(3); // Pause before finishing
    }

    public static void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
            if (i < 9)
            {
                Console.Write("\b\b");
            }
            else
            { 
                Console.Write("\b");
            }
            
        }
        Console.WriteLine();
    }

    public static void ShowSpinner(int seconds)
{
    string[] spinner = { "D", "I"};
    int endTime = Environment.TickCount + (seconds * 1000);

    int i = 0;
    while (Environment.TickCount < endTime)
    {
        Console.Write(":" + spinner[i % spinner.Length]);
        Thread.Sleep(1000);
        Console.Write("\b\b");
        i++;
    }
}
}
