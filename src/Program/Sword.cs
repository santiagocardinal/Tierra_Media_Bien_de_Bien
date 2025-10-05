namespace Program;

public class Sword: IAttackValue
{
    // Implementación de IItem
    public string Name { get; set; }
    public int Value { get; set; }

    // Propiedad AttackValue y DefenseValue
    private int attackValue;
    private int defenseValue;

    
    public int AttackValue
    {
        get { return attackValue; }
        set { attackValue = value; }
    }
    
    public int DefenseValue
    {
        get { return defenseValue; }
        set { defenseValue = value; }
    }

    
    public Sword(string name, int value, int attackValue, int defenseValue)
    {
        this.Name = name;
        this.Value = value;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
    }

    // Método GetAttackValue
    public int GetAttackValue() //ME SALTABA CONQUE NO HABIA IMPLEMENTADO LA INTERFAZ PORQUE EN IATTACKVALUE PUSIMOS UN {GET; } Y NO VA UNA PROPIEDAD AHI, EN INTERFACES SOLO METODOS!
    {
        return this.AttackValue;
    }
    
    public int GetDefenseValue()
    {
        return this.DefenseValue;
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