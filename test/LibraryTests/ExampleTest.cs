using NUnit.Framework;
using Program;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    // ---------------- ITEM ----------------
    [TestFixture]
    public class DwarfTests
    {
        [Test]
        public void Dwarf_ShouldStartWithInitialLife()
        {
            var dwarf = new Dwarf("Gimli", 100);

            Assert.AreEqual(100, dwarf.InitialLife);
            Assert.AreEqual(100, dwarf.AmountLife);
            Assert.AreEqual("Gimli", dwarf.Name);
        }

        [Test]
        public void Dwarf_CanAddAndRemoveItems()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var sword = new Sword("Basic Sword", 10, 5);

            dwarf.AddItem(sword);

            Assert.Contains(sword, dwarf.Element);

            dwarf.RemoveItem(sword);

            Assert.IsFalse(dwarf.Element.Contains(sword));
        }

        [Test]
        public void Dwarf_AttackReducesOpponentLife()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var elf = new Elf("Legolas", 100);

            var sword = new Sword("Basic Sword", 20, 5);
            elf.AddItem(new Cape("Elven Cape", 10));
            dwarf.AddItem(sword);

            dwarf.Attack(elf, sword);

            Assert.Less(elf.AmountLife, 100);
        }

        [Test]
        public void Dwarf_HealRestoresLife()
        {
            var dwarf = new Dwarf("Gimli", 100);
            dwarf.AmountLife = 50;

            dwarf.Heal();

            Assert.AreEqual(100, dwarf.AmountLife);
        }
    }
    
    [TestFixture]
    public class SwordTests
    {
        [Test]
        public void Sword_ShouldStoreAttackAndDefenseValues()
        {
            var sword = new Sword("Excalibur", 30, 15);

            Assert.AreEqual("Excalibur", sword.Name);
            Assert.AreEqual(30, sword.AttackValue);
            Assert.AreEqual(15, sword.DefenseValue);
        }
    }
    
    [TestFixture]
    public class CapeTests
    {
        [Test]
        public void Cape_ShouldStoreDefenseValue()
        {
            var cape = new Cape("Magic Cape", 20);

            Assert.AreEqual("Magic Cape", cape.Name);
            Assert.AreEqual(20, cape.DefenseValue);
        }
    }
    
    [TestFixture]
    public class StickTests
    {
        [Test]
        public void Stick_ShouldStoreAttackValue()
        {
            var stick = new Stick("Wooden Stick", 5);

            Assert.AreEqual("Wooden Stick", stick.Name);
            Assert.AreEqual(5, stick.AttackValue);
        }
    }

    [TestFixture]
    public class BowTests
    {
        [Test]
        public void Bow_ShouldStoreAttackValue()
        {
            var bow = new Bow("Longbow", 15);

            Assert.AreEqual("Longbow", bow.Name);
            Assert.AreEqual(15, bow.AttackValue);
        }
    }
    
    [TestFixture]
    public class ElfTests
    {
        [Test]
        public void Elf_ShouldStartWithInitialLife()
        {
            var elf = new Elf("Legolas", 120);

            Assert.AreEqual(120, elf.InitialLife);
            Assert.AreEqual(120, elf.AmountLife);
        }

        [Test]
        public void Elf_AttackReducesOpponentLife()
        {
            var elf = new Elf("Legolas", 120);
            var dwarf = new Dwarf("Gimli", 100);

            var bow = new Bow("Elven Bow", 25);
            elf.AddItem(bow);

            elf.Attack(dwarf, bow);

            Assert.Less(dwarf.AmountLife, 100);
        }
    }
}

