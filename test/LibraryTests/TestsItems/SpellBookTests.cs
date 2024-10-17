using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;

public class SpellsBookTests
{
    private SpellsBook spellsBook;

    [SetUp]
    public void SetUp()
    {
        // Inicializa una nueva instancia de SpellsBook antes de cada test.
        spellsBook = new SpellsBook();
    }

    [Test]
    public void AttackValue_WithSpells_ShouldCalculateCorrectly()
    {
        // Arrange
        var spellOne = new SpellOne();
        spellsBook.AddSpell(spellOne);

        // Act
        int attackValue = spellsBook.AttackValue;

        // Assert
        Assert.That(attackValue, Is.EqualTo(70));
    }

    [Test]
    public void DefenseValue_WithSpells_ShouldCalculateCorrectly()
    {
        // Arrange
        var spellOne = new SpellOne();
        spellsBook.AddSpell(spellOne);

        // Act
        int defenseValue = spellsBook.DefenseValue;

        // Assert
        Assert.That(defenseValue, Is.EqualTo(70));
    }

    [Test]
    public void AddSpell_ShouldIncreaseSpellCount()
    {
        // Arrange
        var spellOne = new SpellOne();

        // Act
        spellsBook.AddSpell(spellOne);
        int initialCount = spellsBook.Spells.Count; // Assuming you have a property to count spells
        spellsBook.AddSpell(spellOne);
        int newCount = spellsBook.Spells.Count;

        // Assert
        Assert.That(newCount, Is.EqualTo(initialCount + 1));
    }

    [Test]
    public void RemoveSpell_ShouldDecreaseSpellCount()
    {
        // Arrange
        var spellOne = new SpellOne();
        spellsBook.AddSpell(spellOne);

        // Act
        int initialCount = spellsBook.Spells.Count; // Assuming you have a property to count spells
        spellsBook.RemoveSpell(spellOne);
        int newCount = spellsBook.Spells.Count;

        // Assert
        Assert.That(newCount, Is.EqualTo(initialCount - 1));
    }
}