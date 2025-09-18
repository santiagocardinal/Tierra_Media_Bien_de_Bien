namespace Program
{
    class Spell
    {
        public string SpellName { get; set; }
        public int Poder { get; set; }

        public Spell(string spellName, int poder)
        {
            this.SpellName = spellName;
            this.Poder = poder;
        }
    }
}