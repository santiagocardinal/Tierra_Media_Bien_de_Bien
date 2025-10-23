namespace Library
{
    public class SpellBook 
    {
        public string Name { get; }
        private int AmountSpell { get; set; }
        private List<Spell> spell;

        public List<Spell> Spell
        {
            get { return spell; }
            set{spell = value; }
        }

        public SpellBook(string name)
        {
            this.Name = name;
            this.Spell = new List<Spell>();
        }
        public void AddSpell(Spell spell)
        {
            this.Spell.Add(spell);
            AmountSpell ++;
        }

        
    }
}