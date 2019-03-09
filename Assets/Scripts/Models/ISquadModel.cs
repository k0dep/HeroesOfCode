namespace HeroesOfCode.Models
{
    public interface ISquadModel
    {
        int UnitCount { get; set; }
        int CurrentHealth { get; set; }
        int MaxHealth { get; set; }
        int AvailableActiveSkills { get; set; }
    }
}