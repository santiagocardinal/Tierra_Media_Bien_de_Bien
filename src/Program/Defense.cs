namespace Program;

public class Defense : Spell
{
    private int defenseValue;
    
    public Defense(string spellName, int defenseValue):base(spellName)
    {
        this.defenseValue = defenseValue;
    }
}