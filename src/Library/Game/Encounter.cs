namespace Ucu.Poo.RoleplayGame;

public class Encounter
{
    private List<IHero> heroes;
    private List<IEnemy> enemies;

    public Encounter(List<IHero> heroes, List<IEnemy> enemies)
    {
        this.heroes = heroes;
        this.enemies = enemies;
    }

    private void EnemiesAttack()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            IEnemy enemy = enemies[i];

            IHero targetHero = heroes[i % heroes.Count];
            targetHero.ReceiveAttack(enemy.AttackValue);
        }
    }

    private void HeroesAttack()
    {
        foreach (IHero hero in heroes)
        {
            if (hero.Health > 0) 
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.Health > 0) 
                    {
                        enemy.ReceiveAttack(hero.AttackValue);

                        if (enemy.Health <= 0)
                        {
                            hero.GainVictoryPoints(enemy.VictoryPoints);
                        }
                    }
                }
            }
        }
    }
    private bool AreHeroesAlive()
    {
        foreach (var hero in heroes)
        {
            if (hero.Health > 0)
            {
                return true; 
            }
        }
        return false; 
    }

    private bool AreEnemiesAlive()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.Health > 0)
            {
                return true; 
            }
        }
        return false; 
    }
    public void DoEncounter()
    {
        if (heroes.Count == 0 || enemies.Count == 0)
        {
            return;
        }

        while (AreHeroesAlive() && AreEnemiesAlive())
        {
            EnemiesAttack();

            HeroesAttack();

            foreach (IHero hero in heroes)
            {
                if (hero.VictoryPoints >= 5)
                {
                    hero.Cure();
                }
            }
        }
    } 
}