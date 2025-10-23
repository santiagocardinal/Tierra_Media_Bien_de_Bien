using NUnit.Framework;
using Program;

namespace Library.Tests
{
    public class ElfTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            string name = "Gimli";
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Elf elf= new Elf(name, amountLife, initialLife);

            // Assert
            Assert.That(elf.Name, Is.EqualTo(name));
            Assert.That(elf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(elf.InitialLife, Is.EqualTo(initialLife));
        }
        [Test]
        public void Constructor_NullName()
        {
            // Arrange
            string name = null;
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Elf elf= new Elf(name, amountLife, initialLife);

            // Assert
            Assert.That(elf.Name, Is.EqualTo(null));
            Assert.That(elf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(elf.InitialLife, Is.EqualTo(initialLife));
        }
        [Test]
        public void Constructor_WithoutName()
        {
            // Arrange
            string name = "";
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Elf elf= new Elf(name, amountLife, initialLife);

            // Assert
            Assert.That(elf.Name, Is.EqualTo(""));
            Assert.That(elf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(elf.InitialLife, Is.EqualTo(initialLife));
        }
        [Test]
        public void Constructor_AmountLife()
        {
            // Arrange
            string name = "Jose";
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Elf elf= new Elf(name, amountLife, initialLife);

            // Assert
            Assert.That(elf.Name, Is.EqualTo(name));
            Assert.That(elf.AmountLife, Is.GreaterThan(0));
            Assert.That(elf.AmountLife, Is.Not.Negative);
            Assert.That(elf.InitialLife, Is.EqualTo(initialLife));
        }
        [Test]
        public void Constructor_InitialLife()
        {
            // Arrange
            string name = "Jose";
            int amountLife = 100;
            int initialLife = 100;

            // Act
            Elf elf= new Elf(name, amountLife, initialLife);

            // Assert
            Assert.That(elf.Name, Is.EqualTo(name));
            Assert.That(elf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(elf.InitialLife, Is.GreaterThan(0));
            Assert.That(elf.InitialLife, Is.Not.Negative);
        }
        [Test]
        public void Constructor_VPShoudNotBeNegative()
        {
            // Arrange
            string name = "Jose";
            int amountLife = 100;
            int initialLife = 100;
            int vp = 50;

            // Act
            Elf elf= new Elf(name, amountLife, initialLife);

            // Assert
            Assert.That(elf.Name, Is.EqualTo(name));
            Assert.That(elf.AmountLife, Is.EqualTo(amountLife));
            Assert.That(elf.InitialLife, Is.EqualTo(initialLife));
            Assert.That(elf.VP, Is.Not.Negative);
        }
        [Test]
        public void Multiple_Elfs()
        {
            // Arrange
            string name1 = "Jose";
            int amountLife1 = 100;
            int initialLife1 = 100;
            int vp1 = 50;
            string name2 = "Jose";
            int amountLife2 = 100;
            int initialLife2 = 100;
            int vp2 = 50;
            
            // Act
            Elf elf1= new Elf(name1, amountLife1, initialLife1);
            Elf elf2= new Elf(name2, amountLife2, initialLife2);
            
            //Assert
            Assert.That(elf1,Is.Not.EqualTo(elf2));
            Assert.That(elf2,Is.Not.EqualTo(elf1));
        }
        [Test]
        public void Dwarf_Attack_ShouldReduceEnemyLife()
        {
            // Arrange
            Elf elf= new Elf("Gimpli", 100, 100);
            BadGuy ogre = new BadGuy("Orc", 80, 80, 3);
            elf.Element.Add(new Sword("Hacha", 20,5)); 

            // Act
            elf.Attack(ogre);

            // Assert
            Assert.That(ogre.AmountLife, Is.LessThan(80));
        }

        [Test]
        public void Dwarf_ShouldGainVP_WhenEnemyDies()
        {
            // Arrange
            Elf elf= new Elf("Gimpli", 100, 100);
            BadGuy ogre = new BadGuy("Orc", 10, 10, 5); 

            elf.Element.Add(new Sword("Hacha", 20,5));

            // Act
            elf.Attack(ogre);

            // Assert
            Assert.That(ogre.AmountLife, Is.EqualTo(0));   
            Assert.That(elf.VP, Is.GreaterThanOrEqualTo(5)); 
        }

        [Test]
        public void Dwarf_ShouldHeal_WhenVPExceeds5()
        {
            // Arrange
            Elf elf= new Elf("Gimpli", 100, 100);
            BadGuy boss = new BadGuy("Boss", 10, 10, 2);

            elf.Element.Add(new Sword("Hacha", 20,5));

            // Act
            elf.Attack(boss);

            // Assert
            Assert.That(elf.AmountLife, Is.EqualTo(100)); 
        }
        [TestFixture]
        public class CharacterTests
        {
            [Test]
            public void ExchangeItem_ShouldReplaceCorrectElement()
            {
                // Arrange
                var character = new Elf("Gimpli", 100, 100);
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
                var character = new Elf("Gimpli", 100, 100);
                IItem item = new Sword("Espada", 10,15); 
                character.AddItem(item);
                Assert.That(character.Element.Count, Is.EqualTo(1));
            }
            [Test]
            public void IsAlive_ShouldReturnTrue_IfLifeAboveZero()
            {
                var character = new Elf("Gimpli", 10, 100);
                Assert.That(character.IsAlive(), Is.True);
            }

            [Test]
            public void IsAlive_ShouldReturnFalse_IfLifeZero()
            {
                var character = new Elf("Gimpli", 0, 100);
                Assert.That(character.IsAlive(), Is.False);
            }
        }

    }
}