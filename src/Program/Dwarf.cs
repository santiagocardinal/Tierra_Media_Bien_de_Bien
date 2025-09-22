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
    
    public int GetDefense()
    {
        int defensa =0;
        foreach (var element in this.Element)
        {
            defensa += element.DefenseValue;
        }
        return defensa;
    }
    public int GetAttack()
    {
        int ataque = 0;
        foreach (var element in this.Element)
        {
            ataque += element.AttackValue;
        }
        return ataque;
    }
    public void Attack(Elf elf)
    {
        int defense = elf.GetDefense();
        int attack = this.GetAttack();
        
        elf.AmountLife -= (attack - defense);
    }
    public void Attack(Wizard wizard)
    {
        int defense = wizard.GetDefense();
        int attack = wizard.GetAttack();
        
        wizard.AmountLife -= (attack - defense);
    }
    public void Attack(Dwarf dwarf)
    {
        int defense = dwarf.GetDefense();
        int attack = this.GetAttack();
        
        dwarf.AmountLife -= (attack - defense);
    }
}