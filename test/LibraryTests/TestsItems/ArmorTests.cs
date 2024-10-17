using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;

public class ArmorTests
{
    private Armor armor;

    [SetUp]
    public void SetUp()
    {
        armor = new Armor();
    }

    [Test]
    public void DefenseValue_ShouldReturnCorrectValue()
    {
        // Arrange
        int expectedDefenseValue = 25;

        // Act
        int actualDefenseValue = armor.DefenseValue;

        // Assert
        Assert.That(actualDefenseValue, Is.EqualTo(expectedDefenseValue));
    }
}