using Program;

namespace LibraryTests;

public class StickTest
{
    [Test]
    public void Constructor_FullParameters()
    {
        string name = "Super palo";
        int attack = 100;

        Stick stick = new Stick(name, attack);

        Assert.That(stick.Name, Is.EqualTo(name));
        Assert.That(stick.Name, Is.Not.EqualTo(null));
        Assert.That(stick.AttackValue, Is.EqualTo(attack));
        Assert.That(stick.AttackValue, Is.Not.Negative);


    }
    [Test]
    public void Name_ShouldBeMutable()
    {
        // Arrange
        Stick stick = new Stick("Short stick", 10);

        // Act
        stick.Name = "Long stick";

        // Assert
        Assert.That(stick.Name, Is.EqualTo("Long stick"));
    }
    [Test]
    public void AttackValue_ShouldBeMutable()
    {
        // Arrange
        Stick stick = new Stick("Shortstick", 10);

        // Act
        stick.AttackValue = 21;

        // Assert
        Assert.That(stick.AttackValue, Is.EqualTo(21));
    }
    [Test]
    public void CanBeCompared()
    {
        // Arrange
        string name1 = "Super palo";
        int attack1 = 100;
        string name2 = "Palo mortal";
        int attack2 = 50;


        // Act
        Stick stick1 = new Stick(name1, attack1);
        Stick stick2 = new Stick(name2, attack2);
        // Assert
        Assert.That(stick1, Is.Not.EqualTo(stick2));
        Assert.That(stick2,Is.Not.EqualTo(stick1));
        Assert.That(stick1.AttackValue,Is.GreaterThan(stick2.AttackValue));
        Assert.That(stick2.AttackValue,Is.Not.GreaterThan(stick1.AttackValue));
    }
}