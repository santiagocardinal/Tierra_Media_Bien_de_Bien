namespace Program;
public class Cape : IDefenseItem
{
    // Implementación de IItem
    public string Name { get; set; }
    public int DefenseValue { get; set; }


    public Cape(string name, int defenseValue)
    {
        this.Name = name;
        this.DefenseValue = defenseValue;
    }
    
}
/*
public class Cape
{
    private int defenseValue;

    public int DefenseValue
    {
        get { return defenseValue; }
        set { defenseValue = value; }
    }

    public Cape(int attackValue)
    {
        this.DefenseValue = attackValue;
    }

    public int GetAttackValue()
    {
        return this.DefenseValue;
    }
}
*/