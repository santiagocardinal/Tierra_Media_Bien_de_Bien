using NUnit.Framework;
using Library;

namespace Library.Tests
{
    public class DwarfTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            string name = "Gimli";
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Dwarf dwarf = new Dwarf(name, amountLife, initialLife);

            // Assert
            Assert.That(dwarf.Name, Is.EqualTo(name));
            Assert.That(dwarf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(dwarf.InitialLife, Is.EqualTo(initialLife));
        }
        [Test]
        public void Constructor_NullName()
        {
            // Arrange
            string name = null;
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Dwarf dwarf = new Dwarf(name, amountLife, initialLife);

            // Assert
            Assert.That(dwarf.Name, Is.EqualTo(null));
            Assert.That(dwarf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(dwarf.InitialLife, Is.EqualTo(initialLife));
       }
        [Test]
        public void Constructor_WithoutName()
        {
            // Arrange
            string name = "";
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Dwarf dwarf = new Dwarf(name, amountLife, initialLife);

            // Assert
            Assert.That(dwarf.Name, Is.EqualTo(""));
            Assert.That(dwarf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(dwarf.InitialLife, Is.EqualTo(initialLife));
        }
        [Test]
        public void Constructor_AmountLife()
        {
            // Arrange
            string name = "Jose";
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Dwarf dwarf = new Dwarf(name, amountLife, initialLife);

            // Assert
            Assert.That(dwarf.Name, Is.EqualTo(name));
            Assert.That(dwarf.AmountLife, Is.GreaterThan(0));
            Assert.That(dwarf.AmountLife, Is.Not.Negative);
            Assert.That(dwarf.InitialLife, Is.EqualTo(initialLife));
        }
        [Test]
        public void Constructor_InitialLife()
        {
            // Arrange
            string name = "Jose";
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Dwarf dwarf = new Dwarf(name, amountLife, initialLife);

            // Assert
            Assert.That(dwarf.Name, Is.EqualTo(name));
            Assert.That(dwarf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(dwarf.InitialLife, Is.GreaterThan(0));
            Assert.That(dwarf.InitialLife, Is.Not.Negative);
        }
        [Test]
        public void Constructor_VPShoudNotBeNegative()
        {
            // Arrange
            string name = "Jose";
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Dwarf dwarf = new Dwarf(name, amountLife, initialLife);

            // Assert
            Assert.That(dwarf.Name, Is.EqualTo(name));
            Assert.That(dwarf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(dwarf.InitialLife, Is.EqualTo(initialLife));
        }
        [Test]
        public void Multiple_Dwarfs()
        {
            // Arrange
            string name1 = "Jose";
            int amountLife1 = 100;
            int initialLife1 = 100;
            string name2 = "Jose";
            int amountLife2 = 100;
            int initialLife2 = 100;
            
            // Act
            Dwarf dwarf1 = new Dwarf(name1, amountLife1, initialLife1);
            Dwarf dwarf2 = new Dwarf(name2, amountLife2, initialLife2);
            
            //Assert
            Assert.That(dwarf1,Is.Not.EqualTo(dwarf2));
            Assert.That(dwarf2,Is.Not.EqualTo(dwarf1));
        }
        [Test]
        public void Dwarf_Attack_ShouldReduceEnemyLife()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Gimli", 100, 100);
            BadGuy ogre = new BadGuy("Orc", 80, 80, 3);
            dwarf.Element.Add(new Sword("Hacha", 20,5)); 

            // Act
            dwarf.Attack(ogre);

            // Assert
            Assert.That(ogre.AmountLife, Is.LessThan(80));
        }

        [Test]
        public void Dwarf_ShouldGainVP_WhenEnemyDies()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Gimli", 100, 100);
            BadGuy ogre = new BadGuy("Orc", 10, 10, 5); 

            dwarf.Element.Add(new Sword("Hacha", 20,5));

            // Act
            dwarf.Attack(ogre);

            // Assert
            Assert.That(ogre.AmountLife, Is.EqualTo(0));   
            Assert.That(dwarf.VP, Is.GreaterThanOrEqualTo(5)); 
        }

        [Test]
        public void Dwarf_ShouldHeal_WhenVPExceeds5()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Gimli", 50, 100);
            BadGuy boss = new BadGuy("Boss", 10, 10, 6);

            dwarf.Element.Add(new Sword("Hacha", 20,5));

            // Act
            dwarf.Attack(boss);

            // Assert
            Assert.That(dwarf.AmountLife, Is.EqualTo(100)); 
        }
        [TestFixture]
        public class CharacterTests
        {
            [Test]
            public void ExchangeItem_ShouldReplaceCorrectElement()
            {
                // Arrange
                var character = new Dwarf("Jose", 100, 100);
                IItem espada = new Sword("Espada", 10, 15);
                IItem hacha = new Sword("Hacha", 15, 16);

                character.AddItem(espada);
                Assert.That(character.Element, Does.Contain(espada)); // estado inicial

                // Act
                character.ExchangeItem(espada, hacha);

                // Assert
                Assert.That(character.Element, Does.Contain(hacha));
                Assert.That(character.Element, Does.Not.Contain(espada));
            }
            [Test]
            public void AddItem_ShouldIncreaseElementList()
            {
                var character = new Dwarf("Jose", 100, 100);
                IItem item = new Sword("Espada", 10,15); 
                character.AddItem(item);
                Assert.That(character.Element.Count, Is.EqualTo(1));
            }
            [Test]
            public void IsAlive_ShouldReturnTrue_IfLifeAboveZero()
            {
                var character = new Dwarf("Alfonso", 10, 100);
                Assert.That(character.IsAlive(), Is.True);
            }

            [Test]
            public void IsAlive_ShouldReturnFalse_IfLifeZero()
            {
                var character = new Dwarf("Alfonso", 0, 100);
                Assert.That(character.IsAlive(), Is.False);
            }
        }

    }
}