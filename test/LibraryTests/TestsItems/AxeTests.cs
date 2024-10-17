using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;

public class AxeTests
{
    private Axe axe;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe();
    }

    [Test]
    public void AttackValue_ShouldReturnCorrectValue()
    {
        // Arrange
        int expectedAttackValue = 25;

        // Act
        int actualAttackValue = axe.AttackValue;

        // Assert
        Assert.That(actualAttackValue, Is.EqualTo(expectedAttackValue));
    }
}    