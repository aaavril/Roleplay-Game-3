using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;

public class HelmetTests
{
    private Helmet helmet;

    [SetUp]
    public void SetUp()
    {
        helmet = new Helmet();
    }

    [Test]
    public void DefenseValue_ShouldReturnCorrectValue()
    {
        // Arrange
        int expectedDefenseValue = 18;

        // Act
        int actualDefenseValue = helmet.DefenseValue;

        // Assert
        Assert.That(actualDefenseValue, Is.EqualTo(expectedDefenseValue));
    }
}