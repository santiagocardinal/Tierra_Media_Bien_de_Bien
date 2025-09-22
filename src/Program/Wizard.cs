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
    }

    public void RemoveItem(Item element)
    {
        this.LstElement.Remove(element);
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

    public void Attack(Dwarf dwarf)
    {
        int defense = GetDefense(dwarf.Element);
        int attack = GetAttack(dwarf.Element);
        
        dwarf.AmountLife -= (attack - defense);
    }

    public void Attack(Wizard wizard)
    {
        int defense = GetDefense(wizard.LstElement);
        int attack = GetAttack(wizard.LstElement);
        
        wizard.AmountLife -= (attack - defense);
    }
    public void WizardAttackWithSpell(Elf elf, Spell spell)
    {
        if (this.SpellBook.Spell.Contains(spell))
        {
            int defense = 0;
            foreach (var item in elf.Element)
            {
                defense += item.DefenseValue;
            }

            int damage = spell.Poder - defense;
            if (damage < 0) damage = 0; // nunca hace "curar" al enemigo

            elf.AmountLife -= damage;
        }
    }

    public void WizardAttackWithSpell(Dwarf dwarf, Spell spell)
    {
        if (this.SpellBook.Spell.Contains(spell))
        {
            int defense = 0;
            foreach (var item in dwarf.Element)
            {
                defense += item.DefenseValue;
            }

            int damage = spell.Poder - defense;
            if (damage < 0) damage = 0; // nunca hace "curar" al enemigo

            dwarf.AmountLife -= damage;
        }
    }

    public void WizardAttackWithSpell(Wizard wizard, Spell spell)
    {
        if (this.SpellBook.Spell.Contains(spell))
        {
            int defense = 0;
            foreach (var item in wizard.LstElement) // CORRECCIÓN
            {
                defense += item.DefenseValue;
            }

            int damage = spell.Poder - defense;
            if (damage < 0) damage = 0; // nunca hace "curar" al enemigo

            wizard.AmountLife -= damage; // <- punto y coma agregado
            if (wizard.AmountLife < 0) wizard.AmountLife = 0; // opcional, para no bajar de 0
        }
    }
}

