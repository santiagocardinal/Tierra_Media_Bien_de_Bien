namespace Program;

public class Bow
{
    private int attackValue;
    
    public int AttackValue
    {
        get { return attackValue; }
        set { attackValue = value; }
    }
    
    public Bow(int attackValue)
    {
        this.AttackValue = attackValue;
    }
    
    public int GetAttackValue()
    {
        return this.AttackValue;
    }    

}
