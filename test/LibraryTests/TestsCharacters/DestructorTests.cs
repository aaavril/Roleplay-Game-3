using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace Library.Tests
{
    public class DestructorTests
    {
        private Destructor destructor;

        [SetUp]
        public void Setup()
        {
            destructor = new Destructor("Destructor");
        }

        [Test]
        public void DestructorInitialization_IsCorrect()
        {
            // Assert
            Assert.That(destructor.Name, Is.EqualTo("Destructor"));
            Assert.That(destructor.Health, Is.EqualTo(100)); // Salud inicial
            Assert.That(destructor.Items.Count, Is.EqualTo(2)); // Debería tener 2 items (Axe y Shield)
        }

        [Test]
        public void AttackValue_Calculation_IsCorrect()
        {
            // Act
            int attackValue = destructor.AttackValue;

            // Assert
            Assert.That(attackValue, Is.EqualTo(25)); // Axe tiene AttackValue de 25
        }

        [Test]
        public void DefenseValue_Calculation_IsCorrect()
        {
            // Act
            int defenseValue = destructor.DefenseValue;

            // Assert
            Assert.That(defenseValue, Is.EqualTo(14)); // Shield tiene DefenseValue de 14
        }

        [Test]
        public void ReceiveAttack_WithHigherPower_ShouldReduceHealth()
        {
            // Act
            destructor.ReceiveAttack(30); // Ataque con poder 30

            // Assert
            Assert.That(destructor.Health, Is.EqualTo(100 - (30 - destructor.DefenseValue))); // 100 - (30 - 14)
        }
        
        [Test]
        public void Cure_ShouldRestoreHealthTo100()
        {
            // Arrange
            destructor.ReceiveAttack(50); // Reduce la salud a 50

            // Act
            destructor.Cure(); // Curar al Destructor

            // Assert
            Assert.That(destructor.Health, Is.EqualTo(100)); // Salud debe ser restaurada a 100
        }

        [Test]
        public void AddItem_ShouldIncreaseItemsCount()
        {
            // Arrange
            var newItem = new Helmet(); // Suponiendo que Helmet es otro IItem

            // Act
            destructor.AddItem(newItem);

            // Assert
            Assert.That(destructor.Items.Count, Is.EqualTo(3)); // Debería tener ahora 3 items
        }

        [Test]
        public void RemoveItem_ShouldDecreaseItemsCount()
        {
            // Arrange
            var axe = destructor.Items.FirstOrDefault(item => item is Axe); // Obtener el Axe existente

            // Act
            destructor.RemoveItem(axe);

            // Assert
            Assert.That(destructor.Items.Count, Is.EqualTo(1)); // Debería tener ahora 1 item (solo el Shield)
        }
    }
}