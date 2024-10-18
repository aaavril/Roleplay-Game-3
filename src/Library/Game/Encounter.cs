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

            // Determinar el héroe objetivo.
            IHero targetHero = heroes[i % heroes.Count];
            targetHero.ReceiveAttack(enemy.AttackValue);
        }
    }

    private void HeroesAttack()
    {
        foreach (var hero in heroes)
        {
            if (hero.Health > 0) // Solo los héroes vivos atacan.
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.Health > 0) // Solo enemigos vivos son atacados.
                    {
                        enemy.ReceiveAttack(hero.AttackValue);

                        // Si el enemigo muere, el héroe gana sus puntos de victoria.
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
        return heroes.Exists(hero => hero.Health > 0);
    }

    private bool AreEnemiesAlive()
    {
        return enemies.Exists(enemy => enemy.Health > 0);
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
