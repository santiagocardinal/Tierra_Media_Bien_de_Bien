using NUnit.Framework;
using Library;

namespace Library.Tests;

[TestFixture]
public class DefenseTest
{
    [Test]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Arrange
        string name = "Shield Spell";
        int defense = 50;

        // Act
        Defense defenseSpell = new Defense(name, defense);

        // Assert
        Assert.AreEqual(name, defenseSpell.SpellName);
        Assert.AreEqual(defense, defenseSpell.DefenseValue);
    }
}