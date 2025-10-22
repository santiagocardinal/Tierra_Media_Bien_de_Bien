namespace Program;

public class Defense : Spell
{
    private int defenseValue;
    public int DefenseValue
    {
        get { return defenseValue;}
    }
    
    public Defense(string spellName, int defenseValue):base(spellName)
    {
        this.defenseValue = defenseValue;
    }
}