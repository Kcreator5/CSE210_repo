using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Verse
{
    private List<string> originalWords = new List<string>();
    private List<bool> isBlanked = new List<bool>();

    public void SetOriginalText(string text)
    {
        originalWords = new List<string>();
        isBlanked = new List<bool>();

        // Splits by words and punctuation
        MatchCollection matches = Regex.Matches(text, @"\w+|[^\w\s]");
        foreach (Match match in matches)
        {
            originalWords.Add(match.Value);
            isBlanked.Add(false);
        }
    }

    public List<int> GetUnblankedIndexes()
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < isBlanked.Count; i++)
        {
            if (!isBlanked[i])
            {
                indexes.Add(i);
            }
        }
        return indexes;
    }

    public void BlankWordAt(int index)
    {
        isBlanked[index] = true;
    }

    public bool AllWordsBlanked()
    {
        return !isBlanked.Contains(false);
    }

    public string GetDisplayText()
    {
        List<string> display = new List<string>();

        for (int i = 0; i < originalWords.Count; i++)
        {
            if (isBlanked[i])
            {
                display.Add(new string('_', originalWords[i].Length));
            }
            else
            {
                display.Add(originalWords[i]);
            }
        }

        return string.Join(" ", display);
    }

    public int WordCount => originalWords.Count;
}
