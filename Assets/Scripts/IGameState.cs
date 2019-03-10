using System.Collections.Generic;
using HeroesOfCode.Models;

namespace HeroesOfCode
{
    public interface IGameState
    {
        IArmyModel PlayerArmy { get; set; }
        
        IList<IArmyModel> EnemiesArmy { get; set; }
    }
}