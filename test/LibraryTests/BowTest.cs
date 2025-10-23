using NUnit.Framework;
using Library;

namespace Library.Tests;

public class BowTest
{
    [Test]
    public void Constructor_FullParameters()
    {
        string name = "Super arco";
        int attack = 100;

        Bow bow = new Bow(name, attack);
        
        Assert.That(bow.Name, Is.EqualTo(name));
        Assert.That(bow.Name, Is.Not.EqualTo(null));
        Assert.That(bow.AttackValue, Is.EqualTo(attack));
        Assert.That(bow.AttackValue, Is.Not.Negative);
        
        
    }
    [Test]
    public void Name_ShouldBeMutable()
    {
        // Arrange
        Bow bow = new Bow("Short bow", 10);

        // Act
        bow.Name = "Long Bow";

        // Assert
        Assert.That(bow.Name, Is.EqualTo("Long Bow"));
    }
    [Test]
    public void AttackValue_ShouldBeMutable()
    {
        // Arrange
        Bow bow = new Bow("Shortbow", 10);

        // Act
        bow.AttackValue = 21;

        // Assert
        Assert.That(bow.AttackValue, Is.EqualTo(21));
    }
    [Test]
    public void CanBeCompared()
    {
        // Arrange
        string name1 = "Super arco";
        int attack1 = 100;
        string name2 = "Arco mortal";
        int attack2 = 50;
        

        // Act
        Bow bow1 = new Bow(name1, attack1);
        Bow bow2 = new Bow(name2, attack2);
        // Assert
        Assert.That(bow1, Is.Not.EqualTo(bow2));
        Assert.That(bow2,Is.Not.EqualTo(bow1));
        Assert.That(bow1.AttackValue,Is.GreaterThan(bow2.AttackValue));
        Assert.That(bow2.AttackValue,Is.Not.GreaterThan(bow1.AttackValue));
    }
}