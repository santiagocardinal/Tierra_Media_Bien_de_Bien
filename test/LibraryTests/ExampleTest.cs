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
            // Este test verifica que al crear un Item (Espada)
            // sus propiedades se inicialicen correctamente con los valores proporcionados.
            // Se asegura que el constructor funcione correctamente.
            var sword = new Item("Espada", 10, 5);

            Assert.That(sword.NameItem, Is.EqualTo("Espada")); // Verifica el nombre del item
            Assert.That(sword.AttackValue, Is.EqualTo(10));    // Verifica el valor de ataque
            Assert.That(sword.DefenseValue, Is.EqualTo(5));    // Verifica el valor de defensa
        }

        [Test]
        public void Properties_ShouldBeMutable()
        {
            // Este test asegura que las propiedades del item sean modificables.
            // Se prueba que se pueda cambiar el nombre, ataque y defensa después de la creación.
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
            // Verifica que al crear un Elfo sin items,
            // sus propiedades iniciales sean correctas: nombre, vida base y lista de elementos vacía.
            var item = new Item("espada", 15 , 0); // Item inicial para agregar al elfo
            var elf = new Elf("Legolas");

            Assert.That(elf.Element, Is.Empty);           // Lista de elementos vacía inicialmente
            elf.AddItem(item);                             // Agrega item para comprobar integración
            Assert.That(elf.Name, Is.EqualTo("Legolas")); // Verifica nombre del elfo
            Assert.That(elf.AmountLife, Is.EqualTo(50));  // Vida base del elfo
        }

        [Test]
        public void AmountLife_ShouldBeMutable()
        {
            //  Verifica que la vida del elfo cambie correctamente
            // al agregarle un item que proporciona defensa/vida adicional.
            var item = new Item("tunica", 0 , 15);
            var elf = new Elf("Legolas");
            elf.AddItem(item);

            Assert.That(elf.AmountLife, Is.EqualTo(65)); // Vida aumentada por item
        }
    }

    // ---------------- DWARF ----------------
    [TestFixture]
    public class DwarfTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Asegura que al crear un Enano (Dwarf)
            // se inicialicen correctamente nombre, elementos y vida base.
            var dwarf = new Dwarf("Gimli");

            Assert.That(dwarf.Name, Is.EqualTo("Gimli")); // Verifica nombre
            Assert.That(dwarf.Element, Is.Empty);        // Elementos inicialmente vacíos
            Assert.That(dwarf.AmountLife, Is.EqualTo(50));// Vida base
        }

        [Test]
        public void AmountLife_ShouldBeMutable()
        {
            // Este test verifica que la vida de un enano
            // pueda cambiar manualmente sin problemas.
            var dwarf = new Dwarf("Gimli");

            dwarf.AmountLife = 30; // Modificación manual

            Assert.That(dwarf.AmountLife, Is.EqualTo(30)); // Verifica cambio
        }
    }

    // ---------------- WIZARD ----------------
    [TestFixture]
    public class WizardTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Asegura que al crear un Mago (Wizard) con un libro de hechizos,
            // las propiedades se inicialicen correctamente.
            var spell = new Spell("Fuego", 25);
            var spellBook = new SpellBook();
            spellBook.AddSpell(spell);
            var wizard = new Wizard("Gandalf", spellBook);

            Assert.That(wizard.Name, Is.EqualTo("Gandalf")); // Verifica nombre
            Assert.That(wizard.LstElement, Is.Empty);        // Lista de elementos vacía
            Assert.That(wizard.SpellBook, Is.Not.Null);      // Libro de hechizos asignado
        }

        [Test]
        public void AmountLife_ShouldBeMutable()
        {
            //  Verifica que la vida del mago cambie correctamente
            // al agregar un item que proporciona defensa/vida adicional.
            var spell = new Spell("ice", 15);
            var spellBook = new SpellBook();
            var item = new Item("tunica", 0, 5);
            var wizard = new Wizard("Gandalf", spellBook);
            wizard.AddItem(item);

            Assert.That(wizard.AmountLife, Is.EqualTo(55)); // Vida base + item
        }
    }

    // ---------------- SPELLBOOK ----------------
    [TestFixture]
    public class SpellBookTests
    {
        [Test]
        public void Constructor_ShouldInitializeEmptySpellsList()
        {
            // Verifica que un SpellBook recién creado
            // tenga la lista de hechizos inicializada pero vacía.
            var spellBook = new SpellBook();

            Assert.That(spellBook.Spell, Is.Not.Null); // Lista creada
            Assert.That(spellBook.Spell, Is.Empty);    // Lista vacía
        }

        [Test]
        public void AddSpell_ShouldIncreaseSpellsCount()
        {
            // Este test asegura que al agregar un hechizo
            // al libro, se guarde correctamente y se incremente la lista.
            var spell = new Spell("Fuego", 25);
            var spellBook = new SpellBook();
            spellBook.AddSpell(spell);

            Assert.That(spellBook.Spell.Count, Is.EqualTo(1));          // Lista incrementada
            Assert.That(spellBook.Spell.First().SpellName, Is.EqualTo("Fuego")); // Hechizo agregado correctamente
        }
    }

    // ---------------- SPELL ----------------
    [TestFixture]
    public class SpellTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            //  Verifica que al crear un hechizo
            // sus propiedades se inicialicen correctamente con el constructor.
            var fireball = new Spell("Bola de fuego", 30);

            Assert.That(fireball.SpellName, Is.EqualTo("Bola de fuego")); // Nombre del hechizo
            Assert.That(fireball.Poder, Is.EqualTo(30));                 // Poder del hechizo
        }

        [Test]
        public void Properties_ShouldBeMutable()
        {
            // Verifica que las propiedades de un hechizo
            // puedan modificarse después de creado.
            var ice = new Spell("Hielo", 15);

            ice.SpellName = "Super Hielo"; // Cambio de nombre
            ice.Poder = 50;                // Cambio de poder

            Assert.That(ice.SpellName, Is.EqualTo("Super Hielo")); // Verifica nombre modificado
            Assert.That(ice.Poder, Is.EqualTo(50));               // Verifica poder modificado
        }
    }
}
