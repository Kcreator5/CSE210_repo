using System;
using System.IO;

public class Simple
{
    public static void simplegoal()
    {
        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter the number of points: ");
        int points = int.Parse(Console.ReadLine());

        SimpleGoal goal = new SimpleGoal(name, desc, points);

        int earned = goal.RecordEvent();
        menu.points += earned;
        Console.WriteLine($"You earned {earned} points!");

        Save(goal);
    }

    private static void Save(SimpleGoal goal)
    {
        File.AppendAllText("Saved_goals.text", goal.Serialize() + "\n");
    }
}

public class SimpleGoal : Goal
{


    private bool completed;

    public SimpleGoal(string name, string description, int points, bool isCompleted = false)
        : base(name, description, points)
    {
        completed = isCompleted;
    }

    public override int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return Points; // Give full points when completed
        }
        return 0; // No points if already completed
    }

    public override bool IsComplete()
    {
        return completed;
    }

    public override string GetStatus()
    {
        return $"[{(completed ? "X" : " ")}] {Name} ({Description})";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{completed}";
    }

    // Optionally: a static loader for deserialization
    public static SimpleGoal Load(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isCompleted = bool.Parse(parts[4]);
        return new SimpleGoal(name, description, points, isCompleted);
    }
}
