namespace LibraryTests;

using Program;
using NUnit.Framework;

[TestFixture]
public class AttackTest
{
    [Test]
    public void Constructor_ShouldInitializeCorrectly()
    {
        string name = "Fireball";
        int attack = 70;

        Attack attackSpell = new Attack(name, attack);

        Assert.AreEqual(name, attackSpell.SpellName);
        Assert.AreEqual(attack, attackSpell.AttackValue);
    }
}