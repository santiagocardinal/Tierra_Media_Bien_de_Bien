using System.Collections;

namespace Program;

public class Wizard
{
    private List<Item> lstElement;
    private int amountLife;
    private string name;
    public static int initialLife { get; set; } = 50;
    private SpellBook spellBook;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public List<Item> LstElement
    {
        get { return lstElement; }
        set { lstElement = value; }

    }

    public int AmountLife
    {
        get { return amountLife; }
        set { amountLife = value; }
    }

    /*public int InitialLife
    {
        get { return InitialLife; }
        set { InitialLife = value; }
    }
*/
    public SpellBook SpellBook
    {
        get { return spellBook; }
        set { spellBook = value; }
    }
   
    public Wizard(string name, SpellBook book)
    {
        this.Name = name;
        this.LstElement = new List<Item>();
        this.AmountLife = initialLife;
        this.SpellBook = book;
    }

    public void AddItem(Item element)
    {
        this.LstElement.Add(element);
        this.AmountLife += element.DefenseValue;
    }

    public void RemoveItem(Item element)
    {
        this.LstElement.Remove(element);
        this.AmountLife -= element.DefenseValue;
    }

    public void ExchangeItem(Item e1, Item e2)
    {
        int indice = 0;
        foreach (var i in this.LstElement)
        {
            if (i == e1)
            {
                indice = LstElement.IndexOf(i);
            }
        }

        this.LstElement[indice] = e2;
    }

    public void GetAttack(Item element)
    {
        this.AmountLife-=element.AttackValue;
    }

    public void GetDefense(Item defense)
    {
        this.AmountLife+=defense.DefenseValue;
    }

    public void Heal()
    {
        this.AmountLife = initialLife;
    }

    /*public void AddSpell(SpellBook book)
    {
        
    }*/
    
    public void WizardElf(Elf elf)
    {
        foreach (var item in elf.Element)
        {
            this.AmountLife -= item.AttackValue;
        }
    }

    public void WizardDwarf(Dwarf dwarf)
    {
        foreach (var item in dwarf.Element)
        {
            this.AmountLife -= item.AttackValue;
        }
    }

    public void WizardWizard(Wizard wizard)
    {
        foreach (var item in wizard.LstElement)
        {
            this.AmountLife -= item.AttackValue;
        }
    }
}
