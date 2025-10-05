namespace Program;

public interface  IMagicCharacter : ICharacter
{
    void WizardAttackWithSpell(Spell spell,ICharacter atacado);
}