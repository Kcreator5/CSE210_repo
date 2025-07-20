
using System;
using System.Text.RegularExpressions;

public class DiceRoller
{
    private Random rng = new Random();
    private Regex dicePattern = new Regex(@"^(\d+)d(\d+)$");

    // Rolls a string like "2d6" with optional modifier
    public int Roll(string expression, int modifier = 0)
    {
        Match match = dicePattern.Match(expression.ToLower().Trim());
        if (!match.Success)
            throw new ArgumentException($"Invalid dice expression: {expression}");

        int numDice = int.Parse(match.Groups[1].Value);
        int diceSides = int.Parse(match.Groups[2].Value);

        int total = 0;
        for (int i = 0; i < numDice; i++)
        {
            total += rng.Next(1, diceSides + 1);
        }

        return total + modifier;
    }

    // Rolls a single die (e.g., 1d20) with advantage
    public int RollAdv(int modifier = 0)
    {
        int roll1 = rng.Next(1, 21);
        int roll2 = rng.Next(1, 21);
        int result = Math.Max(roll1, roll2);
        return result + modifier;
    }

    // Rolls a single die (e.g., 1d20) with disadvantage
    public int RollDis(int modifier = 0)
    {
        int roll1 = rng.Next(1, 21);
        int roll2 = rng.Next(1, 21);
        int result = Math.Min(roll1, roll2);
        return result + modifier;
    }

    // Rolls a string like "2d6" and returns the number rolled.
    public int RollRaw(string expression, int modifier = 0)
    {
        return Roll(expression, modifier); // same logic, but for semantic clarity
    }
}

// DiceRoller roller = new DiceRoller();
// int attack = roller.Roll("2d6", 3);
// int save = roller.RollAdvantage(2);
// int stealth = roller.RollDisadvantage();

