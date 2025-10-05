namespace Program;
public class Cape : IDefenseValue
{
    // Implementación de IItem
    public string Name { get; set; }
    public int Value { get; set; }

    // Propiedad DefenseValue
    private int defenseValue;

    public int DefenseValue
    {
        get { return defenseValue; }
        set { defenseValue = value; }
    }

    public Cape(string name, int value, int defenseValue)
    {
        this.Name = name;
        this.Value = value;
        this.DefenseValue = defenseValue;
    }

    // Método GetAttackValue
    public int GetDefenseValue()
    {
        return this.DefenseValue;
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