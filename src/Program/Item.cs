namespace Program;

public class Item
{
    private string nameItem;
    private int attackValue;
    private int defenseValue;

    public string NameItem
    {
        get { return nameItem; }
        set { nameItem = value; }
    }

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

    public Item(string nameItem, int attackValue, int defenseValue)
    {
        this.NameItem = nameItem;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
    }
}