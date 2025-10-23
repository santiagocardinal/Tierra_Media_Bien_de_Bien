using NUnit.Framework;
using Program;
using System.Collections.Generic;

[TestFixture]
public class EncounterTestsGlobal
{
    // Variables globales para reutilizar
    private CharacterRegistry registry;
    private Wizard heroWizard;
    private Elf heroElf;
    private Dwarf heroDwarf;
    private Ogre villainOrc;
    private Vampire villainVamp;
    private Witch villainWitch;

    [SetUp]
    public void Setup()
    {
        // Crear registry
        registry = new CharacterRegistry();

        // Crear héroes
        heroWizard = new Wizard("Gandalf", 15, 15);
        heroWizard.AddItem(new Sword("Excalibur", 4, 2));
        heroWizard.AddItem(new Bow("Longbow", 3));

        // Crear SpellBook para Wizard
        SpellBook wizardSpellBook = new SpellBook("Grimoire of Light");
        wizardSpellBook.AddSpell(new Attack("Fireball", 5));
        wizardSpellBook.AddSpell(new Defense("Shield", 3));
        heroWizard.AddSpellBook(wizardSpellBook);

        heroElf = new Elf("Legolas", 10, 10);
        heroElf.AddItem(new Bow("ElvenBow", 3));

        heroDwarf = new Dwarf("Gimli", 12, 12);
        heroDwarf.AddItem(new Sword("BattleAxe", 3, 1));

        // Crear villanos
        villainOrc = new Ogre("Orc1", 8, 8, 2);
        villainOrc.AddItem(new Stick("Club", 2));

        villainVamp = new Vampire("Nosferatu", 10, 10, 3);
        villainVamp.AddItem(new Sword("VampireBlade", 3, 1));

        villainWitch = new Witch("Morgana", 7, 7, 2);
        villainWitch.AddItem(new Stick("MagicStaff", 2));

        // Crear SpellBook para Witch
        SpellBook witchSpellBook = new SpellBook("Book of Shadows");
        witchSpellBook.AddSpell(new Attack("DarkBolt", 4));
        witchSpellBook.AddSpell(new Defense("MagicBarrier", 2));
        villainWitch.AddSpellBook(witchSpellBook);
    }


    [Test]
    public void Encounter_HeroWithTwoVillains()
    {
        registry.ArrangeCharacters(heroWizard);
        registry.ArrangeCharacters(villainOrc);
        registry.ArrangeCharacters(villainVamp);

        Encounter encounter = new Encounter(registry);
        encounter.DoEncounter();

        Assert.IsTrue(heroWizard.AmountLife >= 0);
        Assert.IsTrue(villainOrc.AmountLife >= 0);
        Assert.IsTrue(villainVamp.AmountLife >= 0);
        Assert.IsTrue(registry.GoodGuys.Count == 0 || registry.BadGuys.Count == 0);
    }

    [Test]
    public void Encounter_VillainWithTwoHeroes()
    {
        registry.ArrangeCharacters(heroElf);
        registry.ArrangeCharacters(heroDwarf);
        registry.ArrangeCharacters(villainOrc);

        Encounter encounter = new Encounter(registry);
        encounter.DoEncounter();

        Assert.IsTrue(heroElf.AmountLife >= 0);
        Assert.IsTrue(heroDwarf.AmountLife >= 0);
        Assert.IsTrue(villainOrc.AmountLife >= 0);
        Assert.IsTrue(registry.GoodGuys.Count == 0 || registry.BadGuys.Count == 0);
    }

    [Test]
    public void Encounter_ThreeHeroesThreeVillains()
    {
        registry.ArrangeCharacters(heroWizard);
        registry.ArrangeCharacters(heroElf);
        registry.ArrangeCharacters(heroDwarf);
        registry.ArrangeCharacters(villainOrc);
        registry.ArrangeCharacters(villainVamp);
        registry.ArrangeCharacters(villainWitch);

        Encounter encounter = new Encounter(registry);
        encounter.DoEncounter();

        Assert.IsTrue(registry.GoodGuys.Count == 0 || registry.BadGuys.Count == 0);
    }

    [Test]
    public void Encounter_NoHeroes_OneVillain()
    {
        registry.ArrangeCharacters(villainOrc);

        Encounter encounter = new Encounter(registry);
        encounter.DoEncounter();

        Assert.AreEqual(0, registry.GoodGuys.Count);
        Assert.AreEqual(1, registry.BadGuys.Count);
    }

    [Test]
    public void Encounter_NoVillains_OneHero()
    {
        registry.ArrangeCharacters(heroWizard);

        Encounter encounter = new Encounter(registry);
        encounter.DoEncounter();

        Assert.AreEqual(1, registry.GoodGuys.Count);
        Assert.AreEqual(0, registry.BadGuys.Count);
    }
    
    [Test]
    public void Encounter_VillainsDefeated_AllHeroesWin()
    {
        // Limpiar registry y agregar los personajes para este escenario
        registry = new CharacterRegistry();
        registry.ArrangeCharacters(heroElf);     // héroe
        registry.ArrangeCharacters(heroDwarf);   // héroe
        registry.ArrangeCharacters(villainOrc);  // villano
        registry.ArrangeCharacters(villainVamp); // villano

        Encounter encounter = new Encounter(registry);
        encounter.DoEncounter();

        // Verificar que todos los héroes murieron
        Assert.AreEqual(2, registry.GoodGuys.Count);
        Assert.IsTrue(registry.BadGuys.Count == 0);
    }

    [Test]
    public void Encounter_HeroesDefeated_AllVillainsWin()
    {
        // Limpiar registry y agregar los personajes para este escenario
        registry = new CharacterRegistry();
        registry.ArrangeCharacters(heroDwarf);   // héroe
        registry.ArrangeCharacters(villainWitch); // villano
        registry.ArrangeCharacters(villainVamp); // villano

        Encounter encounter = new Encounter(registry);
        encounter.DoEncounter();

        // Verificar que todos los villanos murieron
        Assert.AreEqual(1, registry.BadGuys.Count);
        Assert.IsTrue(registry.GoodGuys.Count == 0);
    }

}
