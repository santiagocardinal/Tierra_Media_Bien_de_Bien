namespace Program;

public class Sword: IAttackItem, IDefenseItem
{
    public string Name { get; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }

    public Sword(string name, int attackValue, int defenseValue)
    {
        this.Name = name;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
    }
}

/*
 
 
// Implementación de IItem
    public string Name { get; set; }
    public int Value { get; set; }

    // Ataque
    private int attackValue;
    public int GetAttackValue => attackValue;  // propiedad de solo lectura

    // Constructor
    public Sword(string name, int value, int attackValue)
    {
        this.Name = name;
        this.Value = value;
        this.attackValue = attackValue;
    }*/