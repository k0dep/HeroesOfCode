using System.Collections.Generic;
using HeroesOfCode.Models;

namespace HeroesOfCode
{
    public class GameState : IGameState
    {
        public IArmyModel PlayerArmy { get; set; }
        public IDictionary<string, IArmyModel> EnemiesArmy { get; set; }

        public GameState()
        {
            EnemiesArmy = new Dictionary<string, IArmyModel>();
        }
    }
}