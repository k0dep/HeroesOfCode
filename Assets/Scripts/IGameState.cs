using System.Collections.Generic;
using HeroesOfCode.Models;

namespace HeroesOfCode
{
    public interface IGameState
    {
        IArmyModel PlayerArmy { get; set; }
        
        IDictionary<string, IArmyModel> EnemiesArmy { get; set; }
    }
}