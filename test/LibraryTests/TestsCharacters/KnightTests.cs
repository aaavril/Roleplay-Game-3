using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace Library.Tests
{
    public class KnightTests
    {
        private Knight knight;

        [SetUp]
        public void Setup()
        {
            knight = new Knight("Arthur");
        }

        [Test]
        public void KnightInitializationTest()
        {
            // Assert
            Assert.That(knight.Name, Is.EqualTo("Arthur"));
            Assert.That(knight.Health, Is.EqualTo(100));
            
            bool hasSword = false;
            bool hasArmor = false;
            bool hasShield = false;

            foreach (var item in knight.Items)
            {
                if (item is Sword) hasSword = true;
                if (item is Armor) hasArmor = true;
                if (item is Shield) hasShield = true;
            }

            Assert.That(hasSword, Is.True);
            Assert.That(hasArmor, Is.True);
            Assert.That(hasShield, Is.True);
        }

        [Test]
        public void AddItemTest()
        {
            // Arrange
            knight.AddItem(new Sword());

            // Assert
            bool hasSword = false;
            foreach (var item in knight.Items)
            {
                if (item is Sword) hasSword = true;
            }
            Assert.That(hasSword, Is.True);
        }

        [Test]
        public void RemoveItemTest()
        {
            // Arrange
            Axe axe = new Axe();
            knight.AddItem(axe);

            // Act
            knight.RemoveItem(axe);

            // Assert
            bool hasAxe = false;
            foreach (var item in knight.Items)
            {
                if (item is Axe) hasAxe = true;
            }
            Assert.That(hasAxe, Is.False);
        }

        [Test]
        public void ReceiveAttack_WithPowerGreaterThanDefense_DecreasesHealthCorrectly()
        {
            // Arrange
            int initialHealth = knight.Health; // 100
            int attackPower = 50; // Ataque: 50, Defensa total: 39 (25 + 14)

            // Act
            knight.ReceiveAttack(attackPower);

            // Assert
            int expectedHealth = initialHealth - attackPower + knight.DefenseValue; // 100 - 50 + 39 = 89
            Assert.That(knight.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void ReceiveAttack_WithPowerLessThanOrEqualToDefense_HealthUnchanged()
        {
            // Arrange
            int initialHealth = knight.Health; // 100
            int attackPower = 30; // Defensa total: 39

            // Act
            knight.ReceiveAttack(attackPower);

            // Assert
            Assert.That(knight.Health, Is.EqualTo(initialHealth));
        }

        [Test]
        public void ReceiveAttack_HealthDoesNotDropBelowZero()
        {
            // Arrange
            int attackPower = 200; // Gran ataque para probar límite

            // Act
            knight.ReceiveAttack(attackPower);

            // Assert
            Assert.That(knight.Health, Is.EqualTo(0)); // Salud mínima es 0
        }

        [Test]
        public void Cure_RestoresHealthTo100()
        {
            // Arrange
            knight.ReceiveAttack(80); // Reducimos salud

            // Act
            knight.Cure();

            // Assert
            Assert.That(knight.Health, Is.EqualTo(100));
        }
    }
}
