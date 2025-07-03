using System;
using System.IO;

public class Repeat
{
    public static void repeating_goal()
    {
        Console.Write("Enter the name of your repeating goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter the base point value per record: ");
        int points = int.Parse(Console.ReadLine());

        RepeatGoal goal = new RepeatGoal(name, desc, points);

        int earned = goal.RecordEvent();
        menu.points += earned;
        Console.WriteLine($"You earned {earned} points!");

        Save(goal);
    }

    private static void Save(RepeatGoal goal)
    {
        File.AppendAllText("Saved_goals.text", goal.Serialize() + "\n");
    }
}

public class RepeatGoal : Goal
{
    private int streakCount;
    private int basePoints;

    public RepeatGoal(string name, string description, int pointsPerRecord, int streak = 0)
        : base(name, description, pointsPerRecord)
    {
        streakCount = streak;
        basePoints = pointsPerRecord;
    }

    public override int RecordEvent()
    {
        streakCount++;
        return basePoints + (streakCount * 2); // Bonus scales with streak
    }

    public override bool IsComplete()
    {
        return false; // Eternal goal
    }

    public override string GetStatus()
    {
        return $"[∞] {Name} ({Description}) — Streak: {streakCount}";
    }

    public override string Serialize()
    {
        // Format: RepeatGoal|Name|Description|Points|Streak
        return $"RepeatGoal|{Name}|{Description}|{basePoints}|{streakCount}";
    }

    public static RepeatGoal Load(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        int streak = int.Parse(parts[4]);
        return new RepeatGoal(name, description, points, streak);
    }
}
