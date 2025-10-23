using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class WitchTests
    {
        [Test]
        public void AddSpellBook_ShouldAssignSpellBook_3()
        {
            // Arrange
            var witch = new Witch("Morgana", 100, 100, 0);
            var spellBook = new SpellBook("Hechizo de oscuridad");

            // Act
            witch.AddSpellBook(spellBook);

            // Assert
            Assert.That(witch.SpellBook, Is.EqualTo(spellBook));
        }

        [Test]
        public void Attack_WithAttackSpell_ShouldReduceGoodGuyLife_3()
        {
            // Arrange
            var witch = new Witch("Lilith", 100, 100, 0);
            var goodGuy = new Wizard("Merlin", 80, 80); 
            var spell = new Attack("Dark Fire", 20);

            // Act
            witch.Attack(goodGuy, spell);
        }
    }
}