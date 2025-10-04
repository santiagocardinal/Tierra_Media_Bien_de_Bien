namespace Program;

public class Stick: IAttackValue
{
    private int attackValue;
    
    public int AttackValue
    {
        get { return attackValue; }
        set { attackValue = value; }
    }
    
    public Stick(int attackValue)
    {
        this.AttackValue = attackValue;
    }
    
    public int GetAttackValue()
    {
        return this.AttackValue;
    }    
    
}

