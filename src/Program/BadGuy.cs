namespace Program;

public class BadGuy : Character
{
    public int VP { get; set; }

    public BadGuy(string name, int amountLife, int initialLife,int vp): base(name,amountLife,initialLife)
    {
        this.VP = vp;
    }

    public void GiveVp(int vp)
    {
        this.VP += vp;
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }
    public void Attack(GoodGuy goodGuy)
    {
        // Verificar si el GoodGuy está vivo antes de atacar
        /*if (goodGuy.AmountLife <= 0)
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
        int totalDamage = damage - goodGuy.GetDefense();
        if (totalDamage > 0)
        {
            goodGuy.ReceiveDamage(totalDamage);
        }
    }
}
