namespace Program;

public class GoodGuy : Character
{
    public int VP { get; set; }

    public GoodGuy(string name, int amountLife, int initialLife): base(name,amountLife,initialLife)
    {
        this.VP = 0;
    }
    
    public override void Attack()
    {
        throw new NotImplementedException();
    }

    // Sobrecarga: nuevo método con misma firma base + parámetros diferentes
    public void Attack(BadGuy badGuy)
    {
        // Verificar si el BadGuy está vivo antes de atacar
        /*if (badGuy.AmountLife <= 0)
        {
            return;
        }*/
        
        int damage = 0;
        
        // Calcular daño total de todos los items de ataque
        foreach (var item in Element)
        {
            if (item is IAttackItem attackItem)
            {
                damage += attackItem.AttackValue;
            }
        }
        
        // Aplicar daño considerando la defensa del oponente
        int totalDamage = damage - badGuy.GetDefense();
        if (totalDamage > 0)
        {
            badGuy.ReceiveDamage(totalDamage);
        }
        
        // Verificar si el BadGuy murió después del ataque
        if (badGuy.AmountLife <= 0)
        {
            // El GoodGuy gana los VP del BadGuy derrotado
            this.VP += badGuy.GiveVp();
            
            // Si tiene más de 5 VP, se cura completamente
            if (this.VP > 5)
            {
                this.Heal();
            }
        }
    }
    

    
}
