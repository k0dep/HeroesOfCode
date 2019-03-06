using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeroesOfCode
{
    public interface INavigationGridAgent
    {
        Vector2Int Position { get; }
        
        IObservable<bool> Move(IList<Vector2Int> _path);
    }
}