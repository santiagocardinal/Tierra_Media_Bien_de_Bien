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

    public int GetDefense()
    {
        int defensa =0;
        foreach (var element in this.LstElement)
        {
            defensa += element.DefenseValue;
        }
        return defensa;
    }
    public int GetAttack()
    {
        int ataque = 0;
        foreach (var element in this.LstElement)
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

    public void Attack(Dwarf dwarf)
    {
        int defense = dwarf.GetDefense();
        int attack = this.GetAttack();
        
        dwarf.AmountLife -= (attack - defense);
    }

    public void Attack(Wizard wizard)
    {
        int defense = wizard.GetDefense();
        int attack = this.GetAttack();
        
        wizard.AmountLife -= (attack - defense);
    }
    public void WizardAttackWithSpell(Elf elf, Spell spell)
    {
        if (this.SpellBook.Spell.Contains(spell))
        {
            int defense = elf.GetDefense();

            int damage = spell.Poder - defense;
            if (damage < 0) damage = 0; // nunca hace "curar" al enemigo

            elf.AmountLife -= damage;
        }
    }

    public void WizardAttackWithSpell(Dwarf dwarf, Spell spell)
    {
        if (this.SpellBook.Spell.Contains(spell))
        {
            int defense = dwarf.GetDefense();

            int damage = spell.Poder - defense;
            if (damage < 0) damage = 0; // nunca hace "curar" al enemigo

            dwarf.AmountLife -= damage;
        }
    }

    public void WizardAttackWithSpell(Wizard wizard, Spell spell)
    {
        if (this.SpellBook.Spell.Contains(spell))
        {
            int defense = wizard.GetDefense();

            int damage = spell.Poder - defense;
            if (damage < 0) damage = 0; 

            wizard.AmountLife -= damage; 
            if (wizard.AmountLife < 0) wizard.AmountLife = 0; 
        }
    }
}

