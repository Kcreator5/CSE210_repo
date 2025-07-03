using System;
using System.IO;
using System.Collections.Generic;

public class loading
{
    private static string saveFile = "Saved_goals.text";

    public static void load()
    {
        if (!File.Exists(saveFile))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();
        string[] lines = File.ReadAllLines(saveFile);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            string type = parts[0];

            Goal goal = type switch
            {
                "SimpleGoal" => SimpleGoal.Load(parts),
                "RepeatGoal" => RepeatGoal.Load(parts),
                "ChecklistGoal" => ChecklistGoal.Load(parts),
                _ => null
            };

            if (goal != null)
            {
                loadedGoals.Add(goal);
            }
        }

        if (loadedGoals.Count == 0)
        {
            Console.WriteLine("No valid goals found in file.");
            return;
        }

        Console.WriteLine("\nLoaded Goals:");
        for (int i = 0; i < loadedGoals.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {loadedGoals[i].GetStatus()}");
        }

        Console.Write("\nWhich goal did you accomplish? (Enter number or press Enter to cancel): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int choice) && choice > 0 && choice <= loadedGoals.Count)
        {
            int earned = loadedGoals[choice - 1].RecordEvent();
            menu.points += earned;

            Console.WriteLine($"You earned {earned} points!");
            Console.WriteLine($"Total points: {menu.points}");

            SaveGoals(loadedGoals);
        }
        else
        {
            Console.WriteLine("No goal recorded.");
        }
    }

    private static void SaveGoals(List<Goal> goals)
    {
        using (StreamWriter writer = new StreamWriter(saveFile))
        {
            foreach (Goal g in goals)
            {
                writer.WriteLine(g.Serialize());
            }
        }
    }
}
