namespace Program;

public class Elf
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

    //public int VidaInicial{ get {return vidaInicial;} set { vidaInicial = value; } }

    public Elf(string name)
    {
        this.Name = name;
        this.Element  = new List<Item>();
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
    
    //public void GetDefense(Element defense)
    //{
     //   this.AmountLife += defense.Defense;
    //}

    public void Heal()
    {
        this.AmountLife = initialLife;
    }
    

    public void Attack(Dwarf dwarf)
    {
        foreach (var item in dwarf.Element)
        {
            this.AmountLife -= item.AttackValue;
        }
    }
    
    public void Attack(Wizard wizard)
    {
        int defense = 0;
        
        foreach (var item in wizard.LstElement)
            
            
        {
            
            defense += item.DefenseValue;
        }
        int damage = 0;
        
        foreach (var item in this.Element)
            
        {
            damage += item.AttackValue;
        }
        
        wizard.AmountLife = AmountLife + defense - damage;
    }
    public void Attack(Elf elf)
    {
        foreach (var item in elf.Element)
        {
            this.AmountLife -= item.AttackValue;
        }
    }
}
