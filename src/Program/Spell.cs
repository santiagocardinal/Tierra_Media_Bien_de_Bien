namespace Program
{
    public abstract class Spell
    {
        public string SpellName { get; set; }
        
        public Spell(string spellName)
        {
            this.SpellName = spellName;
        }
    }
}