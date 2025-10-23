/*using NUnit.Framework;
using Program;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    // ==================== ITEM TESTS ====================
    
    [TestFixture]
    public class SwordTests
    {
        [Test]
        public void Sword_ShouldStoreCorrectValues()
        {
            var sword = new Sword("Excalibur", 30, 15);

            Assert.AreEqual("Excalibur", sword.Name);
            Assert.AreEqual(30, sword.AttackValue);
            Assert.AreEqual(15, sword.DefenseValue);
        }

        [Test]
        public void Sword_ShouldImplementBothAttackAndDefenseInterfaces()
        {
            var sword = new Sword("Excalibur", 30, 15);

            Assert.IsInstanceOf<IAttackItem>(sword);
            Assert.IsInstanceOf<IDefenseItem>(sword);
            Assert.IsInstanceOf<IItem>(sword);
        }

        [Test]
        public void Sword_ShouldAllowZeroValues()
        {
            var sword = new Sword("Broken Sword", 0, 0);

            Assert.AreEqual(0, sword.AttackValue);
            Assert.AreEqual(0, sword.DefenseValue);
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

        [Test]
        public void Cape_ShouldImplementDefenseInterface()
        {
            var cape = new Cape("Magic Cape", 20);

            Assert.IsInstanceOf<IDefenseItem>(cape);
            Assert.IsInstanceOf<IItem>(cape);
        }

        [Test]
        public void Cape_ShouldAllowHighDefenseValues()
        {
            var cape = new Cape("Legendary Cape", 1000);

            Assert.AreEqual(1000, cape.DefenseValue);
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

        [Test]
        public void Stick_ShouldImplementAttackInterface()
        {
            var stick = new Stick("Wooden Stick", 5);

            Assert.IsInstanceOf<IAttackItem>(stick);
            Assert.IsInstanceOf<IItem>(stick);
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

        [Test]
        public void Bow_ShouldImplementAttackInterface()
        {
            var bow = new Bow("Longbow", 15);

            Assert.IsInstanceOf<IAttackItem>(bow);
            Assert.IsInstanceOf<IItem>(bow);
        }

        [Test]
        public void Bow_ShouldAllowDifferentAttackValues()
        {
            var weakBow = new Bow("Short Bow", 5);
            var strongBow = new Bow("War Bow", 50);

            Assert.AreEqual(5, weakBow.AttackValue);
            Assert.AreEqual(50, strongBow.AttackValue);
        }
    }

    // ==================== SPELL TESTS ====================
    
    [TestFixture]
    public class SpellTests
    {
        [Test]
        public void Spell_ShouldStoreNameAndPower()
        {
            var spell = new Spell("Fireball", 40);

            Assert.AreEqual("Fireball", spell.SpellName);
            Assert.AreEqual(40, spell.Poder);
        }
    }

    [TestFixture]
    public class SpellBookTests
    {
        [Test]
        public void SpellBook_ShouldStartEmpty()
        {
            var book = new SpellBook("Ancient Tome");

            Assert.AreEqual("Ancient Tome", book.Name);
            Assert.IsEmpty(book.Spell);
        }

        [Test]
        public void SpellBook_ShouldAddSpells()
        {
            var book = new SpellBook("Ancient Tome");
            var fireball = new Spell("Fireball", 30);
            var ice = new Spell("Ice Blast", 25);

            book.AddSpell(fireball);
            book.AddSpell(ice);

            Assert.AreEqual(2, book.Spell.Count);
            Assert.Contains(fireball, book.Spell);
            Assert.Contains(ice, book.Spell);
        }

        [Test]
        public void SpellBook_ShouldImplementIMagicItem()
        {
            var book = new SpellBook("Ancient Tome");

            Assert.IsInstanceOf<IMagicCharacter>(book);
            Assert.IsInstanceOf<IItem>(book);
        }

        [Test]
        public void SpellBook_ShouldAllowMultipleSpells()
        {
            var book = new SpellBook("Grimoire");
            
            for (int i = 0; i < 10; i++)
            {
                book.AddSpell(new Spell($"Spell{i}", i * 10));
            }

            Assert.AreEqual(10, book.Spell.Count);
        }

        [Test]
        public void SpellBook_ShouldAllowDuplicateSpells()
        {
            var book = new SpellBook("Grimoire");
            var fireball = new Spell("Fireball", 30);

            book.AddSpell(fireball);
            book.AddSpell(fireball);

            Assert.AreEqual(2, book.Spell.Count);
        }
    }

    // ==================== CHARACTER TESTS ====================
    
    [TestFixture]
    public class DwarfTests
    {
        [Test]
        public void Dwarf_ShouldStartWithInitialLife()
        {
            var dwarf = new Dwarf("Gimli", 100);

            Assert.AreEqual("Gimli", dwarf.Name);
            Assert.AreEqual(100, dwarf.InitialLife);
            Assert.AreEqual(100, dwarf.AmountLife);
            Assert.IsEmpty(dwarf.Element);
        }

        [Test]
        public void Dwarf_ShouldImplementICharacter()
        {
            var dwarf = new Dwarf("Gimli", 100);

            Assert.IsInstanceOf<ICharacter>(dwarf);
            Assert.IsInstanceOf<IItem>(dwarf);
        }

        [Test]
        public void Dwarf_CanAddItems()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var sword = new Sword("Axe", 10, 5);
            var cape = new Cape("Armor", 15);

            dwarf.AddItem(sword);
            dwarf.AddItem(cape);

            Assert.AreEqual(2, dwarf.Element.Count);
            Assert.Contains(sword, dwarf.Element);
            Assert.Contains(cape, dwarf.Element);
        }

        [Test]
        public void Dwarf_CanRemoveItems()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var sword = new Sword("Basic Sword", 10, 5);

            dwarf.AddItem(sword);
            Assert.Contains(sword, dwarf.Element);

            dwarf.RemoveItem(sword);
            Assert.IsFalse(dwarf.Element.Contains(sword));
        }

        [Test]
        public void Dwarf_RemoveNonExistentItemDoesNotThrow()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var sword = new Sword("Basic Sword", 10, 5);

            Assert.DoesNotThrow(() => dwarf.RemoveItem(sword));
        }

        [Test]
        public void Dwarf_CanExchangeItems()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var oldSword = new Sword("Old Sword", 10, 5);
            var newSword = new Sword("New Sword", 20, 10);

            dwarf.AddItem(oldSword);
            dwarf.ExchangeItem(oldSword, newSword);

            Assert.Contains(newSword, dwarf.Element);
            Assert.IsFalse(dwarf.Element.Contains(oldSword));
        }

        [Test]
        public void Dwarf_GetDefenseReturnsZeroWithNoItems()
        {
            var dwarf = new Dwarf("Gimli", 100);

            Assert.AreEqual(0, dwarf.GetDefense());
        }

        [Test]
        public void Dwarf_GetDefenseSumsAllDefenseItems()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var sword = new Sword("Sword", 10, 5);
            var cape = new Cape("Cape", 15);

            dwarf.AddItem(sword);
            dwarf.AddItem(cape);

            Assert.AreEqual(20, dwarf.GetDefense());
        }

        [Test]
        public void Dwarf_GetDefenseIgnoresAttackOnlyItems()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var bow = new Bow("Bow", 20);
            var cape = new Cape("Cape", 10);

            dwarf.AddItem(bow);
            dwarf.AddItem(cape);

            Assert.AreEqual(10, dwarf.GetDefense());
        }

        [Test]
        public void Dwarf_AttackReducesOpponentLife()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var elf = new Elf("Legolas", 100);
            var sword = new Sword("Battle Axe", 20, 5);

            dwarf.AddItem(sword);
            dwarf.Attack(elf, sword);

            Assert.AreEqual(80, elf.AmountLife);
        }

        [Test]
        public void Dwarf_AttackConsidersOpponentDefense()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var elf = new Elf("Legolas", 100);
            var sword = new Sword("Battle Axe", 20, 0);
            var cape = new Cape("Elven Cape", 10);

            elf.AddItem(cape);
            dwarf.AddItem(sword);
            dwarf.Attack(elf, sword);

            Assert.AreEqual(90, elf.AmountLife);
        }

        [Test]
        public void Dwarf_AttackWithNonAttackItemDoesNoDamage()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var elf = new Elf("Legolas", 100);
            var cape = new Cape("Cape", 10);

            dwarf.AddItem(cape);
            dwarf.Attack(elf, cape);

            Assert.AreEqual(100, elf.AmountLife);
        }

        [Test]
        public void Dwarf_HealRestoresFullLife()
        {
            var dwarf = new Dwarf("Gimli", 100);
            dwarf.AmountLife = 20;

            dwarf.Heal();

            Assert.AreEqual(100, dwarf.AmountLife);
        }

        [Test]
        public void Dwarf_HealWhenFullLifeDoesNothing()
        {
            var dwarf = new Dwarf("Gimli", 100);

            dwarf.Heal();

            Assert.AreEqual(100, dwarf.AmountLife);
        }

        [Test]
        public void Dwarf_CanTakeDamageToZero()
        {
            var dwarf = new Dwarf("Gimli", 50);
            var attacker = new Elf("Enemy", 100);
            var bow = new Bow("Strong Bow", 100);

            attacker.AddItem(bow);
            attacker.Attack(dwarf, bow);

            Assert.LessOrEqual(dwarf.AmountLife, 0);
        }
    }
    
    [TestFixture]
    public class ElfTests
    {
        [Test]
        public void Elf_ShouldStartWithInitialLife()
        {
            var elf = new Elf("Legolas", 120);

            Assert.AreEqual("Legolas", elf.Name);
            Assert.AreEqual(120, elf.InitialLife);
            Assert.AreEqual(120, elf.AmountLife);
            Assert.IsEmpty(elf.Element);
        }

        [Test]
        public void Elf_ShouldImplementICharacter()
        {
            var elf = new Elf("Legolas", 120);

            Assert.IsInstanceOf<ICharacter>(elf);
            Assert.IsInstanceOf<IItem>(elf);
        }

        [Test]
        public void Elf_AttackReducesOpponentLife()
        {
            var elf = new Elf("Legolas", 120);
            var dwarf = new Dwarf("Gimli", 100);
            var bow = new Bow("Elven Bow", 25);

            elf.AddItem(bow);
            elf.Attack(dwarf, bow);

            Assert.AreEqual(75, dwarf.AmountLife);
        }

        [Test]
        public void Elf_AttackConsidersOpponentDefense()
        {
            var elf = new Elf("Legolas", 120);
            var dwarf = new Dwarf("Gimli", 100);
            var bow = new Bow("Elven Bow", 25);
            var armor = new Cape("Heavy Armor", 15);

            dwarf.AddItem(armor);
            elf.AddItem(bow);
            elf.Attack(dwarf, bow);

            Assert.AreEqual(90, dwarf.AmountLife);
        }

        [Test]
        public void Elf_GetDefenseSumsAllDefenseItems()
        {
            var elf = new Elf("Legolas", 120);
            var cape = new Cape("Light Cape", 10);
            var sword = new Sword("Short Sword", 5, 8);

            elf.AddItem(cape);
            elf.AddItem(sword);

            Assert.AreEqual(18, elf.GetDefense());
        }

        [Test]
        public void Elf_HealRestoresFullLife()
        {
            var elf = new Elf("Legolas", 120);
            elf.AmountLife = 30;

            elf.Heal();

            Assert.AreEqual(120, elf.AmountLife);
        }

        [Test]
        public void Elf_ReceiveDamageReducesLife()
        {
            var elf = new Elf("Legolas", 100);

            elf.ReceiveDamage(30);

            Assert.AreEqual(70, elf.AmountLife);
        }

        [Test]
        public void Elf_ReceiveDamageCannotGoNegative()
        {
            var elf = new Elf("Legolas", 50);

            elf.ReceiveDamage(100);

            Assert.AreEqual(0, elf.AmountLife);
        }

        [Test]
        public void Elf_CanExchangeItems()
        {
            var elf = new Elf("Legolas", 120);
            var oldBow = new Bow("Old Bow", 10);
            var newBow = new Bow("New Bow", 25);

            elf.AddItem(oldBow);
            elf.ExchangeItem(oldBow, newBow);

            Assert.Contains(newBow, elf.Element);
            Assert.IsFalse(elf.Element.Contains(oldBow));
        }
    }

    [TestFixture]
    public class WizardTests
    {
        [Test]
        public void Wizard_ShouldStartWithInitialLife()
        {
            var wizard = new Wizard("Gandalf", 100, 100);

            Assert.AreEqual("Gandalf", wizard.Name);
            Assert.AreEqual(100, wizard.InitialLife);
            Assert.AreEqual(100, wizard.AmountLife);
            Assert.IsEmpty(wizard.Element);
        }

        [Test]
        public void Wizard_ShouldImplementIMagicCharacter()
        {
            var wizard = new Wizard("Gandalf", 100, 100);

            Assert.IsInstanceOf<IMagicCharacterOld>(wizard);
            Assert.IsInstanceOf<ICharacter>(wizard);
            Assert.IsInstanceOf<IItem>(wizard);
        }

        [Test]
        public void Wizard_CanAddSpellBook()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            var spellBook = new SpellBook("Ancient Tome");
            var fireball = new Spell("Fireball", 40);

            spellBook.AddSpell(fireball);
            wizard.AddItem(spellBook);

            Assert.Contains(spellBook, wizard.Element);
        }

        [Test]
        public void Wizard_CanAttackWithPhysicalWeapon()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            var staff = new Stick("Magic Staff", 15);
            var enemy = new Dwarf("Orc", 100);

            wizard.AddItem(staff);
            wizard.Attack(enemy, staff);

            Assert.AreEqual(85, enemy.AmountLife);
        }

        [Test]
        public void Wizard_AttackWithSpellReducesOpponentLife()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            var spellBook = new SpellBook("Grimoire");
            var fireball = new Spell("Fireball", 40);
            var enemy = new Dwarf("Orc", 100);

            spellBook.AddSpell(fireball);
            wizard.AddItem(spellBook);
            wizard.WizardAttackWithSpell(fireball, enemy);

            Assert.AreEqual(60, enemy.AmountLife);
        }

        [Test]
        public void Wizard_SpellAttackConsidersDefense()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            var spellBook = new SpellBook("Grimoire");
            var fireball = new Spell("Fireball", 40);
            var enemy = new Dwarf("Orc", 100);
            var armor = new Cape("Heavy Armor", 15);

            spellBook.AddSpell(fireball);
            wizard.AddItem(spellBook);
            enemy.AddItem(armor);
            wizard.WizardAttackWithSpell(fireball, enemy);

            Assert.AreEqual(75, enemy.AmountLife);
        }

        [Test]
        public void Wizard_CanAttackDifferentCharacterTypes()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            var spellBook = new SpellBook("Grimoire");
            var lightning = new Spell("Lightning", 30);
            
            var elf = new Elf("Elf", 100);
            var dwarf = new Dwarf("Dwarf", 100);
            var wizard2 = new Wizard("Wizard2", 100, 100);

            spellBook.AddSpell(lightning);
            wizard.AddItem(spellBook);

            wizard.WizardAttackWithSpell(lightning, elf);
            wizard.WizardAttackWithSpell(lightning, dwarf);
            wizard.WizardAttackWithSpell(lightning, wizard2);

            Assert.AreEqual(70, elf.AmountLife);
            Assert.AreEqual(70, dwarf.AmountLife);
            Assert.AreEqual(70, wizard2.AmountLife);
        }

        [Test]
        public void Wizard_GetDefenseWorksWithMixedItems()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            var cape = new Cape("Wizard Robe", 12);
            var staff = new Stick("Staff", 10);
            var spellBook = new SpellBook("Book");

            wizard.AddItem(cape);
            wizard.AddItem(staff);
            wizard.AddItem(spellBook);

            Assert.AreEqual(12, wizard.GetDefense());
        }

        [Test]
        public void Wizard_HealRestoresFullLife()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            wizard.AmountLife = 25;

            wizard.Heal();

            Assert.AreEqual(100, wizard.AmountLife);
        }

        [Test]
        public void Wizard_CanExchangeItems()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            var oldBook = new SpellBook("Old Book");
            var newBook = new SpellBook("New Book");

            wizard.AddItem(oldBook);
            wizard.ExchangeItem(oldBook, newBook);

            Assert.Contains(newBook, wizard.Element);
            Assert.IsFalse(wizard.Element.Contains(oldBook));
        }

        [Test]
        public void Wizard_CanCastMultipleSpells()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            var spellBook = new SpellBook("Grimoire");
            var fireball = new Spell("Fireball", 20);
            var ice = new Spell("Ice", 25);
            var enemy = new Dwarf("Orc", 100);

            spellBook.AddSpell(fireball);
            spellBook.AddSpell(ice);
            wizard.AddItem(spellBook);

            wizard.WizardAttackWithSpell(fireball, enemy);
            wizard.WizardAttackWithSpell(ice, enemy);

            Assert.AreEqual(55, enemy.AmountLife);
        }
    }

    // ==================== INTEGRATION TESTS ====================
    
    [TestFixture]
    public class CombatIntegrationTests
    {
        [Test]
        public void Combat_WizardVsDwarfFullFight()
        {
            var wizard = new Wizard("Gandalf", 100, 100);
            var dwarf = new Dwarf("Gimli", 100);

            var spellBook = new SpellBook("Ancient Tome");
            var fireball = new Spell("Fireball", 30);
            spellBook.AddSpell(fireball);
            wizard.AddItem(spellBook);

            var axe = new Sword("Battle Axe", 25, 5);
            dwarf.AddItem(axe);

            // Round 1: Wizard attacks
            wizard.WizardAttackWithSpell(fireball, dwarf);
            Assert.AreEqual(75, dwarf.AmountLife);

            // Round 2: Dwarf attacks
            dwarf.Attack(wizard, axe);
            Assert.AreEqual(75, wizard.AmountLife);

            // Round 3: Wizard attacks again
            wizard.WizardAttackWithSpell(fireball, dwarf);
            Assert.AreEqual(50, dwarf.AmountLife);
        }

        [Test]
        public void Combat_ElfVsElfWithDefense()
        {
            var elf1 = new Elf("Legolas", 100);
            var elf2 = new Elf("Tauriel", 100);

            var bow1 = new Bow("Longbow", 20);
            var bow2 = new Bow("Shortbow", 15);
            var cape1 = new Cape("Light Armor", 10);
            var cape2 = new Cape("Heavy Armor", 15);

            elf1.AddItem(bow1);
            elf1.AddItem(cape1);
            elf2.AddItem(bow2);
            elf2.AddItem(cape2);

            elf1.Attack(elf2, bow1);
            Assert.AreEqual(95, elf2.AmountLife);

            elf2.Attack(elf1, bow2);
            Assert.AreEqual(95, elf1.AmountLife);
        }

        [Test]
        public void Combat_HighDefenseBlocksMostDamage()
        {
            var attacker = new Dwarf("Attacker", 100);
            var defender = new Elf("Defender", 100);

            var weakBow = new Bow("Weak Bow", 10);
            var superArmor = new Cape("Super Armor", 50);

            attacker.AddItem(weakBow);
            defender.AddItem(superArmor);

            attacker.Attack(defender, weakBow);

            // 100 + 50 (defense) - 10 (attack) = 140
            Assert.AreEqual(140, defender.AmountLife);
        }

        [Test]
        public void Combat_MultipleItemsStackCorrectly()
        {
            var character = new Dwarf("Tank", 100);

            var sword = new Sword("Sword", 10, 5);
            var cape1 = new Cape("Cape1", 10);
            var cape2 = new Cape("Cape2", 15);

            character.AddItem(sword);
            character.AddItem(cape1);
            character.AddItem(cape2);

            Assert.AreEqual(30, character.GetDefense());
        }

        [Test]
        public void Combat_HealingDuringBattle()
        {
            var wizard = new Wizard("Healer", 100, 100);
            var enemy = new Dwarf("Enemy", 100);
            var sword = new Sword("Sword", 40, 0);

            enemy.AddItem(sword);
            enemy.Attack(wizard, sword);
            Assert.AreEqual(60, wizard.AmountLife);

            wizard.Heal();
            Assert.AreEqual(100, wizard.AmountLife);

            enemy.Attack(wizard, sword);
            Assert.AreEqual(60, wizard.AmountLife);
        }
    }

    // ==================== EDGE CASE TESTS ====================
    
    [TestFixture]
    public class EdgeCaseTests
    {
        [Test]
        public void Character_WithZeroInitialLife()
        {
            var dwarf = new Dwarf("Dead", 0);

            Assert.AreEqual(0, dwarf.AmountLife);
            Assert.AreEqual(0, dwarf.InitialLife);
        }

        [Test]
        public void Attack_WithZeroDamageWeapon()
        {
            var attacker = new Elf("Attacker", 100);
            var defender = new Dwarf("Defender", 100);
            var brokenBow = new Bow("Broken Bow", 0);

            attacker.AddItem(brokenBow);
            attacker.Attack(defender, brokenBow);

            Assert.AreEqual(100, defender.AmountLife);
        }

        [Test]
        public void Spell_WithZeroPower()
        {
            var wizard = new Wizard("Wizard", 100, 100);
            var enemy = new Dwarf("Enemy", 100);
            var spellBook = new SpellBook("Book");
            var weakSpell = new Spell("Weak", 0);

            spellBook.AddSpell(weakSpell);
            wizard.AddItem(spellBook);
            wizard.WizardAttackWithSpell(weakSpell, enemy);

            Assert.AreEqual(100, enemy.AmountLife);
        }

        [Test]
        public void ExchangeItem_WithItemNotInList()
        {
            var dwarf = new Dwarf("Gimli", 100);
            var sword1 = new Sword("Sword1", 10, 5);
            var sword2 = new Sword("Sword2", 15, 8);

            dwarf.AddItem(sword1);

            // Intentar intercambiar un item que no está en la lista
            // El comportamiento actual puede variar, esto documenta el comportamiento esperado
            Assert.DoesNotThrow(() => dwarf.ExchangeItem(sword2, sword1));
        }

        [Test]
        public void Character_CanHaveEmptyName()
        {
            var elf = new Elf("", 100);

            Assert.AreEqual("", elf.Name);
        }

        [Test]
        public void SpellBook_WithNoSpells()
        {
            var wizard = new Wizard("Wizard", 100, 100);
            var emptyBook = new SpellBook("Empty");
            var enemy = new Dwarf("Enemy", 100);

            wizard.AddItem(emptyBook);

            // No debe causar error aunque el libro esté vacío
            Assert.DoesNotThrow(() => wizard.WizardAttackWithSpell(new Spell("NonExistent", 10), enemy));
        }
    }
}*/