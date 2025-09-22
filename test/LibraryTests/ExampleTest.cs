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

            Assert.That(elf.AmountLife, Is.EqualTo(50)); // Vida aumentada por item
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

            Assert.That(wizard.AmountLife, Is.EqualTo(50)); // Vida base + item
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
    
    [TestFixture]
    public class AttackTests
    {
        [Test]
        public void WizardAttacks()
        {
            // Creo ítems,creo el hechizo del mago, creo los personajes, les asigno items
            var fireball = new Spell("Bola de fuego", 30);
            var spellbook = new SpellBook();
            spellbook.AddSpell(fireball);

            var wizard1 = new Wizard("Gandalf", spellbook);
            var wizard2 = new Wizard("Bmbi", spellbook);
            var elf = new Elf("Legolas");
            var dwarf = new Dwarf("Gimli");

            var item = new Item("tunica", 0, 5);
            var item2 = new Item("espada", 5, 0);
            elf.AddItem(item2);
            dwarf.AddItem(item);
            wizard1.AddItem(item);

            // Wizard ataca con hechizo a todos los enemigos
            wizard1.WizardAttackWithSpell(elf, fireball);
            wizard1.WizardAttackWithSpell(dwarf, fireball);
            wizard1.WizardAttackWithSpell(wizard2, fireball);

            // Verificar vida después de los ataques
            Assert.That(elf.AmountLife, Is.EqualTo(20));
            Assert.That(dwarf.AmountLife, Is.EqualTo(25));
            Assert.That(wizard2.AmountLife, Is.EqualTo(20));
        }
        [Test]
        public void ElfAttacks()
        {
            // Creo ítems,creo el hechizo del mago, creo los personajes, les asigno items
            var fireball = new Spell("Bola de fuego", 30);
            var spellbook = new SpellBook();
            spellbook.AddSpell(fireball);

            var wizard1 = new Wizard("Gandalf", spellbook);
            var elf = new Elf("Legolas");
            var elf2 = new Elf("Legolas");
            var dwarf = new Dwarf("Gimli");

            var item = new Item("tunica", 0, 8);
            var item2 = new Item("espada", 6, 0);
            var item3 = new Item("baston", 2, 0);
            
            elf.AddItem(item2);
            dwarf.AddItem(item);
            elf2.AddItem(item3);
            wizard1.AddItem(item);

            // Elf ataca a otros personajes
            elf.Attack(dwarf);
            elf.Attack(wizard1);
            elf.Attack(elf2);

            // Verificar vida después de los ataques
            Assert.That(elf2.AmountLife, Is.EqualTo(44)); //<---------------------------------------
            Assert.That(dwarf.AmountLife, Is.EqualTo(52));//<---------------------------------------
            Assert.That(wizard1.AmountLife, Is.EqualTo(52));
        }

        [Test]
        public void DwarfAttacks()
        {
            // Creo ítems,creo el hechizo del mago, creo los personajes, les asigno items
            var fireball = new Spell("Bola de fuego", 30);
            var spellbook = new SpellBook();
            spellbook.AddSpell(fireball);
            
            var wizard = new Wizard("Gandalf", spellbook);
            var elf = new Elf("Legolas");
            var dwarf = new Dwarf("Gimli");
            var dwarf1 = new Dwarf("Hermano_de_Gimli");

            var item = new Item("tunica", 0, 8);
            var item2 = new Item("espada", 6, 0);
            var item3 = new Item("baston", 2, 0);
            
            dwarf.AddItem(item);
            elf.AddItem(item2);
            dwarf1.AddItem(item3);
            wizard.AddItem(item);

            // Dwarf ataca a otros personajes
            dwarf.Attack(elf);
            dwarf.Attack(wizard);
            dwarf.Attack(dwarf1);

            // Verificar vida después de los ataques
            Assert.That(elf.AmountLife, Is.EqualTo(50));
            Assert.That(wizard.AmountLife, Is.EqualTo(58));//<---------------------------------------
            Assert.That(dwarf1.AmountLife, Is.EqualTo(50));
        }

        [Test]
        public void Heal()
        {
            // Creo ítems, personajes, les asigno items y los enfrento para simular la reduccion de vida
            var tunica = new Item("Tunica", 0, 8);
            var espada = new Item("Espada", 6, 0);
            var baston = new Item("Baston", 2, 0);

            var fireball = new Spell("Bola de fuego", 30);  
            var spellbookWizard = new SpellBook();
            spellbookWizard.AddSpell(fireball);
            
            var wizard = new Wizard("Gandalf", spellbookWizard);
            var elf = new Elf("Legolas");
            var dwarf = new Dwarf("Gimli");
            
            wizard.AddItem(tunica);  
            elf.AddItem(espada);
            dwarf.AddItem(baston);
            
            elf.Attack(wizard);      
            dwarf.Attack(elf);       
            wizard.WizardAttackWithSpell(dwarf, fireball); 

            // Uso Heal para restaurar la vida
            wizard.Heal();
            elf.Heal();
            dwarf.Heal();

            // Verificar que la vida volvió al valor inicial
            Assert.That(wizard.AmountLife, Is.EqualTo(Wizard.initialLife));
            Assert.That(elf.AmountLife, Is.EqualTo(Elf.initialLife));
            Assert.That(dwarf.AmountLife, Is.EqualTo(Dwarf.initialLife));
        }

    }
}
