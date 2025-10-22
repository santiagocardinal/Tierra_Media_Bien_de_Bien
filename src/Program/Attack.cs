namespace Program;

public class Attack : Spell
{
    private int attackValue;
    
    public Attack(string spellName, int attackValue):base(spellName)
    {
        this.attackValue = attackValue;
    }
}
