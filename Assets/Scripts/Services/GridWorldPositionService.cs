using AStar.ActionGrid;
using UnityEngine;

namespace HeroesOfCode.Services
{
    public class GridWorldPositionService
    {
        private readonly INavigationActionGrid _grid;

        public GridWorldPositionService(INavigationActionGrid grid)
        {
            _grid = grid;
        }

        public Vector2Int GetGridPosition(Vector3 worldPosition)
        {
            var gridOrigin = _grid.GetCellPoint(Vector2Int.zero);
            var secondWidthCell =  _grid.GetCellPoint(new Vector2Int(1, 0));
            var secondHeightCell =  _grid.GetCellPoint(new Vector2Int(1, 0));
                
            var cellWidth = Vector3.Distance(gridOrigin, secondWidthCell);
            var cellHeight = Vector3.Distance(gridOrigin, secondHeightCell);

            var relativePosition = worldPosition - gridOrigin;
                
            return new Vector2Int((int)(relativePosition.x / cellWidth), (int)(relativePosition.z / cellHeight));
        }
    }
}