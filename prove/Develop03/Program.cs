using System;

class Program
{
    static void Main(string[] args)
    {
        Verse verse = new Verse();
        Blanking blanking = new Blanking();

        verse.SetOriginalText(" Moroni 10:2 And I seal up these records, after I have spoken a few words by way of exhortation unto you."); // 'input'

        Console.Clear();

        while (!verse.AllWordsBlanked())
        {
            Console.WriteLine(verse.GetDisplayText());
            Console.WriteLine("\n Press {Enter} to blank three random words");
            Console.ReadLine();
            blanking.BlankRandomWords(verse, 3);
            Console.Clear();
        }

        Console.WriteLine(verse.GetDisplayText());
        Console.WriteLine("\n All of the words have been blanked out");
    }
}
