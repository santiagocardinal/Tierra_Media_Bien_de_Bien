namespace Program;

public class Bow  : IAttackValue
{
    // Implementación de IItem
    public string Name { get; set; }
    public int Value { get; set; }

    private int attackValue;
    
    public int AttackValue
    {
        get { return attackValue; }
        set { attackValue = value; }
    }

    public Bow(string name, int value, int attackValue, int defenseValue)
    {
        this.Name = name;
        this.Value = value;
        this.AttackValue = attackValue;
    }
    
    public int GetAttackValue() //ME SALTABA CONQUE NO HABIA IMPLEMENTADO LA INTERFAZ PORQUE EN IATTACKVALUE PUSIMOS UN {GET; } Y NO VA UNA PROPIEDAD AHI, EN INTERFACES SOLO METODOS!
    {
        return this.AttackValue;
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