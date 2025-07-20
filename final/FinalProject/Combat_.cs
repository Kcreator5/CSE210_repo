using System;

public class Combat
{
    private Player player;
    private Monster monster;
    private DiceRoller roller = new DiceRoller();

    public Combat(Player player, Monster monster)
    {
        this.player = player;
        this.monster = monster;
    }

    public void StartBattle()
    {
        Console.Clear();
        Console.WriteLine("Without ferther adue!");
        Console.WriteLine("=== Combat Begins! ===");
        AsciiPrinter.Print();
        Console.WriteLine("Press enter too continue:");
        Console.ReadLine();

        while (player.HP > 0 && monster.HP > 0)
        {
            // PLAYER TURN
            Console.Clear();
            Console.WriteLine($"Your Health points: {player.HP}");
            Console.WriteLine($"Your Armor class: {player.AC}");
            Console.WriteLine("\nYour Turn! Choose an action:");
            Console.WriteLine($"[1] Melee Attack. +{player.GetMod(player.GetStr())} to hit, 1d4 + {player.GetMod(player.GetStr())} damage.");
            Console.WriteLine($"[2] Ranged Attack. +{player.GetMod(player.GetDex())} to hit, 1d10 + {player.GetMod(player.GetDex())} damage.");
            Console.WriteLine($"[3] Cast Firebolt (2d6 + {player.GetMod(player.GetInt())} )");
            Console.WriteLine($"[4] Cast Heal (2d4 + WIS mod)");
            Console.Write("Choice: ");
            string input = Console.ReadLine();

            int Attack_roll = 0;
            int Attack_total = 0;
            int Damage = 0;

            if (input == "1")
            {
                Attack_roll = roller.Roll("1d20");
                Attack_total = Attack_roll + player.GetMod(player.GetStr());
                Console.WriteLine($"You attack and rolled a {Attack_roll}, +{player.GetMod(player.GetStr())} = {Attack_total} to hit");

                if (Attack_roll >= monster.AC)
                {
                    Console.WriteLine("You Hit! :D");
                    Damage = roller.Roll("1d4", player.GetMod(player.GetStr()));
                    Console.WriteLine($"You strike with a melee hit for {Damage} damage!");
                    monster.HP -= Damage;
                }
                else Console.WriteLine("You miss... D:");
            }
            else if (input == "2")
            {
                Attack_roll = roller.Roll("1d20");
                Attack_total = Attack_roll + player.GetMod(player.GetDex());
                Console.WriteLine($"You attack and rolled a {Attack_roll}, +{player.GetMod(player.GetDex())} = {Attack_total} to hit");

                if (Attack_roll >= monster.AC)
                {
                    Console.WriteLine("You Hit! :D");
                    Damage = roller.Roll("1d10", player.GetMod(player.GetDex()));
                    Console.WriteLine($"You strike with a ranged hit for {Damage} damage!");
                    monster.HP -= Damage;
                }
                else Console.WriteLine("You miss... D:");
            }
            else if (input == "3")
            {
                Abilities.UseFirebolt(player, monster);
            }
            else if (input == "4")
            {
                Abilities.UseHeal(player, player);
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
                Console.ReadLine();
                continue;
            }

            Console.ReadLine();

            if (monster.HP <= 0)
            {
                Console.WriteLine($"{monster.Name} has been defeated! :D");
                Console.ReadLine();
                break;
            }

            Console.WriteLine($"{monster.Name} HP: {monster.HP}");

            // MONSTER TURN
            Console.WriteLine($"\n{monster.Name}'s turn!");
            int monster_choice = roller.Roll("1d2");
            int M_Attack_roll = 0;
            int M_Attack_total = 0;
            int M_Damage = 0;

            if (monster_choice == 1)
            {
                M_Attack_roll = roller.Roll("1d20");
                M_Attack_total = M_Attack_roll + monster.GetMod(monster.GetStr());
                Console.WriteLine($"{monster.Name} attacks and rolled a {M_Attack_roll}, + {monster.GetMod(monster.GetStr())}, with a total of {M_Attack_total} to Hit");

                if (M_Attack_roll >= player.AC)
                {
                    Console.WriteLine($"{monster.Name} hits you! D:");
                    M_Damage = roller.Roll("1d5", monster.GetMod(monster.GetStr()));
                    Console.WriteLine($"{monster.Name} strikes you with a melee hit for {M_Damage} damage!");
                    player.HP -= M_Damage;
                }
                else
                {
                    Console.WriteLine($"{monster.Name} misses you! :D");
                }
            }
            else if (monster_choice == 2)
            {
                M_Attack_roll = roller.Roll("1d20");
                M_Attack_total = M_Attack_roll + monster.GetMod(monster.GetDex());
                Console.WriteLine($"{monster.Name} attacks and rolled a {M_Attack_roll}, + {monster.GetMod(monster.GetDex())}, with a total of {M_Attack_total} to Hit");

                if (M_Attack_roll >= player.AC)
                {
                    Console.WriteLine($"{monster.Name} Hits! D:");
                    M_Damage = roller.Roll("1d10", monster.GetMod(monster.GetDex()));
                    Console.WriteLine($"{monster.Name} strikes you with a ranged hit for {M_Damage} damage!");
                    player.HP -= M_Damage;
                }
                else
                {
                    Console.WriteLine($"{monster.Name} missed you! :D");
                }
            }

            Console.ReadLine();

            if (player.HP <= 0)
            {
                Console.WriteLine("You have been defeated! D:");
                Console.ReadLine();
                break;
            }
        }

        Console.WriteLine("\n=== Combat Ends ===");
    }
}
