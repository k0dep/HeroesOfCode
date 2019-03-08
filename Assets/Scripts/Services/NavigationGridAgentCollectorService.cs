using System.Collections.Generic;
using System.Linq;
using HeroesOfCode.Components;
using UnityEngine;

namespace HeroesOfCode.Services
{
    public class NavigationGridAgentCollectorService : INavigationGridAgentCollectorService
    {
        public IEnumerable<Vector2Int> GetAgents()
        {
            return GameObject
                .FindObjectsOfType<EnemyNavigationGridAgent>()
                .Select(component => component.Position);
        }
    }
}