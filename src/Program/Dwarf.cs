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

    public Dwarf(string name, List<Item> element)
    {
        this.Name = name;
        this.Element = element ?? new List<Item>();
        this.AmountLife = initialLife;
    }

    public void AddItem(Item element)
    {
        this.Element.Add(element);
        this.AmountLife += element.DefenseValue;
    }

    public void RemoveItem(Item element)
    {
        this.Element.Remove(element);
        this.AmountLife -= element.DefenseValue;
    }

    public void ExchangeItem(Item e1, Item e2)
    {
        int index = this.Element.IndexOf(e1);
        if (index != -1)
        {
            this.Element[index] = e2;
            this.AmountLife -= e1.DefenseValue;
            this.AmountLife += e2.DefenseValue;
        }
    }

    public void Heal()
    {
        this.AmountLife = initialLife;
    }

    /*public void DwarfElf(Elf elf)
    {
        foreach (var item in elf.Element)
        {
            this.AmountLife -= item.AttackValue;
        }
    }
    public void DwarfWizard(Wizard wizard)
    {
        foreach (var item in wizard.LstElement)
        {
            this.AmountLife -= item.AttackValue;
        }
    }
    public void DwarfDwarf(Dwarf dwarf)
    {
        foreach (var item in dwarf.Element)
        {
            this.AmountLife -= item.AttackValue;
        }
    }*/
}