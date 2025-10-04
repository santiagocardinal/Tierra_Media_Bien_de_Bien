namespace Program;

public class Cape
{
    private int defenseValue;
    
    public int DefenseValue
    {
        get { return defenseValue; }
        set { defenseValue = value; }
    }
    
    public Cape(int attackValue)
    {
        this.DefenseValue = attackValue;
    }
    
    public int GetAttackValue()
    {
        return this.DefenseValue;
    }
}
