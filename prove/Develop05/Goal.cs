using System;

public abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    // Called when the user records that they completed this goal.
    public abstract int RecordEvent();

    // Returns whether the goal is fully complete (optional for eternal goals).
    public abstract bool IsComplete();

    // Returns the status display string (e.g., [ ] Run 5 miles or [X] Read Book).
    public abstract string GetStatus();

    // Used for saving to file
    public abstract string Serialize();
}
