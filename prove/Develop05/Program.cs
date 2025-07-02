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
        Console.WriteLine("[1] Simple goal");
        Console.WriteLine("[2] Checklist ");
        Console.WriteLine("[3] Repeating goal");
        Console.WriteLine("[4] Loading Goal");
        Console.WriteLine("[5] Exit the program");
        Console.WriteLine("-----------------------------------");
        Console.Write("Enter your choice: ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Simple.simplegoal();
                break;
            case "2":
                _List.checklist();
                break;
            case "3":
                Repeat.repeating_goal(); 
                break;
            case "4":
                loading.load();
                break;
            case "5":
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
        menu.RunMenu();
    }
}