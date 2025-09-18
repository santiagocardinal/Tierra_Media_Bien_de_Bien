using NUnit.Framework;
using Program;
using System.Collections.Generic;

namespace LibraryTests
{
    public class Tests
    {
        private Item sword;
        private Item shield;
        private Elf elf;
        private Dwarf dwarf;
        private Wizard wizard;
        private Spell fireball;
        private Spell ice;
        private SpellBook spellBook;

        [SetUp]
        public void Setup()
        {
            // Ítems
            sword = new Item("Sword", 10, 5);
            shield = new Item("Shield", 3, 8);

            // Personajes
            elf = new Elf("Legolas");
            dwarf = new Dwarf("Gimli");
            wizard = new Wizard("Baltazar");

            // Hechizos y libro
            fireball = new Spell("Fireball", 20);
            ice = new Spell("Ice", 15);
            spellBook = new SpellBook(2, new List<Spell> { fireball, ice });
        }

        // ---------------- Personajes ----------------
        [Test]
        public void ElfStartsWithInitialLife()
        {
            Assert.AreEqual(Elf.initialLife, elf.AmountLife);
        }

        [Test]
        public void DwarfStartsWithInitialLife()
        {
            Assert.AreEqual(Dwarf.initialLife, dwarf.AmountLife);
        }

        [Test]
        public void WizardStartsWithInitialLife()
        {
            Assert.AreEqual(Wizard.initialLife, wizard.AmountLife);
        }

        [Test]
        public void ElfAddItemIncreasesLife()
        {
            var elf = new Elf("Gimpli");
            Console.WriteLine($"Vida inicial del elf: {elf.AmountLife}");
            Console.WriteLine($"Vida estática: {Elf.initialLife}");

            var shield = new Item("shield",0, 10);
            Console.WriteLine($"DefenseValue del shield: {shield.DefenseValue}");
    
            elf.AddItem(shield);
            Console.WriteLine($"Vida después de AddItem: {elf.AmountLife}");
    
            // Tu assert actual
            Assert.AreEqual(Elf.initialLife + shield.DefenseValue, elf.AmountLife);
        }

        [Test]
        public void DwarfRemoveItemDecreasesLife()
        {
            dwarf.AddItem(shield);
            dwarf.RemoveItem(shield);
            Assert.AreEqual(Dwarf.initialLife, dwarf.AmountLife);
        }

        [Test]
        public void ElfExchangeItemUpdatesLife()
        {
            elf.AddItem(sword);
            elf.ExchangeItem(sword, shield);
            //Assert.AreEqual(Elf.amountLife - sword.DefenseValue + shield.DefenseValue, elf.AmountLife);
        }
        [Test]
        public void WizardHealRestoresLife()
        {
            wizard.AddItem(shield);
            wizard.RemoveItem(shield);
            wizard.Heal();
            Assert.AreEqual(Wizard.initialLife, wizard.AmountLife);
        }

        // ---------------- Hechizos ----------------
        [Test]
        public void SpellHasCorrectNameAndPower()
        {
            Assert.AreEqual("Fireball", fireball.SpellName);
            Assert.AreEqual(20, fireball.Poder);
        }

        [Test]
        public void SpellBookStoresSpellsCorrectly()
        {
            Assert.IsNotNull(spellBook);
        }
    }
}