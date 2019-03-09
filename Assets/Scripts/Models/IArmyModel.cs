namespace HeroesOfCode.Models
{
    public interface IArmyModel
    {
        ISquadModel ArchersSquad { get; set; }
        ISquadModel PikinersSquad { get; set; }
        ISquadModel KnightsSquad { get; set; }
        ISquadModel GoblinsSquad { get; set; }
    }
}