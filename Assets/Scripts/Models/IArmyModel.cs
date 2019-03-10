using System;

namespace HeroesOfCode.Models
{
    public interface IArmyModel : ICloneable
    {
        string Guid { get; }
        string Title { get; }
        
        ISquadModel ArchersSquad { get; set; }
        ISquadModel PikinersSquad { get; set; }
        ISquadModel KnightsSquad { get; set; }
        ISquadModel GoblinsSquad { get; set; }
    }
}