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