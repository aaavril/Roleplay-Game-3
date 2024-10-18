using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace Library.Tests;

public class EncounterTests
{
    private Archer archer;
    private Dwarf dwarf;
    private Hannibal hannibal;
    private Nessy nessy;
    private Encounter encounter;

    [SetUp]
    public void SetUp()
    {
        archer = new Archer("Archer");
        dwarf = new Dwarf("Dwarf");
        hannibal = new Hannibal("Hannibal");
        nessy = new Nessy("Nessy");

        List<IHero> heroes = new List<IHero> { archer, dwarf };
        List<IEnemy> enemies = new List<IEnemy> { hannibal, nessy };

        encounter = new Encounter(heroes, enemies);
    }
    
    [Test]
    public void DoEncounter_HeroesWin_EnemiesAreDefeated()
    {
        hannibal.ReceiveAttack(200); 
        nessy.ReceiveAttack(200);  

        encounter.DoEncounter();

        Assert.That(hannibal.Health, Is.EqualTo(0));
        Assert.That(nessy.Health, Is.EqualTo(0));
    }

    [Test]
    public void DoEncounter_WhenEnemiesWin_HeroesAreAllDead()
    {
        archer.ReceiveAttack(100);
        dwarf.ReceiveAttack(100);

        encounter.DoEncounter();

        Assert.That(archer.Health, Is.EqualTo(0));
        Assert.That(dwarf.Health, Is.EqualTo(0));
    }
    
    [Test]
    public void DoEncounter_NoActionIfNoHeroesOrEnemies()
    {
        encounter = new Encounter(new List<IHero>(), new List<IEnemy>());

        encounter.DoEncounter();

        Assert.Pass();
    }
}

