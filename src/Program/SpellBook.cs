namespace Program
{
    class SpellBook
    {
        private int AmountSpell { get; set; }
        private List<Spell> Spell { get; set; }

        public SpellBook(int amountSpell, List<Spell> spellList)
        {
            this.Spell = spellList;
            this.AmountSpell = amountSpell;
        }
    }
}