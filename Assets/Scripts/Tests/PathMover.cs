using System.Collections;
using System.Collections.Generic;
using AStar;
using AStar.ActionGrid;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace HeroesOfCode.Components
{
    public class PathMover : MonoBehaviour
    {
        public Vector2Int from;
        public Vector2Int to;
        public NavigationGridAgent mover;

        [Inject] public IGraphNeighborsService neighbor;

        [Inject] public INavigationActionGrid Grid { get; set; }

        [Inject] public IGraph Graph { get; set; }

        public void Move()
        {
            var pathFinder = new AStarPathFindService(neighbor);

            var path = pathFinder.Find(Graph, new PathFindingOptions()
            {
                Start = from,
                End = to
            });

            if (path == null)
            {
                return;
            }

            mover.Move(path.Path);
        }


        private void OnDrawGizmos()
        {
            var pathFinder = new AStarPathFindService(neighbor);

            var path = pathFinder.Find(Graph, new PathFindingOptions()
            {
                Start = from,
                End = to
            });

            if (path == null)
            {
                return;
            }

            foreach (var point in path.Path)
            {
                Gizmos.DrawCube(Grid.GetCellPoint(point), Vector3.one * 2);
            }
        }
    }
}