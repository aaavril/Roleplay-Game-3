using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;

public class BowTests
{
    private Bow bow;

    [SetUp]
    public void SetUp()
    {
        bow = new Bow();
    }

    [Test]
    public void AttackValue_ShouldReturnCorrectValue()
    {
        // Arrange
        int expectedAttackValue = 15;

        // Act
        int actualAttackValue = bow.AttackValue;

        // Assert
        Assert.That(actualAttackValue, Is.EqualTo(expectedAttackValue));
    }
}