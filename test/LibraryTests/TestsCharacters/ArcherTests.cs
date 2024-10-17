  
using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace Library.Tests
{
    public class ArcherTests
    {
        private Archer archer;

        [SetUp]
        public void Setup()
        {
            archer = new Archer("Legolas");
        }

        [Test]
        public void ArcherInitialization_IsCorrect()
        {
            // Assert
            Assert.That(archer.Name, Is.EqualTo("Legolas"));
            Assert.That(archer.Health, Is.EqualTo(100));
            bool hasBow = false;
            foreach (var item in archer.Items)
            {
                if (item is Bow)
                {
                    hasBow = true;
                }
            }
            Assert.That(hasBow, Is.True);
        }
        
        [Test]
        public void AddItem_ItemIsStoredAndAccesedCorrectly()
        {
            // Arrange
            Archer archer = new Archer("Legolas");

            // Act
            archer.AddItem(new Axe());

            // Assert
            bool hasAxe = false;
            foreach (var item in archer.Items)
            {
                if (item is Axe)
                {
                    hasAxe = true;
                }
            }
            Assert.That(hasAxe, Is.True);
        }

        [Test]
        public void RemoveItem_ItemIsRemovedAndCannotBeAccesed()
        {
            // Arrange
            Archer archer = new Archer("Legolas");

            // Act
            Axe axe = new Axe();
            archer.AddItem(axe);
            archer.RemoveItem(axe);

            // Assert
            bool hasAxe = false;
            foreach (var item in archer.Items)
            {
                if (item is Axe)
                {
                    hasAxe = true;
                }
            }
            Assert.That(hasAxe, Is.False);
        }
        
        [Test]
        public void ReceiveAttack_WithPowerGreaterThanDefense_DecreasesHealthCorrectly()
        {
            // Arrange
            Shield shield = new Shield(); // Defensa: 14
            archer.AddItem(shield); 
            int initialHealth = archer.Health; // 100
            int attackPower = 50;

            // Act
            archer.ReceiveAttack(attackPower);

            // Assert
            int expectedHealth = initialHealth - attackPower + archer.DefenseValue; // 100 - 50 + (14 + 18)  = 64
            Assert.That(archer.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void ReceiveAttack_WithPowerLessThanOrEqualToDefense_HealthUnchanged()
        {
            // Arrange
            Shield shield = new Shield(); // Defensa: 14
            archer.AddItem(shield);
            int initialHealth = archer.Health; // 100
            int attackPower = 10;

            // Act
            archer.ReceiveAttack(attackPower);

            // Assert
            Assert.That(archer.Health, Is.EqualTo(initialHealth));
        }

        [Test]
        public void ReceiveAttack_HealthDoesNotDropBelowZero()
        {
            // Arrange
            Shield shield = new Shield(); // Defensa: 14
            archer.AddItem(shield);
            int attackPower = 200;

            // Act
            archer.ReceiveAttack(attackPower);

            // Assert
            Assert.That(archer.Health, Is.EqualTo(0)); // La salud mínima es 0
        }
       
        [Test]
        public void Cure_RestoresHealthTo100()
        {
            // Arrange
            archer.ReceiveAttack(80); 

            // Act
            archer.Cure();

            // Assert
            Assert.That(archer.Health, Is.EqualTo(100));
        }
    }
}

