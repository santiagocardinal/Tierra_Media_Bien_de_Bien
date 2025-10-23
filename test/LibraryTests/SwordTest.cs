using NUnit.Framework;
using Library;

namespace Library.Tests;

public class SwordTest
{
    [Test]
    public void Constructor_FullParameters()
    {
        string name = "Super espada";
        int attack = 200;
        int defense = 125;

        Sword espada = new Sword(name, attack,defense);
        
        Assert.That(espada.Name, Is.EqualTo(name));
        Assert.That(espada.Name, Is.Not.EqualTo(null));
        Assert.That(espada.AttackValue, Is.EqualTo(attack));
        Assert.That(espada.AttackValue, Is.Not.Negative);
        Assert.That(espada.DefenseValue, Is.EqualTo(defense));
        Assert.That(espada.DefenseValue, Is.Not.Negative);
        
    }
    [Test]
    public void Name_ShouldBeMutable()
    {
        // Arrange
        Sword espada = new Sword("Espada flamante", 50,25);

        // Act
        espada.Name = "Espada normal";

        // Assert
        Assert.That(espada.Name, Is.EqualTo("Espada normal"));
    }
    [Test]
    public void AttackValue_ShouldBeMutable()
    {
        // Arrange
        Sword espada = new Sword("Espada flamante", 50,25);


        // Act
        espada.AttackValue = 1025;

        // Assert
        Assert.That(espada.AttackValue, Is.EqualTo(1025));
    }
    [Test]
    public void DefenseValue_ShouldBeMutable()
    {
        // Arrange
        Sword espada = new Sword("Espada flamante", 50,25);


        // Act
        espada.DefenseValue = 500;

        // Assert
        Assert.That(espada.DefenseValue, Is.EqualTo(500));
    }
    [Test]
    public void CanBeCompared()
    {
        // Arrange
        string name1 = "Super espada 300";
        int attack1 = 100;
        int defense1 = 50;
        string name2 = "Espada mortal";
        int attack2 = 50;
        int defense2 = 25;
        
        // Act
        Sword espada1 = new Sword(name1, attack1,defense1);
        Sword espada2 = new Sword(name2, attack2,defense2);
        
        // Assert
        Assert.That(espada1, Is.Not.EqualTo(espada2));
        Assert.That(espada2,Is.Not.EqualTo(espada1));
        Assert.That(espada1.AttackValue,Is.GreaterThan(espada2.AttackValue));
        Assert.That(espada2.AttackValue,Is.Not.GreaterThan(espada1.AttackValue));
    }
}