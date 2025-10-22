using System.Collections;

namespace Program;

public class Wizard : GoodGuy
{
    public Wizard(string name, int amountLife, int initialLife, int vp) : base(name, amountLife, initialLife, vp)
    {
    }
    public void Attack(BadGuy badGuy, Spell spell)
    {
        // Verificar si el BadGuy está vivo antes de atacar
        if (badGuy.AmountLife <= 0)
        {
            return;
        }
        
        int damage = 0;
        
        // Obtener el daño del hechizo
        if (spell is IAttackItem attackItem)
        {
            damage = attackItem.AttackValue;
        }
        
        // Calcular daño total considerando la defensa del oponente
        int totalDamage = damage - badGuy.GetDefense();
        
        if (totalDamage > 0)
        {
            badGuy.ReceiveDamage(totalDamage);
        }
        
        // Verificar si el BadGuy murió después del ataque
        if (badGuy.AmountLife <= 0)
        {
            // El Wizard gana los VP del BadGuy derrotado
            this.VP += badGuy.VP;
            
            // Si tiene más de 5 VP, se cura completamente
            if (this.VP > 5)
            {
                this.Heal();
            }
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
}



