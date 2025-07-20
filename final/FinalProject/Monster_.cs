using System;

public class Monster : Character
{
    public string Name { get; private set; }

    private DiceRoller roller = new DiceRoller();

    public Monster(string name, int _str, int _dex, int _con, int _int, int _wis, int _cha)
        : base(_str, _dex, _con, _int, _wis, _cha)
    {
        Name = name;
    }

    public override void DisplayStats()
    {
        Console.WriteLine($"=== Monster: {Name} stats ===");
        Console.WriteLine($"Health points: {HP}");
        Console.WriteLine($"Armor class: {AC}");
        Console.WriteLine($"STR: {GetStr()} + {GetMod(GetStr())})");
        Console.WriteLine($"DEX: {GetDex()} + {GetMod(GetDex())})");
        Console.WriteLine($"CON: {GetCon()} + {GetMod(GetCon())})");
        // Console.WriteLine($"CON: {Getint()} (mod + {GetMod(Getint())})"); If I deside to impliment saving throws.
    }

    public int Melee_() // I honestly forgot I made these....
    {
        // Example: 1d8 + Str modifier
        int damage = roller.Roll("1d4", GetMod(GetStr()));
        Console.WriteLine($"{Name} dose a melle attack for {damage} damage!");
        return damage;
    }

    public int Ranged_()
    {
        //: 1d8 + Dex modifier
        int damage = roller.Roll("1d8", GetMod(GetDex()));
        Console.WriteLine($"{Name} dose a ranged attack for {damage} damage!");
        return damage;
    }
    
        public override void Describe()
    {
        DisplayStats();
        Console.WriteLine($"I am {Name}, a monster that also needs stats. I'm here to fight the player!");
    }

}
