namespace Program;

public class Stick: IAttackItem
{
    public string Name { get; set; }
    public int AttackValue { get; set; }
    
    public Stick(string name, int attackValue)
    {
        this.Name = name;
        this.AttackValue = attackValue;
    }
}

