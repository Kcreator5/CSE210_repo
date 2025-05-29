using System;

class Program
{
    static void Main(string[] args)
    {
        Verse verse = new Verse();
        Blanking blanking = new Blanking();
        Console.WriteLine("2 And I seal up these records, after I have spoken a few words by way of exhortation unto you. Moroni 10:2 ");
        Console.WriteLine("Enter a sentence or paragraph:");
        
        string input = Console.ReadLine();

        verse.SetOriginalText(input);
        Console.Clear();

        while (!verse.AllWordsBlanked())
        {
            Console.WriteLine(verse.GetDisplayText());
            Console.WriteLine("\nPress [Enter] to blank more words...");
            Console.ReadLine();
            blanking.BlankRandomWords(verse, 3);
            Console.Clear();
        }

        Console.WriteLine(verse.GetDisplayText());
        Console.WriteLine("\nAll words have been blanked out!");
    }
}
