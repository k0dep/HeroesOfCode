using System.Collections.Generic;
using AStar.ActionGrid;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.Components
{
    public class PathVisualizer : MonoBehaviour, IPathVisualizer
    {
        [Inject]
        public INavigationActionGrid NavigationGrid { get; set; }
        
        public GameObject PathPartPrefab;

        private List<GameObject> _currentPath;
        
        public void Visualize(IList<Vector2Int> path)
        {
            Hide();

            _currentPath = new List<GameObject>();
            for (int i = 1; i < path.Count; i++)
            {
                var pathPartInstance = Instantiate(PathPartPrefab);
                var pathPartComponent = pathPartInstance.GetComponent<PathPartInstance>();
                pathPartComponent.Setup(NavigationGrid.GetCellPoint(path[i-1]), NavigationGrid.GetCellPoint(path[i]));
                _currentPath.Add(pathPartInstance);
            }
        }

        public void Hide()
        {
            if (_currentPath == null)
            {
                return;
            }
            
            foreach (var part in _currentPath)
            {
                Destroy(part);
            }
        }
    }
}