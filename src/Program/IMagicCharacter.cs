namespace Program;

public interface  IMagicCharacter<T> : ICharacter<T>
{
    string Name { get; }
    List<IItem> Element { get; set; }
    int AmountLife { get; set; }
    int InitialLife { get; set; }

    void AddItem(IItem item);
    void RemoveItem(IItem item);
    void ExchangeItem(IItem item);
    void Attack(T opponent, IItem item);
    void Heal();
    void WizardAttackWithSpell(Spell spell,ICharacter<T> atacado);
}
/*
+ WizardAttackWithSpell(Spell, ICharacter) : void
*/