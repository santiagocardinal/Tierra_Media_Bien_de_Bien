using NUnit.Framework;
using Program;

namespace Library.Tests
{
    public class VampireTests
    {
        [Test]
        public void Constructor_IniciaCorrectamente_2()
        {
            // Arrange
            string name = "Dracula";
            int amountLife = 250;
            int initialLife = 300;
            int vp = 70;

            // Act
            Vampire vampire = new Vampire(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(vampire.Name, Is.EqualTo(name));
            Assert.That(vampire.AmountLife, Is.EqualTo(amountLife));
            Assert.That(vampire.InitialLife, Is.EqualTo(initialLife));
            Assert.That(vampire.VP, Is.EqualTo(vp));
        }

        [Test]
        public void Constructor_NombreNulo_2()
        {
            // Arrange
            string name = null;
            int amountLife = 250;
            int initialLife = 300;
            int vp = 70;

            // Act
            Vampire vampire = new Vampire(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(vampire.Name, Is.EqualTo(null));
            Assert.That(vampire.AmountLife, Is.EqualTo(amountLife));
            Assert.That(vampire.InitialLife, Is.EqualTo(initialLife));
            Assert.That(vampire.VP, Is.EqualTo(vp));
        }

        [Test]
        public void Constructor_SinNombre_2()
        {
            // Arrange
            string name = "";
            int amountLife = 250;
            int initialLife = 300;
            int vp = 70;

            // Act
            Vampire vampire = new Vampire(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(vampire.Name, Is.EqualTo(""));
            Assert.That(vampire.AmountLife, Is.EqualTo(amountLife));
            Assert.That(vampire.InitialLife, Is.EqualTo(initialLife));
            Assert.That(vampire.VP, Is.EqualTo(vp));
        }

        [Test]
        public void Constructor_CantidadDeVida_2()
        {
            // Arrange
            string name = "Nosferatu";
            int amountLife = 150;
            int initialLife = 250;
            int vp = 45;

            // Act
            Vampire vampire = new Vampire(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(vampire.Name, Is.EqualTo(name));
            Assert.That(vampire.AmountLife, Is.GreaterThan(0));
            Assert.That(vampire.AmountLife, Is.Not.Negative);
            Assert.That(vampire.InitialLife, Is.EqualTo(initialLife));
            Assert.That(vampire.VP, Is.EqualTo(vp));
        }

        [Test]
        public void Constructor_VidaInicial_2()
        {
            // Arrange
            string name = "Nosferatu";
            int amountLife = 150;
            int initialLife = 250;
            int vp = 45;

            // Act
            Vampire vampire = new Vampire(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(vampire.Name, Is.EqualTo(name));
            Assert.That(vampire.AmountLife, Is.EqualTo(amountLife));
            Assert.That(vampire.InitialLife, Is.GreaterThan(0));
            Assert.That(vampire.InitialLife, Is.Not.Negative);
            Assert.That(vampire.VP, Is.EqualTo(vp));
        }

        [Test]
        public void Constructor_VPNoDeberiaSerNegativo_2()
        {
            // Arrange
            string name = "Nosferatu";
            int amountLife = 150;
            int initialLife = 250;
            int vp = 45;

            // Act
            Vampire vampire = new Vampire(name, amountLife, initialLife, vp);

            // Assert
            Assert.That(vampire.Name, Is.EqualTo(name));
            Assert.That(vampire.AmountLife, Is.EqualTo(amountLife));
            Assert.That(vampire.InitialLife, Is.EqualTo(initialLife));
            Assert.That(vampire.VP, Is.Not.Negative);
        }

        [Test]
        public void Multiples_Vampires_2()
        {
            // Arrange
            string name1 = "Vlad";
            int amountLife1 = 150;
            int initialLife1 = 250;
            int vp1 = 45;
            string name2 = "Alucard";
            int amountLife2 = 120;
            int initialLife2 = 150;
            int vp2 = 13;
            
            // Act
            Vampire vampire1 = new Vampire(name1, amountLife1, initialLife1, vp1);
            Vampire vampire2 = new Vampire(name2, amountLife2, initialLife2, vp2);
            
            //Assert
            Assert.That(vampire1, Is.Not.EqualTo(vampire2));
            Assert.That(vampire2, Is.Not.EqualTo(vampire1));
        }

        [Test]
        public void AtaqueDeVampireDeberiaReducirLaVidaDelEnemigo()
        {
            // Arrange
            Vampire vampire = new Vampire("Alucard", 120, 150, 13);
            GoodGuy elf = new GoodGuy("Legolas", 80, 80);
            vampire.Element.Add(new Sword("Daga", 20, 5)); 

            // Act
            vampire.Attack(elf);

            // Assert
            Assert.That(elf.AmountLife, Is.LessThan(80));
        }

        [Test]
        public void VampireGanaVP()
        {
            // Arrange
            Vampire vampire = new Vampire("Drac", 100, 100, 0);
            GoodGuy elf = new GoodGuy("Elrond", 10, 10); 

            vampire.Element.Add(new Sword("Daga", 20, 5));

            // Act
            vampire.Attack(elf);

            // Assert
            Assert.That(elf.AmountLife, Is.EqualTo(0));   
            Assert.That(vampire.VP, Is.GreaterThanOrEqualTo(5)); 
        }

        [Test]
        public void VampireSeCuraConVPMayorA5()
        {
            // Arrange
            Vampire vampire = new Vampire("Lestat", 50, 100, 5);
            GoodGuy elf = new GoodGuy("Legolas", 10, 10);

            vampire.Element.Add(new Sword("Daga", 20, 5));

            // Act
            vampire.Attack(elf);

            // Assert
            Assert.That(vampire.AmountLife, Is.EqualTo(100)); 
        }

        [TestFixture]
        public class CharacterTests
        {
            [Test]
            public void ExchangeItem_Vampire()
            {
                // Arrange
                var character = new Vampire("Jose", 100, 100, 10);
                IItem espada = new Sword("Espada", 10, 15);
                IItem daga = new Sword("Daga", 15, 16);

                character.AddItem(espada);
                Assert.That(character.Element, Does.Contain(espada)); // estado inicial

                // Act
                character.ExchangeItem(espada, daga);

                // Assert
                Assert.That(character.Element, Does.Contain(daga));
                Assert.That(character.Element, Does.Not.Contain(espada));
            }

            [Test]
            public void AddItem_Vampire()
            {
                var character = new Vampire("Jose", 100, 100, 5);
                IItem item = new Sword("Daga", 10, 15); 
                character.AddItem(item);
                Assert.That(character.Element.Count, Is.EqualTo(1));
            }

            [Test]
            public void IsAlive_ShouldReturnTrue_IfLifeAboveZero_Vampire()
            {
                var character = new Vampire("Sanguinario", 10, 100, 5);
                Assert.That(character.IsAlive(), Is.True);
            }

            [Test]
            public void IsAlive_ShouldReturnFalse_IfLifeZero_Vampire()
            {
                var character = new Vampire("Inmortal", 0, 100, 5);
                Assert.That(character.IsAlive(), Is.False);
            }
        }

    }
}
