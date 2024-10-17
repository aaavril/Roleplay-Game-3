using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace Library.Tests
{
    public class DwarfTests
    {
        private Dwarf dwarf;

        [SetUp]
        public void Setup()
        {
            dwarf = new Dwarf("Gimli");
        }

        [Test]
        public void DwarfInitialization_IsCorrect()
        {
            // Assert
            Assert.That(dwarf.Name, Is.EqualTo("Gimli"));
            Assert.That(dwarf.Health, Is.EqualTo(100));
            bool hasAxe = false;
            bool hasHelmet = false;

            foreach (var item in dwarf.Items)
            {
                if (item is Axe)
                {
                    hasAxe = true;
                }
                if (item is Helmet)
                {
                    hasHelmet = true;
                }
            }

            Assert.That(hasAxe, Is.True);
            Assert.That(hasHelmet, Is.True);
        }

        [Test]
        public void AddItem_ItemIsStoredAndAccesedCorrectly()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Gimli");

            // Act
            dwarf.AddItem(new Sword());

            // Assert
            bool hasSword = false;
            foreach (var item in dwarf.Items)
            {
                if (item is Sword)
                {
                    hasSword = true;
                }
            }
            Assert.That(hasSword, Is.True);
        }

        [Test]
        public void RemoveItem_ItemIsRemovedAndCannotBeAccesed()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Gimli");

            // Act
            Bow bow = new Bow();
            dwarf.AddItem(bow);
            dwarf.RemoveItem(bow);

            // Assert
            bool hasBow = false;
            foreach (var item in dwarf.Items)
            {
                if (item is Bow)
                {
                    hasBow = true;
                }
            }
            Assert.That(hasBow, Is.False);
        }

        [Test]
        public void ReceiveAttack_WithPowerGreaterThanDefense_DecreasesHealthCorrectly()
        {
            // Arrange
            int initialHealth = dwarf.Health; // 100
            int attackPower = 50;

            // Act
            dwarf.ReceiveAttack(attackPower);

            // Assert
            int expectedHealth = initialHealth - (attackPower - dwarf.DefenseValue); // 100 - (50 - 18) = 68
            Assert.That(dwarf.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void ReceiveAttack_WithPowerLessThanOrEqualToDefense_HealthUnchanged()
        {
            // Arrange
            int initialHealth = dwarf.Health; // 100
            int attackPower = 10;

            // Act
            dwarf.ReceiveAttack(attackPower);

            // Assert
            Assert.That(dwarf.Health, Is.EqualTo(initialHealth));
        }

        [Test]
        public void ReceiveAttack_HealthDoesNotDropBelowZero()
        {
            // Arrange
            int attackPower = 200;

            // Act
            dwarf.ReceiveAttack(attackPower);

            // Assert
            Assert.That(dwarf.Health, Is.EqualTo(0)); // La salud mínima es 0
        }

        [Test]
        public void Cure_RestoresHealthTo100()
        {
            // Arrange
            dwarf.ReceiveAttack(80); 

            // Act
            dwarf.Cure();

            // Assert
            Assert.That(dwarf.Health, Is.EqualTo(100));
        }
    }
}
