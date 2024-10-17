using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;

public class ShieldTests
{
    private Shield shield;

    [SetUp]
    public void SetUp()
    {
        shield = new Shield();
    }

    [Test]
    public void DefenseValue_ShouldReturnCorrectValue()
    {
        // Arrange
        int expectedDefenseValue = 14;

        // Act
        int actualDefenseValue = shield.DefenseValue;

        // Assert
        Assert.That(actualDefenseValue, Is.EqualTo(expectedDefenseValue));
    }
}