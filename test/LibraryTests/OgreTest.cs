using NUnit.Framework;
using Program;

namespace Library.Tests
{
    public class OgreTests
    {
        [Test]
        public void Constructor_IniciaCorrectamente_1()
        {
            // Arrange
            string name = "Grommash";
            int amountLife = 250;
            int initialLife = 300;
            int vp = 70;

            // Act
            Ogre ogre = new Ogre(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(ogre.Name, Is.EqualTo(name));
            Assert.That(ogre.AmountLife, Is.EqualTo(amountLife));
            Assert.That(ogre.InitialLife, Is.EqualTo(initialLife));
            Assert.That(ogre.VP, Is.EqualTo(vp));
        }
        [Test]
        public void Constructor_NombreNulo_1()
        {
            // Arrange
            string name = null;
            int amountLife = 250;
            int initialLife = 300;
            int vp = 70;

            // Act
            Ogre ogre = new Ogre(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(ogre.Name, Is.EqualTo(null));
            Assert.That(ogre.AmountLife, Is.EqualTo(amountLife));
            Assert.That(ogre.InitialLife, Is.EqualTo(initialLife));
            Assert.That(ogre.VP, Is.EqualTo(vp));
        }
        [Test]
        public void Constructor_SinNombre_1()
        {
            // Arrange
            string name = "";
            int amountLife = 250;
            int initialLife = 300;
            int vp = 70;

            // Act
            Ogre ogre = new Ogre(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(ogre.Name, Is.EqualTo(""));
            Assert.That(ogre.AmountLife, Is.EqualTo(amountLife));
            Assert.That(ogre.InitialLife, Is.EqualTo(initialLife));
            Assert.That(ogre.VP, Is.EqualTo(vp));
        }
        [Test]
        public void Constructor_CantidadDeVida_1()
        {
            // Arrange
            string name = "Grothok";
            int amountLife = 150;
            int initialLife = 250;
            int vp = 45;

            // Act
            Ogre ogre = new Ogre(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(ogre.Name, Is.EqualTo(name));
            Assert.That(ogre.AmountLife, Is.GreaterThan(0));
            Assert.That(ogre.AmountLife, Is.Not.Negative);
            Assert.That(ogre.InitialLife, Is.EqualTo(initialLife));
            Assert.That(ogre.VP, Is.EqualTo(vp));
        }
        [Test]
        public void Constructor_VidaInicial_1()
        {
            // Arrange
            string name = "Grothok";
            int amountLife = 150;
            int initialLife = 250;
            int vp = 45;

            // Act
            Ogre ogre = new Ogre(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(ogre.Name, Is.EqualTo(name));
            Assert.That(ogre.AmountLife, Is.EqualTo(amountLife));
            Assert.That(ogre.InitialLife, Is.GreaterThan(0));
            Assert.That(ogre.InitialLife, Is.Not.Negative);
            Assert.That(ogre.VP, Is.EqualTo(vp));
        }
        [Test]
        public void Constructor_VPNoDeberiaSerNegativo_1()
        {
            // Arrange
            string name = "Grothok";
            int amountLife = 150;
            int initialLife = 250;
            int vp = 45;

            // Act
            Ogre ogre = new Ogre(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(ogre.Name, Is.EqualTo(name));
            Assert.That(ogre.AmountLife, Is.EqualTo(amountLife));
            Assert.That(ogre.InitialLife, Is.EqualTo(initialLife));
            Assert.That(ogre.VP, Is.Not.Negative);
        }
        [Test]
        public void Multiples_Ogros_1()
        {
            // Arrange
            string name1 = "Grothok";
            int amountLife1 = 150;
            int initialLife1 = 250;
            int vp1 = 45;
            string name2 = "Krulg";
            int amountLife2 = 120;
            int initialLife2 = 150;
            int vp2 = 13;
            
            // Act
            Ogre ogre1 = new Ogre(name1, amountLife1, initialLife1, vp1);
            Ogre ogre2 = new Ogre(name2, amountLife2, initialLife2, vp2);
            
            //Assert
            Assert.That(ogre1,Is.Not.EqualTo(ogre2));
            Assert.That(ogre2,Is.Not.EqualTo(ogre1));
        }
        [Test]
        public void AtaqueDeOgreDeberiaReducirLaVidaDelEnemigo()
        {
            // Arrange
            Ogre ogre = new Ogre("Krulg", 120, 150, 13);
            GoodGuy dwarf = new GoodGuy("Orc", 80, 80);
            ogre.Element.Add(new Sword("Hacha", 20,5)); 

            // Act
            ogre.Attack(dwarf);

            // Assert
            Assert.That(dwarf.AmountLife, Is.LessThan(80));
        }

        [Test]
        public void OgroGanaVP()
        {
            // Arrange
            Ogre ogre = new Ogre("Destructor", 100, 100, 0);
            GoodGuy dwarf = new GoodGuy("Mimi", 10, 10); 

            ogre.Element.Add(new Sword("Hacha", 20,5));

            // Act
            ogre.Attack(dwarf);

            // Assert
            Assert.That(dwarf.AmountLife, Is.EqualTo(0));   
            Assert.That(ogre.VP, Is.GreaterThanOrEqualTo(5)); 
        }

        [Test]
        public void OgreSeCuraConVPMayorA5()
        {
            // Arrange
            Ogre ogre = new Ogre("Pedro", 50, 100, 5);
            GoodGuy boss = new GoodGuy("Boss", 10, 10);

            ogre.Element.Add(new Sword("Hacha", 20,5));

            // Act
            ogre.Attack(boss);

            // Assert
            Assert.That(ogre.AmountLife, Is.EqualTo(100)); 
        }
        [TestFixture]
        public class CharacterTests
        {
            [Test]
            public void ExchangeItem_Ogre()
            {
                // Arrange
                var character = new Ogre("Jose", 100, 100, 10);
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
            public void AddItem_Ogre()
            {
                var character = new Ogre("Jose", 100, 100,5);
                IItem item = new Sword("Espada", 10,15); 
                character.AddItem(item);
                Assert.That(character.Element.Count, Is.EqualTo(1));
            }
            [Test]
            public void IsAlive_ShouldReturnTrue_IfLifeAboveZero_Ogre()
            {
                var character = new Ogre("Aniquilador", 10, 100,5);
                Assert.That(character.IsAlive(), Is.True);
            }

            [Test]
            public void IsAlive_ShouldReturnFalse_IfLifeZero_Ogre()
            {
                var character = new Ogre("Destruyemundos", 0, 100,5);
                Assert.That(character.IsAlive(), Is.False);
            }
        }

    }
}