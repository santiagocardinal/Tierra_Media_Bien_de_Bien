using NUnit.Framework;
using Program;
using System.Collections.Generic;

[TestFixture]
public class CharacterRegistryTests
{
    [Test]
    public void ArrangeCharacters_ShouldAddGoodAndBadGuysCorrectly()
    {
        // Crear personajes GoodGuys
        Elf legolas = new Elf("Legolas", 10, 10);
        Dwarf gimli = new Dwarf("Gimli", 12, 12);
        Wizard gandalf = new Wizard("Gandalf", 15, 15);

        // Crear personajes BadGuys
        Ogre orc = new Ogre("Orc", 8, 8, 2);
        Ogre goblin = new Ogre("Goblin", 5, 5, 1);

        // Crear el registry
        CharacterRegistry registry = new CharacterRegistry();

        // Agregar personajes usando ArrangeCharacters
        registry.ArrangeCharacters(legolas);
        registry.ArrangeCharacters(gimli);
        registry.ArrangeCharacters(gandalf);
        registry.ArrangeCharacters(orc);
        registry.ArrangeCharacters(goblin);

        // Verificar listas de GoodGuys
        Assert.AreEqual(3, registry.GoodGuys.Count);
        Assert.Contains(legolas, registry.GoodGuys);
        Assert.Contains(gimli, registry.GoodGuys);
        Assert.Contains(gandalf, registry.GoodGuys);

        // Verificar listas de BadGuys
        Assert.AreEqual(2, registry.BadGuys.Count);
        Assert.Contains(orc, registry.BadGuys);
        Assert.Contains(goblin, registry.BadGuys);
    }
}