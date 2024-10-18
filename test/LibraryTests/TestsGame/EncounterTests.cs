using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;
public class EncounterTests
{
    private IHero archerHero;
    private IHero dwarfHero;
    private IEnemy hannibalEnemy;
    private IEnemy nessyEnemy;
    private Encounter encounter;

    [SetUp]
    public void Setup()
    {
        // Crear héroes tipo Archer y Dwarf
        archerHero = new Archer("Archer Hero");
        dwarfHero = new Dwarf("Dwarf Hero");

        // Crear enemigos de tipo Hannibal y Nessy
        hannibalEnemy = new Hannibal("Hannibal");
        nessyEnemy = new Nessy("Nessy");

        // Configurar el encuentro con dos héroes y dos enemigos
        var heroes = new List<IHero> { archerHero, dwarfHero };
        var enemies = new List<IEnemy> { hannibalEnemy, nessyEnemy };
        encounter = new Encounter(heroes, enemies);
    }

    [Test]
    public void DoEncounter_WhenEnemiesAttack_ShouldReduceHeroHealth()
    {
        // Act
        encounter.DoEncounter();

        // Assert
        Assert.That(archerHero.Health, Is.LessThan(100));
        Assert.That(dwarfHero.Health, Is.LessThan(100));
    }

    [Test]
    public void DoEncounter_WhenHeroDefeatsEnemy_ShouldGainVictoryPoints()
    {
        // Arrange
        hannibalEnemy.ReceiveAttack(150); // Héroe derrota al enemigo Hannibal

        // Act
        encounter.DoEncounter();

        // Assert
        Assert.That(archerHero.VictoryPoints, Is.GreaterThan(0));
        Assert.That(dwarfHero.VictoryPoints, Is.GreaterThan(0));
    }

    [Test]
    public void DoEncounter_WhenHeroGainsFiveVictoryPoints_ShouldHeal()
    {
        // Arrange
        hannibalEnemy.ReceiveAttack(150); // Héroe derrota al enemigo Hannibal

        // Simular que los héroes ganan suficientes puntos de victoria
        archerHero.GainVictoryPoints(5); // Ganar 5 puntos
        dwarfHero.GainVictoryPoints(5); // Ganar 5 puntos

        // Act
        encounter.DoEncounter();

        // Assert
        Assert.That(archerHero.Health, Is.EqualTo(100));
        Assert.That(dwarfHero.Health, Is.EqualTo(100));
    }

    [Test]
    public void DoEncounter_WhenNoHeroes_ShouldNotProceed()
    {
        // Arrange
        var emptyHeroes = new List<IHero>(); // Sin héroes
        encounter = new Encounter(emptyHeroes, new List<IEnemy> { hannibalEnemy, nessyEnemy });

        // Act
        encounter.DoEncounter();

        // Assert
        Assert.That(hannibalEnemy.Health, Is.EqualTo(100));
        Assert.That(nessyEnemy.Health, Is.EqualTo(100));
    }

    [Test]
    public void DoEncounter_WhenNoEnemies_ShouldNotProceed()
    {
        // Arrange
        encounter = new Encounter(new List<IHero> { archerHero, dwarfHero }, new List<IEnemy>()); // Sin enemigos

        // Act
        encounter.DoEncounter();

        // Assert
        Assert.That(archerHero.Health, Is.EqualTo(100));
        Assert.That(dwarfHero.Health, Is.EqualTo(100));
    }
}
