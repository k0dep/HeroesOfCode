using System.Collections.Generic;
using HeroesOfCode.Models;

namespace HeroesOfCode
{
    public class GameState : IGameState
    {
        public IArmyModel PlayerArmy { get; set; }
        public IList<IArmyModel> EnemiesArmy { get; set; }
        public IArmyModel CurrentEnemyArmy { get; set; }

        public GameState()
        {
            EnemiesArmy = new List<IArmyModel>();
        }
    }
}