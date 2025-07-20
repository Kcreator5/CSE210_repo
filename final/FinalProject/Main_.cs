using System;
// Console.Clear(); this command clears the console. 
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // This allows me to print some sybols for ascii art.
        Player player = new Player(18, 14, 12, 10, 10, 12); // this sets up the player and their stats
        Monster goblin = new Monster("Goblin", 10, 14, 12, 6, 8, 5); // this sets up the golblin
        List<Character> characters = new List<Character>() { player, goblin };

        /* I no longer need this because I polymorphed it!
                player.DisplayStats();
                Console.WriteLine("Press enter to continue:");
                Console.ReadLine();
                Console.Clear();
                goblin.DisplayStats();
                Console.WriteLine("Press enter to continue:");
                Console.ReadLine();
        */
        Console.Clear();
        Console.WriteLine("Welcome to my program and final project. This is a very basic combat simulator.");
        Console.WriteLine("Press enter to continue:");
        Console.ReadLine();

        foreach (var character in characters)
        {
            Console.Clear();
            character.Describe(); // On each call, depending on who calls it, this gives a different description and prints off their stats!
            Console.WriteLine("Press enter to continue:");
            Console.ReadLine();
        }
        Console.WriteLine("Now, lets get into the battle simulator");
        var combat = new Combat(player, goblin);
        combat.StartBattle();


    }
}