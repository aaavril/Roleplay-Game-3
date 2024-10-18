using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace Library.Tests;

public class HannibalTests
{
    private Hannibal hannibal;

    [SetUp]
    public void Setup()
    {
        hannibal = new Hannibal("Hannibal");
    }

    [Test]
    public void HannibalInitialization_IsCorrect()
    {
        // Assert
        Assert.That(hannibal.Name, Is.EqualTo("Hannibal"));
        Assert.That(hannibal.Health, Is.EqualTo(100)); // Salud inicial
        Assert.That(hannibal.Items.Count, Is.EqualTo(2)); // Debería tener 2 items (Bow y Staff)
    }

    [Test]
    public void AttackValue_Calculation_IsCorrect()
    {
        // Act
        int attackValue = hannibal.AttackValue;

        // Assert
        Assert.That(attackValue, Is.EqualTo(115)); // Bow tiene AttackValue de 15
    }

    [Test]
    public void DefenseValue_Calculation_IsCorrect()
    {
        // Act
        int defenseValue = hannibal.DefenseValue;

        // Assert
        Assert.That(defenseValue, Is.EqualTo(100)); // Staff no tiene valor de defensa
    }

    [Test]
    public void ReceiveAttack_ShouldReduceHealth()
    {
        // Act
        hannibal.ReceiveAttack(120); // Ataque con poder 30

        // Assert
        Assert.That(hannibal.Health, Is.EqualTo(80)); 
    }

    [Test]
    public void Cure_ShouldRestoreHealthTo100()
    {
        // Arrange
        hannibal.ReceiveAttack(50); // Reduce la salud a 50

        // Act
        hannibal.Cure(); // Curar a Hannibal

        // Assert
        Assert.That(hannibal.Health, Is.EqualTo(100)); // Salud debe ser restaurada a 100
    }

    [Test]
    public void AddItem_ShouldIncreaseItemsCount()
    {
        // Arrange
        var newItem = new Helmet(); // Suponiendo que Helmet es otro IItem

        // Act
        hannibal.AddItem(newItem);

        // Assert
        Assert.That(hannibal.Items.Count, Is.EqualTo(3)); // Debería tener ahora 3 items
    }

    [Test]
    public void RemoveItem_ShouldDecreaseItemsCount()
    {
        // Arrange
        var bow = hannibal.Items.FirstOrDefault(item => item is Bow); // Obtener el Bow existente

        // Act
        hannibal.RemoveItem(bow);

        // Assert
        Assert.That(hannibal.Items.Count, Is.EqualTo(1)); // Debería tener ahora 1 item (solo el Staff)
    }
}
    