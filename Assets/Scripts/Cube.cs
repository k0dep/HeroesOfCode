using System.Collections.Generic;
using AStar.ActionGrid;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Cube : MonoBehaviour
{
    [Inject]
    public INavigationActionGrid Grid { get; set; }

    public UnityEvent OnWalked;
    
    public float WalkSpeed;
    
    private IList<Vector2Int> path;
    private int targetPathPoint;
    private float elapsed;
    
    public void Move(IList<Vector2Int> _path)
    {
        path = _path;
        targetPathPoint = 1;
    }

    private void Update()
    {
        if (path == null)
        {
            return;
        }

        var fromNode = path[targetPathPoint - 1];
        var destNode = path[targetPathPoint];

        var fromPoint = Grid.GetCellPoint(fromNode);
        var destPoint = Grid.GetCellPoint(destNode);

        var distance = Vector3.Distance(fromPoint, destPoint);
        
        elapsed += WalkSpeed * Time.deltaTime;

        if (elapsed > distance)
        {
            elapsed = distance;

            if (path.Count == (targetPathPoint + 1))
            {
                path = null;
                OnWalked.Invoke();
            }
        }

        var currentPosition = Vector3.Lerp(fromPoint, destPoint, elapsed / distance);
        transform.position = currentPosition;

        if (elapsed == distance)
        {
            elapsed = 0;
            targetPathPoint++;
        }
    }
}
