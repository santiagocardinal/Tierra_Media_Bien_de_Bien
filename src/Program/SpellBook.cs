namespace Program
{
    public class SpellBook
    {
        private int AmountSpell { get; set; }
        private List<Spell> spell;

        public List<Spell> Spell
        {
            get { return spell; }
            set{spell = value; }
        }

        public SpellBook()
        {
            this.Spell = new List<Spell>();
        }
        public void AddSpell(Spell spell)
        {
            this.Spell.Add(spell);
            AmountSpell ++;
        }
    }
}