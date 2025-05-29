using System;
using System.Collections.Generic;

public class Blanking
{
    private Random rand = new Random();

    public void BlankRandomWords(Verse verse, int count)
    {
        List<int> unblanked = verse.GetUnblankedIndexes();

        int blanksToDo = Math.Min(count, unblanked.Count);

        for (int i = 0; i < blanksToDo; i++)
        {
            int randomIndex = rand.Next(unblanked.Count);
            int wordIndex = unblanked[randomIndex];
            verse.BlankWordAt(wordIndex);
            unblanked.RemoveAt(randomIndex);
        }
    }
}
