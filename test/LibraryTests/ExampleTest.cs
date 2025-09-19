using NUnit.Framework;
using Program;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    // ---------------- ITEM ----------------
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            var sword = new Item("Espada", 10, 5);

            Assert.That(sword.NameItem, Is.EqualTo("Espada"));
            Assert.That(sword.AttackValue, Is.EqualTo(10));
            Assert.That(sword.DefenseValue, Is.EqualTo(5));
        }

        [Test]
        public void Properties_ShouldBeMutable()
        {
            var shield = new Item("Escudo", 5, 8);

            shield.NameItem = "Mega Escudo";
            shield.AttackValue = 20;
            shield.DefenseValue = 30;

            Assert.That(shield.NameItem, Is.EqualTo("Mega Escudo"));
            Assert.That(shield.AttackValue, Is.EqualTo(20));
            Assert.That(shield.DefenseValue, Is.EqualTo(30));
        }
    }

    // ---------------- ELF ----------------
    [TestFixture]
    public class ElfTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            var item = new Item ("espada", 15 , 0);
            var elf = new Elf("Legolas");
            
            Assert.That(elf.Element, Is.Empty);
            elf.AddItem(item);
            Assert.That(elf.Name, Is.EqualTo("Legolas"));
            Assert.That(elf.AmountLife, Is.EqualTo(50));
        }

        [Test]
        public void AmountLife_ShouldBeMutable()
        {
            var item = new Item ("tunica", 0 , 15);
            var elf = new Elf("Legolas");
            elf.AddItem(item);

            Assert.That(elf.AmountLife, Is.EqualTo(65));
        }
    }

    // ---------------- DWARF ----------------
    [TestFixture]
    public class DwarfTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            var dwarf = new Dwarf("Gimli");

            Assert.That(dwarf.Name, Is.EqualTo("Gimli"));
            Assert.That(dwarf.Element, Is.Empty);
            Assert.That(dwarf.AmountLife, Is.EqualTo(50));
        }

        [Test]
        public void AmountLife_ShouldBeMutable()
        {
            var item = new Item ("tunica", 0 , 15);
            var dwarf = new Dwarf("Gimli");

            dwarf.AmountLife = 30;

            Assert.That(dwarf.AmountLife, Is.EqualTo(30));
        }
    }

    // ---------------- WIZARD ----------------
    [TestFixture]
    public class WizardTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            var spell = new Spell("Fuego", 25);
            var spellBook = new SpellBook();
            spellBook.AddSpell(spell);
            var wizard = new Wizard("Gandalf", spellBook);

            Assert.That(wizard.Name, Is.EqualTo("Gandalf"));
            Assert.That(wizard.LstElement, Is.Empty);
            Assert.That(wizard.SpellBook, Is.Not.Null);
        }

        [Test]
        public void AmountLife_ShouldBeMutable()
        {
            var spell = new Spell("ice", 15);
            var spellBook = new SpellBook();
            var item = new Item("tunica", 0, 5);
            var wizard = new Wizard("Gandalf", spellBook);
            wizard.AddItem(item);

            Assert.That(wizard.AmountLife, Is.EqualTo(55));
        }
    }

    // ---------------- SPELLBOOK ----------------
    [TestFixture]
    public class SpellBookTests
    {
        [Test]
        public void Constructor_ShouldInitializeEmptySpellsList()
        {
            var spellBook = new SpellBook();

            Assert.That(spellBook.Spell, Is.Not.Null);
            Assert.That(spellBook.Spell, Is.Empty);
        }

        [Test]
        public void AddSpell_ShouldIncreaseSpellsCount()
        {
            var spell = new Spell("Fuego", 25);
            var spellBook = new SpellBook();
            spellBook.AddSpell(spell);

            Assert.That(spellBook.Spell.Count, Is.EqualTo(1));
            Assert.That(spellBook.Spell.First().SpellName, Is.EqualTo("Fuego"));
        }
    }

    // ---------------- SPELL ----------------
    [TestFixture]
    public class SpellTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            var fireball = new Spell("Bola de fuego", 30);

            Assert.That(fireball.SpellName, Is.EqualTo("Bola de fuego"));
            Assert.That(fireball.Poder, Is.EqualTo(30));
        }

        [Test]
        public void Properties_ShouldBeMutable()
        {
            var ice = new Spell("Hielo", 15);

            ice.SpellName = "Super Hielo";
            ice.Poder = 50;

            Assert.That(ice.SpellName, Is.EqualTo("Super Hielo"));
            Assert.That(ice.Poder, Is.EqualTo(50));
        }
    }
}
