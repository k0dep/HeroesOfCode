using AStar.ActionGrid;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace HeroesOfCode.Components
{
    public class GridCellConstructor : MonoBehaviour
    {
        [Inject]
        public INavigationActionGrid NavGrid;

        [Inject]
        public GameOptions Options;
        
        [Inject]
        public DiContainer Container { get; set; }

        public GameObject GridCellPrefab;

        public Transform CellParent;
        
        public void Start()
        {
            Assert.IsNotNull(GridCellPrefab);
            Assert.IsNotNull(CellParent);

            for (var x = 0; x < Options.GraphWidth; x++)
            {
                for (var y = 0; y < Options.GraphHeight; y++)
                {
                    var node = new Vector2Int(x, y);
                    var position = NavGrid.GetCellPoint(node);
                    var instance = Container.InstantiatePrefab(GridCellPrefab, position, Quaternion.identity, CellParent);
                    var cell = instance.GetComponent<GridCell>();
                    cell.Node = node;
                }
            }
        }
    }
}