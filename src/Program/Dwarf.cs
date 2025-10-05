using System;
using System.Collections.Generic;

namespace Program
{
    public class Dwarf : ICharacter
    {
        // Aca menciono las ropiedades de ICharacter que ya habiamos escrito
        public string Name { get; private set; }
        public List<IItem> Element { get; set; }
        public int AmountLife { get; set; }
        public int InitialLife { get; set; }

       
        public Dwarf(string name, int initialLife)
        {
            Name = name;
            InitialLife = initialLife;
            AmountLife = initialLife;
            Element = new List<IItem>();
        }

        // Implemento lo de la interfaz IItem>
        public void AddItem(IItem item)
        {
            Element.Add(item); 
        }

        public void RemoveItem(IItem item)
        {
            Element.Remove(item);
        }

        
        // Implementación de ICharacter<Dwarf>
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
    }
}
