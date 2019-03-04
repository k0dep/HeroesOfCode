using AStar;
using AStar.ActionGrid;
using UnityEngine;

namespace HeroesOfCode
{
    [ExecuteInEditMode]
    public class NavigationGridEditor : MonoBehaviour
    {
        public GameOptions options;

        private bool isInit = false;
        
        void Update()
        {
            if (!(Application.isEditor && !Application.isPlaying))
            {
                return;
            }
            
            if (isInit)
            {
                return;
            }

            var graph = new MatrixFullGraph(options.GraphWidth, options.GraphHeight);
            var neighbor = new GraphGridNeighborsService(options.MaxNotWalkableCost);

            var navGrid = GetComponent<NavigationActionGrid>();
            navGrid.Graph = graph;
            navGrid.NeighborsService = neighbor;

            isInit = true;
        }
    }
}