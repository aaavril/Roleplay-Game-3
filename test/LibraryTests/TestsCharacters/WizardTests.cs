using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace Library.Tests
{
    public class WizardTests
    {
        private Wizard wizard;

        [SetUp]
        public void Setup()
        {
            wizard = new Wizard("Gandalf");
        }

        [Test]
        public void WizardInitialization_IsCorrect()
        {
            // Assert
            Assert.That(wizard.Name, Is.EqualTo("Gandalf"));
            Assert.That(wizard.Health, Is.EqualTo(100));

            bool hasStaff = false;

            foreach (var item in wizard.Items)
            {
                if (item is Staff) hasStaff = true;
            }

            Assert.That(hasStaff, Is.True);
        }

        [Test]
        public void AddItem_ItemIsAdded()
        {
            // Act
            wizard.AddItem(new Axe());

            // Assert
            bool hasAxe = false;
            foreach (var item in wizard.Items)
            {
                if (item is Axe) hasAxe = true;
            }
            Assert.That(hasAxe, Is.True);
        }

        [Test]
        public void RemoveItem_ItemIsRemoved()
        {
            // Arrange
            Axe axe = new Axe();
            wizard.AddItem(axe);

            // Act
            wizard.RemoveItem(axe);

            // Assert
            bool hasAxe = false;
            foreach (var item in wizard.Items)
            {
                if (item is Axe) hasAxe = true;
            }
            Assert.That(hasAxe, Is.False);
        }

        [Test]
        public void AddMagicalItem_ItemIsAdded()
        {
            // Act
            SpellsBook spellsBook = new SpellsBook();
            wizard.AddItem(spellsBook);

            // Assert
            bool hasSpellsBook = false;
            foreach (var item in wizard.MagicalItems)
            {
                if (item is SpellsBook) hasSpellsBook = true;
            }
            Assert.That(hasSpellsBook, Is.True);
        }

        [Test]
        public void RemoveMagicalItem_ItemIsRemoved()
        {
            // Arrange
            SpellsBook spellsBook = new SpellsBook();
            wizard.AddItem(spellsBook);

            // Act
            wizard.RemoveItem(spellsBook);

            // Assert
            bool hasSpellsBook = false;
            foreach (var item in wizard.Items)
            {
                if (item is SpellsBook) hasSpellsBook = true;
            }
            Assert.That(hasSpellsBook, Is.False);
        }

        [Test]
        public void AttackValue_WithItemsAndSpells_ShouldCalculateCorrectly()
        {
            // Arrange
            var spellOne = new SpellOne(); // Crea un hechizo con AttackValue 70
            var spellsBook = new SpellsBook();
            spellsBook.AddSpell(spellOne); // Agrega el hechizo al libro de hechizos
            wizard.AddItem(spellsBook); // Agrega el libro de hechizos al mago

            // Act
            int attackValue = wizard.AttackValue; // Obtiene el valor de ataque

            // Assert
            Assert.That(attackValue, Is.EqualTo(170)); // Verifica que sea 70
        }

        [Test]
        public void DefenseValue_WithItemsAndSpells_ShouldCalculateCorrectly()
        {
            // Arrange
            var spellOne = new SpellOne(); // Crea un hechizo con DefenseValue 70
            var spellsBook = new SpellsBook();
            spellsBook.AddSpell(spellOne); // Agrega el hechizo al libro de hechizos
            wizard.AddItem(spellsBook); // Agrega el libro de hechizos al mago

            // Act
            int defenseValue = wizard.DefenseValue; // Obtiene el valor de defensa

            // Assert
            Assert.That(defenseValue, Is.EqualTo(170)); // Verifica que sea 70
        }

        [Test]
        public void ReceiveAttack_WhenPowerGreaterThanDefense_ShouldReduceHealth()
        {
            // Arrange
            int initialHealth = wizard.Health;
            int attackPower = 120;

            // Act
            wizard.ReceiveAttack(attackPower);

            // Assert
            int expectedHealth = initialHealth - attackPower + wizard.DefenseValue;
            Assert.That(wizard.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void ReceiveAttack_WhenPowerLessThanOrEqualToDefense_ShouldNotChangeHealth()
        {
            // Arrange
            var shield = new Shield(); // Defensa: 14
            wizard.AddItem(shield);
            int initialHealth = wizard.Health;

            // Act
            wizard.ReceiveAttack(10);

            // Assert
            Assert.That(wizard.Health, Is.EqualTo(initialHealth));
        }

        [Test]
        public void ReceiveAttack_WhenPowerIsHighEnough_ShouldNotDropHealthBelowZero()
        {
            // Arrange
            int attackPower = 200;

            // Act
            wizard.ReceiveAttack(attackPower);

            // Assert
            Assert.That(wizard.Health, Is.EqualTo(0));
        }

        [Test]
        public void Cure_WhenCalled_ShouldRestoreHealthTo100()
        {
            // Arrange
            wizard.ReceiveAttack(80); 

            // Act
            wizard.Cure();

            // Assert
            Assert.That(wizard.Health, Is.EqualTo(100));
        }
    }
}
