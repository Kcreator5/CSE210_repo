using System;

class ShuffleList
{
    private List<int> remaining_prompts;
    private Random rng = new Random();

    public ShuffleList(int count)
    {
        remaining_prompts = new List<int>();
        for (int i = 0; i < count; i++)
        {
            remaining_prompts.Add(i);
        }
    }

    public int GetNextIndex()
    {
        if (remaining_prompts.Count == 0)
        {
            // this reasets if all are used.
            for (int i = 0; i < remaining_prompts.Capacity; i++)
                remaining_prompts.Add(i);
        }

        int randIndex = rng.Next(remaining_prompts.Count);
        int value = remaining_prompts[randIndex];
        remaining_prompts.RemoveAt(randIndex);
        return value;
    }
}
