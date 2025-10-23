namespace Library;

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
