// Character.cs
public abstract class Character
{
    private int strength;
    private int dexterity;
    private int constitution;
    private int intelligence;
    private int wisdom;
    private int charisma;

    public int level = 1;

    public int HP { get; set; }
    public int AC { get; set; }

    public Character(int _str, int _dex, int _con, int _int, int _wis, int _cha)
    {
        strength = _str;
        dexterity = _dex;
        constitution = _con;
        intelligence = _int;
        wisdom = _wis;
        charisma = _cha;


        HP = (10 + GetMod(constitution)) * level;
        AC = 10 + GetMod(dexterity);
    }

    // Public method to get ability modifier
    public int GetMod(int score)
    {
        return (score - 10) / 2;
    }

    public virtual void DisplayStats()
    {
        Console.WriteLine("=== Player Stats ===");
        Console.WriteLine($"Health points: {HP}");
        Console.WriteLine($"Armor class: {AC}");
        Console.WriteLine($"STR: {GetStr()}. + {GetMod(GetStr())})");
        Console.WriteLine($"DEX: {GetDex()}. + {GetMod(GetDex())})");
        Console.WriteLine($"CON: {GetCon()}. + {GetMod(GetCon())})");
        Console.WriteLine($"INT: {GetInt()}. + {GetMod(GetInt())})");
        Console.WriteLine($"WIS: {GetWis()}. + {GetMod(GetWis())})");
        Console.WriteLine($"CHA: {GetCha()}. + {GetMod(GetCha())})");
    }

    // Other ways to get ability scores.
    public int GetStr() => strength;
    public int GetDex() => dexterity;
    public int GetCon() => constitution;
    public int GetInt() => intelligence;
    public int GetWis() => wisdom;
    public int GetCha() => charisma;

    public virtual void Describe()
    {
        DisplayStats();
        Console.WriteLine("I'm just a character. An empty hust waiting to be filled. I have stats I need to assine to someone or something.");
        
    }


}
