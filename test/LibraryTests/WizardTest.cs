using NUnit.Framework;

namespace Program.Tests
{
    [TestFixture]
    public class WizardTests
    {
        [Test]
        public void AddSpellBook_ShouldAssignSpellBook()
        {
            // Arrange
            var wizard = new Wizard("Merlin", 100, 100);
            var spellBook = new SpellBook("Bola de fuego");

            // Act
            wizard.AddSpellBook(spellBook);

            // Assert
            Assert.That(wizard.SpellBook, Is.EqualTo(spellBook));
        }

        [Test]
        public void Attack_WithAttackSpell_ShouldReduceBadGuyLife()
        {
            // Arrange
            var wizard = new Wizard("Gandalf", 100, 100);
            var badGuy = new BadGuy("Orc", 50, 50, 2);
            var spell = new Attack("Fireball", 20); 

            // Act
            wizard.Attack(badGuy, spell);

            // Assert
            Assert.That(badGuy.AmountLife, Is.LessThan(50)); 
        }

        [Test]
        public void Attack_WithDefenseSpell_ShouldIncreaseWizardLife()
        {
            // Arrange
            var wizard = new Wizard("Gandalf", 50, 100);
            var badGuy = new BadGuy("Orc", 50, 50, 2);
            var spell = new Defense("Shield", 30); 

            // Act
            wizard.Attack(badGuy, spell);

            // Assert
            Assert.That(wizard.AmountLife, Is.EqualTo(80));
        }

        [Test]
        public void Attack_ShouldGiveVP_WhenBadGuyDies()
        {
            // Arrange
            var wizard = new Wizard("Gandalf", 100, 100);
            var badGuy = new BadGuy("Orc", 10, 10, 3);
            var spell = new Attack("Fireball", 20);

            // Act
            wizard.Attack(badGuy, spell);

            // Assert
            Assert.That(badGuy.IsAlive(), Is.False);
            Assert.That(wizard.VP, Is.EqualTo(3));
        }

        [Test]
        public void Attack_ShouldHeal_WhenVPExceedsFive()
        {
            // Arrange
            var wizard = new Wizard("Gandalf", 60, 100); 
            var badGuy = new BadGuy("Orc", 10, 10, 6); 
            var spell = new Attack("Fireball", 20);

            // Act
            wizard.Attack(badGuy, spell);

            // Assert
            Assert.That(wizard.AmountLife, Is.EqualTo(100)); 
        }

        [Test]
        public void Attack_ShouldNotDamage_WhenDefenseIsHigherThanAttack()
        {
            // Arrange
            var wizard = new Wizard("Gandalf", 100, 100);
            var badGuy = new BadGuy("Troll", 50, 50, 2);

            // Mock de defensa alta
            badGuy.AddItem(new Cape("Capa de invisibilidad", 100)); 
            var spell = new Attack("Weak Spell", 10);

            // Act
            wizard.Attack(badGuy, spell);

            // Assert
            Assert.That(badGuy.AmountLife, Is.EqualTo(50)); 
        }
    }
}
