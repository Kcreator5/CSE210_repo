
public class Player : Character
{
    public string Name { get; private set; }

    private DiceRoller roller = new DiceRoller();
    public Player(int _str, int _dex, int _con, int _int, int _wis, int _cha)
        : base(_str, _dex, _con, _int, _wis, _cha)
    {
    }

    /*
    public void DisplayStats()
    {
        Console.WriteLine("=== Player Stats ===");
        Console.WriteLine($"HP: {HP}");
        Console.WriteLine($"AC: {AC}");
        Console.WriteLine($"STR: {GetStr()} (mod + {GetMod(GetStr())})");
        Console.WriteLine($"DEX: {GetDex()} (mod + {GetMod(GetDex())})");
        Console.WriteLine($"CON: {GetCon()} (mod + {GetMod(GetCon())})");
        Console.WriteLine($"INT: {GetInt()} (mod + {GetMod(GetInt())})");
        Console.WriteLine($"WIS: {GetWis()} (mod + {GetMod(GetWis())})");
        Console.WriteLine($"CHA: {GetCha()} (mod + {GetMod(GetCha())})");
    }
    */
    public int Melee_()
    {
        // 1d4 + Str modifier
        int damage = roller.Roll("1d4", GetMod(GetStr()));
        Console.WriteLine($"{Name} dose a melle attack for {damage} damage!");
        return damage;
    }

    public int Ranged_()
    {
        // 1d8 + Dex modifier
        int damage = roller.Roll("1d8", GetMod(GetDex()));
        Console.WriteLine($"{Name} dose a ranged attack for {damage} damage!");
        return damage;
    }

    public override void Describe()
    {
        DisplayStats();
        Console.WriteLine("I'm here to override that emtpy void and recive all those stats. I am the player.");
    }

}
