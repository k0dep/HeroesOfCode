using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HeroesOfCode.Services
{
    public class PathIntersectionService : IPathIntersectionService
    {
        public int MinimumDistance { get; set; }
        
        public PathIntersection CheckIntersections(IList<Vector2Int> path, IEnumerable<Vector2Int> collidedNodes)
        {
            var firstCollided = path.Select(node => (pathNode: node,
                collidedNode: collidedNodes.Select(n => (distance: Distance(node, n), node: n))
                    .OrderBy(n => n.distance)
                    .First()))
                .OrderBy(n => n.collidedNode.distance)
                .First();

            if (firstCollided.collidedNode.distance > MinimumDistance)
            {
                return null;
            }

            return new PathIntersection()
            {
                IntersectedPath = path.TakeWhile(n => n != firstCollided.pathNode)
                    .Append(firstCollided.pathNode)
                    .ToList(),
                IntersectionNode = firstCollided.collidedNode.node
            };
        }

        private int Distance(Vector2Int a, Vector2Int b)
        {
            return Math.Max(Math.Abs(a.x - b.x), Math.Abs(a.y - b.y));
        }
    }

    public class PathIntersection
    {
        public IList<Vector2Int> IntersectedPath { get; set; }
        public Vector2Int IntersectionNode { get; set; }
    }
}