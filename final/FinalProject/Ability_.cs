using System;

public static class Abilities
{
    private static DiceRoller roller = new DiceRoller();

    public static void UseFirebolt(Character user, Character target)
    {
        int attackRoll = roller.Roll("1d20", user.GetMod(user.GetInt()));
        Console.WriteLine($"{user.GetType().Name} casts Firebolt and rolls a {attackRoll} to hit!");

        if (attackRoll >= target.AC)
        {
            int damage = roller.Roll("2d6", user.GetMod(user.GetInt()));
            target.HP -= damage;
            Console.WriteLine($"The Firebolt hits and deals {damage} fire damage to {target.GetType().Name}!");
        }
        else
        {
            Console.WriteLine("The Firebolt misses!");
        }
    }

    public static void UseHeal(Character user, Character target)
    {
        int healing = roller.Roll("2d4", user.GetMod(user.GetWis()));
        target.HP += healing;
        Console.WriteLine($"{user.GetType().Name} casts Heal and restores {healing} HP to {target.GetType().Name}.");
    }
}
