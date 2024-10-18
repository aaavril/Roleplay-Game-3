namespace Ucu.Poo.RoleplayGame;

public interface IHero : ICharacter
{
    int VictoryPoints { get; set; } 

    void GainVictoryPoints(int points); 
}