using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;

public class SpellOneTests
{
    private SpellOne spellOne;

    [SetUp]
    public void SetUp()
    {
        spellOne = new SpellOne();
    }

    [Test]
    public void AttackValue_ShouldReturnCorrectValue()
    {
        // Arrange
        int expectedAttackValue = 70;

        // Act
        int actualAttackValue = spellOne.AttackValue;

        // Assert
        Assert.That(actualAttackValue, Is.EqualTo(expectedAttackValue));
    }

    [Test]
    public void DefenseValue_ShouldReturnCorrectValue()
    {
        // Arrange
        int expectedDefenseValue = 70;

        // Act
        int actualDefenseValue = spellOne.DefenseValue;

        // Assert
        Assert.That(actualDefenseValue, Is.EqualTo(expectedDefenseValue));
    }
}