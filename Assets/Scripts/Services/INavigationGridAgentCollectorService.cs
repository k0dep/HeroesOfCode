using System.Collections.Generic;
using UnityEngine;

namespace HeroesOfCode.Services
{
    public interface INavigationGridAgentCollectorService
    {
        IEnumerable<Vector2Int> GetAgents();

        GameObject GetAgentInNode(Vector2Int node);
    }
}