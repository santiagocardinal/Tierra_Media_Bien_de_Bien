namespace Program;

public class Sword
{
    private int attackValue;
    
    public int AttackValue
    {
        get { return attackValue; }
        set { attackValue = value; }
    }
    
    public Sword(int attackValue)
    {
        this.AttackValue = attackValue;
    }
    
    public int GetAttackValue()
    {
        return this.AttackValue;
    }    

}
