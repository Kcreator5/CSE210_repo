using System;

class menu
{ 
    public static void RunMenu()
{
    bool running = true;

    while (running)
    {  
        Console.WriteLine("\nWelcome back to your journal!");

        Console.WriteLine("What would you like to do?");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("[1] Write an entry");
        Console.WriteLine("[2] Start with a prompt");
        Console.WriteLine("[3] View past entries");
        Console.WriteLine("[4] Exit the program");
        Console.WriteLine("-----------------------------------");
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


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
    }
}