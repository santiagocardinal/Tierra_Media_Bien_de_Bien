namespace Program;

public class Bow  : IAttackItem
{
    // Implementación de IItem
    public string Name { get; set; }
    public int AttackValue { get; set; }
    

    public Bow(string name, int attackValue)
    {
        this.Name = name;
        this.AttackValue = attackValue;
    }
    
}

/* private int attackValue;

    public int AttackValue
    {
        get { return attackValue; }
        set { attackValue = value; }
    }

    public Bow(int attackValue)
    {
        this.AttackValue = attackValue;
    }

    public int GetAttackValue()
    {
        return this.AttackValue;
    }
    */ 