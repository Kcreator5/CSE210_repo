using System;
using System.IO;

public class _List
{
    public static void checklistgoal()
    {
        Console.Write("Enter the name of your checklist goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter the points for each step: ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("How many steps to complete it?: ");
        int target = int.Parse(Console.ReadLine());
        Console.Write("What’s the bonus when completed?: ");
        int bonus = int.Parse(Console.ReadLine());

        ChecklistGoal goal = new ChecklistGoal(name, desc, points, target, bonus);

        int earned = goal.RecordEvent();
        menu.points += earned;
        Console.WriteLine($"You earned {earned} points!");

        Save(goal);
    }

    private static void Save(ChecklistGoal goal)
    {
        File.AppendAllText("Saved_goals.text", goal.Serialize() + "\n");
    }
}


public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int progress = 0)
        : base(name, description, points)
    {
        targetCount = target;
        bonusPoints = bonus;
        currentCount = progress;
    }

    public override int RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            if (currentCount == targetCount)
            {
                return Points + bonusPoints;
            }
            return Points;
        }
        return 0; // Already completed
    }

    public override bool IsComplete()
    {
        return currentCount >= targetCount;
    }

    public override string GetStatus()
    {
        string check = IsComplete() ? "X" : " ";
        return $"[{check}] {Name} ({Description}) — Completed: {currentCount}/{targetCount}";
    }

    public override string Serialize()
    {
        // Format: ChecklistGoal|Name|Description|Points|TargetCount|Bonus|CurrentCount
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{targetCount}|{bonusPoints}|{currentCount}";
    }

    public static ChecklistGoal Load(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        int target = int.Parse(parts[4]);
        int bonus = int.Parse(parts[5]);
        int progress = int.Parse(parts[6]);
        return new ChecklistGoal(name, description, points, target, bonus, progress);
    }
}
