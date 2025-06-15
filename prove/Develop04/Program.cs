
using System;

class Program
{
    static void Main(string[] args)
    {   
        breathing_activity breathing = new breathing_activity();
        reflection_activity reflection = new reflection_activity();
        listing_activity listing = new listing_activity();

        
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to this Program. We hope we can help you with your anxiety.");
            Console.WriteLine("\nSelect one of the following activities:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nEnter your choice (1 - 4): ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    
                    breathing.StartActivity();
                    breathing.Run();
                    breathing.EndActivity();
                    break;
                case "2":
                    
                    reflection.StartActivity();
                    reflection.Run();
                    reflection.EndActivity();
                    break;
                case "3":
                    
                    listing.StartActivity();
                    listing.Run();
                    listing.EndActivity();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye! Be kind to yourself, and maybe treat yourself to some icecream!");
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 4.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }
}