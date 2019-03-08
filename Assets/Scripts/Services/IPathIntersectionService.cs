using System.Collections.Generic;
using UnityEngine;

namespace HeroesOfCode.Services
{
    public interface IPathIntersectionService
    {
        PathIntersection CheckIntersections(IList<Vector2Int> path, IEnumerable<Vector2Int> collidedNodes);
    }
}