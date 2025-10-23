using NUnit.Framework;
using Library;

namespace Library.Tests;

[TestFixture]
public class SpellTest
{
    //Al ser Spel abstracta, mo se testea la clase en sí, sino el comportamiento que se define para esta
    private class TestSpell : Spell
    {
        public TestSpell(string spellName) : base(spellName) { }
    }

    [Test]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Arrange
        string name = "Magical Wisdom";

        // Act
        TestSpell spell = new TestSpell(name);

        // Assert
        Assert.AreEqual(name, spell.SpellName);
    }
}