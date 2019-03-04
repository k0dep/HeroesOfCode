using System.Collections;
using System.Collections.Generic;
using AStar;
using AStar.ActionGrid;
using UnityEngine;
using Zenject;

public class PathMover : MonoBehaviour
{
    public Vector2Int from;
    public Vector2Int to;
    public Cube mover;

    [Inject]
    public IGraphNeighborsService neighbor;

    [Inject]
    public INavigationActionGrid grid;

    [Inject] public IGraph graph;

    [ContextMenu("Move")]
    public void Move()
    {
        var pathFinder = new AStarPathFindService(neighbor);
        
        var path = pathFinder.Find(graph, new PathFindingOptions()
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

        var path = pathFinder.Find(graph, new PathFindingOptions()
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
            Gizmos.DrawCube(grid.GetCellPoint(point), Vector3.one * 2);
        }
    }

}
