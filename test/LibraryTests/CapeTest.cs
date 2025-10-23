using NUnit.Framework;
using Library;

namespace Library.Tests;

public class CapeTest
{
    [Test]
    public void Constructor_FullParameters()
    {
        string name = "Super capa";
        int defense = 100;

        Cape cape = new Cape(name, defense);

        Assert.That(cape.Name, Is.EqualTo(name));
        Assert.That(cape.Name, Is.Not.EqualTo(null));
        Assert.That(cape.DefenseValue, Is.EqualTo(defense));
        Assert.That(cape.DefenseValue, Is.Not.Negative);


    }
    [Test]
    public void Name_ShouldBeMutable()
    {
        // Arrange
        Cape cape = new Cape("Short cape", 10);

        // Act
        cape.Name = "Long cape";

        // Assert
        Assert.That(cape.Name, Is.EqualTo("Long cape"));
    }
    [Test]
    public void AttackValue_ShouldBeMutable()
    {
        // Arrange
        Cape cape = new Cape("Shortcape", 10);

        // Act
        cape.DefenseValue = 21;

        // Assert
        Assert.That(cape.DefenseValue, Is.EqualTo(21));
    }
    [Test]
    public void CanBeCompared()
    {
        // Arrange
        string name1 = "Super capa";
        int defense1 = 100;
        string name2 = "capa mortal";
        int defense2 = 50;


        // Act
        Cape cape1 = new Cape(name1, defense1);
        Cape cape2 = new Cape(name2, defense2);
        // Assert
        Assert.That(cape1, Is.Not.EqualTo(cape2));
        Assert.That(cape2,Is.Not.EqualTo(cape1));
        Assert.That(cape1.DefenseValue,Is.GreaterThan(cape2.DefenseValue));
        Assert.That(cape2.DefenseValue,Is.Not.GreaterThan(cape1.DefenseValue));
    }
}