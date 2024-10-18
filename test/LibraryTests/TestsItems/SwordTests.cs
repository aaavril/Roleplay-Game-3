using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;

public class SwordTests
{
    private Sword sword;

    [SetUp]
    public void SetUp()
    {
        sword = new Sword();
    }

    [Test]
    public void AttackValue_ShouldReturnCorrectValue()
    {
        // Arrange
        int expectedAttackValue = 20;

        // Act
        int actualAttackValue = sword.AttackValue;

        // Assert
        Assert.That(actualAttackValue, Is.EqualTo(expectedAttackValue));
    }
}