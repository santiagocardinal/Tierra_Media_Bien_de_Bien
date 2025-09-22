namespace Program;

public class Dwarf
{
    private string name;
    private List<Item> element;
    private int amountLife;
    public static int initialLife { get; set; } = 50;


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Item> Element
    {
        get { return element; }
        set { element = value; }
    }

    public int AmountLife
    {
        get { return amountLife; }
        set { amountLife = value; }
    }

    public Dwarf(string name)
    {
        this.Name = name;
        this.Element = new List<Item>();
        this.AmountLife = initialLife;
    }

    public void AddItem(Item element)
    {
        this.Element.Add(element);
    }

    public void RemoveItem(Item element)
    {
        this.Element.Remove(element);
    }

    public void ExchangeItem(Item e1, Item e2)
    {
        int index = this.Element.IndexOf(e1);
        if (index != -1)
        {
            this.Element[index] = e2;
  
        }
    }

    public void Heal()
    {
        this.AmountLife = initialLife;
    }
    
    public int GetDefense(List<Item> defense)
    {
        int defensa =0;
        foreach (var element in defense)
        {
            defensa += element.DefenseValue;
        }
        return defensa;
    }
    public int GetAttack(List<Item> defense)
    {
        int defensa =0;
        foreach (var element in defense)
        {
            defensa += element.AttackValue;
        }
        return defensa;
    }
    public void Attack(Elf elf)
    {
        int defense = GetDefense(elf.Element);
        int attack = GetAttack(elf.Element);
        
        elf.AmountLife -= (attack - defense);
    }
    public void Attack(Wizard wizard)
    {
        int defense = GetDefense(wizard.LstElement);
        int attack = GetAttack(wizard.LstElement);
        
        wizard.AmountLife -= (attack - defense);
    }
    public void Attack(Dwarf dwarf)
    {
        int defense = GetDefense(dwarf.Element);
        int attack = GetAttack(dwarf.Element);
        
        dwarf.AmountLife -= (attack - defense);
    }
}