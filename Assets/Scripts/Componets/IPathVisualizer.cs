using System.Collections.Generic;
using UnityEngine;

namespace HeroesOfCode.Componets
{
    public interface IPathVisualizer
    {
        void Visualize(IList<Vector2Int> path);
        void Hide();
    }
}