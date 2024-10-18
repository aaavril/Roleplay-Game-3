using Ucu.Poo.RoleplayGame;
using NUnit.Framework;
namespace Library.Tests;

public class NessyTests
{
    private Nessy nessy;

    [SetUp]
    public void Setup()
    {
        nessy = new Nessy("Nessy");
    }

    [Test]
    public void Constructor_ShouldInitializeNessy_WithCorrectName()
    {
        Assert.That(nessy.Name, Is.EqualTo("Nessy"));
        Assert.That(nessy.Health, Is.EqualTo(100));
    }

    [Test]
    public void AttackValue_ShouldReturnCorrectValue()
    {
        // Act
        int attackValue = nessy.AttackValue; //20

        // Assert
        Assert.That(attackValue, Is.EqualTo(20)); 
    }

    [Test]
    public void DefenseValue_ShouldReturnCorrectValue()
    {
        // Act
        int defenseValue = nessy.DefenseValue; //18

        // Assert
        Assert.That(defenseValue, Is.EqualTo(18));
    }

    [Test]
    public void ReceiveAttack_ShouldReduceHealth_WhenDefenseIsLessThanPower()
    {
        // Arrange
        int initialHealth = nessy.Health;
        int attackPower = 20;

        // Act
        nessy.ReceiveAttack(attackPower);

        // Assert
        Assert.That(nessy.Health, Is.EqualTo(initialHealth - (attackPower - nessy.DefenseValue)));
    }

    [Test]
    public void ReceiveAttack_ShouldNotReduceHealth_WhenDefenseIsGreaterThanPower()
    {
        // Arrange
        int initialHealth = nessy.Health;
        int attackPower = 3;

        // Act
        nessy.ReceiveAttack(attackPower);

        // Assert
        Assert.That(nessy.Health, Is.EqualTo(initialHealth));
    }

    [Test]
    public void Cure_ShouldRestoreHealthTo100()
    {
        // Arrange
        nessy.ReceiveAttack(50); // Reduce health to 50

        // Act
        nessy.Cure();

        // Assert
        Assert.That(nessy.Health, Is.EqualTo(100));
    }

    [Test]
    public void AddItem_ShouldIncreaseItemsCount()
    {
        // Arrange
        var item = new Shield();
        int initialCount = nessy.Items.Count;

        // Act
        nessy.AddItem(item);

        // Assert
        Assert.That(nessy.Items.Count, Is.EqualTo(initialCount + 1));
    }

    [Test]
    public void RemoveItem_ShouldDecreaseItemsCount()
    {
        // Arrange
        var item = new Sword();
        nessy.AddItem(item);
        int initialCount = nessy.Items.Count;

        // Act
        nessy.RemoveItem(item);

        // Assert
        Assert.That(nessy.Items.Count, Is.EqualTo(initialCount - 1));
    }
}
