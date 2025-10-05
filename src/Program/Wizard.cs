using System.Collections;

namespace Program;

public class Wizard : IMagicCharacter
{
    public string Name { get; set; }
    public List<IItem> Element { get; set; }
    public int AmountLife { get; set; }
    public int InitialLife { get; set; }

    public Wizard(string name, int amountLife, int initialLife)
    {
        Name = name;
        AmountLife = amountLife;
        InitialLife = initialLife;
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

    public void ExchangeItem(IItem e1, IItem e2)
    {
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
        this.AmountLife = this.InitialLife;
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

    public void WizardAttackWithSpell(Spell spell, ICharacter atacado)
    {
        SpellBook spellBook = null;

        foreach (var item in Element)
        {
            if (item is SpellBook book)
            {
                spellBook = book;
            }
        }

        int vidaConDefensa = atacado.AmountLife + atacado.GetDefense();
        atacado.AmountLife = vidaConDefensa - spell.Poder;
    }
}



