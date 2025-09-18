namespace Program
{
    public class SpellBook
    {
        private int AmountSpell { get; set; }
        private List<Spell> Spell { get; set; }

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