using System;
using System.Collections.Generic;

namespace Program
{
    public class Elf : ICharacter<Elf>, IInventory<IItem> //LLAMO A LAS INTEFACES ICharacter y le pongo en T el tipo Dwarf, tambien llamo a IInventory que viene con la interfaz IItem implementada
    {
        // Atributos privados
        private List<IItem> items = new List<IItem>();

        // Aca menciono las ropiedades de ICharacter que ya habiamos escrito
        public string Name { get; private set; }
        public List<IItem> Element { get; set; }
        public int AmountLife { get; set; }
        public int InitialLife { get; set; }

       
        public Elf(string name, int initialLife)
        {
            Name = name;
            InitialLife = initialLife;
            AmountLife = initialLife;
            Element = new List<IItem>();
        }

        // Implemento lo de la interfaz IInventory<IItem>
        public void AddItem(IItem item)
        {
            items.Add(item);
            Element.Add(item); // sincronizamos ambas listas ESTO LO HIZO CHAT NO ME SALIA :(
        }

        public void RemoveItem(IItem item)
        {
            items.Remove(item);
            Element.Remove(item);
        }

        public List<IItem> GetItems()
        {
            return new List<IItem>(items);
        }

        public int GetAttackValue()
        {
            int total = 0;
            foreach (var item in items)
            {
                if (item is IAttackValue attackItem)
                {
                    total += attackItem.GetAttackValue(); //LLAMO AL METODO DE LA INTERFAZ IATTACKVALUE
                }
            }
            return total;
        }

        public int GetDefenseValue()
        {
            int total = 0;
            foreach (var item in items)
            {
                if (item is IDefenseValue defenseItem)
                {
                    total += defenseItem.GetDefenseValue();//LLAMO AL METODO DE LA INTERFAZ IDEFENSEVALUE
                }
            }
            return total;
        }

        // Implementación de ICharacter<Elf>
        public void ExchangeItem(IItem item)
        {
            // ejemplo simple: si ya existe lo quita, si no lo agrega
            if (items.Contains(item))
                RemoveItem(item);
            else
                AddItem(item);
        }

        public void Attack(Elf opponent, IItem item)
        {
            if (items.Contains(item) && item is IAttackValue attackValue)
            {
                int damage = attackValue.GetAttackValue() - opponent.GetDefenseValue();
                if (damage < 0) damage = 0;
                opponent.ReceiveDamage(damage);
            }
        }

        public void Heal()
        {
            AmountLife = InitialLife;
        }

        public void ReceiveDamage(int damage)
        {
            AmountLife -= damage;
            if (AmountLife < 0)
                AmountLife = 0;
        }
    }
}

/*namespace Program;
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

    public void Heal()
    {
        this.AmountLife = initialLife;
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
    public void Attack(Elf elf)
    {
        int defense = elf.GetDefense();
        int attack = this.GetAttack();
        
        elf.AmountLife -= (attack - defense);
    }
}
*/