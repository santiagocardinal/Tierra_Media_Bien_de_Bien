using System;
using System.Collections.Generic;

namespace Program
{
    public class Elf : ICharacter
    {
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
        
        public void AddItem(IItem item)
        {
            Element.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            Element.Remove(item);
        }
        

        // Implementación de ICharacter<Elf>
        public void ExchangeItem(IItem e1, IItem e2)
        {
            // ejemplo simple: si ya existe lo quita, si no lo agrega
            /*if (items.Contains(item))
                RemoveItem(item);
            else
                AddItem(item);*/
            
            int indice = 0;
            foreach (var i in this.Element)
            {
                if (i == e1)
                {
                    indice = Element.IndexOf(i);
                }
            }

            this.Element[indice] = e2;
        }

        public void Attack(ICharacter opponent, IItem item)
        {
            int vida = opponent.AmountLife + opponent.GetDefense();
            if (item is IAttackItem attackItem)
            {
                vida -= attackItem.AttackValue;
            }
            opponent.AmountLife = vida;
        }

        public void Heal()
        {
            AmountLife = InitialLife;
        }

        public int GetDefense()
        {
            int defensa = 0;
            foreach (var item in Element)
            {
                if (item is IDefenseItem defenseItem)
                {
                    defensa += defenseItem.DefenseValue;
                }
            }
            return defensa;
        }

        public void ReceiveDamage(int damage)
        {
            AmountLife -= damage;
            if (AmountLife < 0)
                AmountLife = 0;
        }
    }
    
}

/*ublic int GetAttackValue()
        {
            int total = 0;
            foreach (var item in Element)
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
            foreach (var item in Element)
            {
                if (item is IDefenseValue defenseItem)
                {
                    total += defenseItem.GetDefenseValue();//LLAMO AL METODO DE LA INTERFAZ IDEFENSEVALUE
                }
            }
            return total;
        }*/

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