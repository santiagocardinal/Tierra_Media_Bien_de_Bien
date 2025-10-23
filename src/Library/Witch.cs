using System.Collections;

namespace Library;

public class Witch : BadGuy, IMagicCharacter
{
    public SpellBook SpellBook { get; set; }
    public Witch(string name, int amountLife, int initialLife, int vp) : base(name, amountLife, initialLife, vp)
    {
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }
    
    public void Attack(GoodGuy goodGuy, Spell spell)
    {
        // Verificar si el BadGuy está vivo antes de atacar
        /*if (badGuy.AmountLife <= 0)
        {
            return;
        }*/
        
        int damage = 0;
        
        // Obtener el daño del hechizo
        if (spell is Attack attack)
        {
            damage = attack.AttackValue;
            
            int totalDamage = damage - goodGuy.GetDefense();
        
            if (totalDamage > 0)
            {
                goodGuy.ReceiveDamage(totalDamage);
            }
            
            // Verificar si el BadGuy murió después del ataque
            if (goodGuy.AmountLife <= 0)
            {
                // El Wizard gana los VP del BadGuy derrotado
                this.VP += goodGuy.VP;
            
                // Si tiene más de 5 VP, se cura completamente
                if (this.VP > 5)
                {
                    this.Heal();
                }
            }
        }
        else if (spell is Defense defense)
        {
            this.AmountLife+= defense.DefenseValue;
        }
    }
    
    /*
    public void Attack(BadGuy badGuy, Spell spell)
    {
        int vida = badGuy.AmountLife + badGuy.GetDefense();
        if (spell is IAttackItem attackItem)
        {
            vida -= attackItem.AttackValue;
        }

        badGuy.AmountLife = vida;
    }
    */
    public void AddSpellBook(SpellBook spellBook)
    {
        this.SpellBook = spellBook;
    }
}