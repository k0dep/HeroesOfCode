using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeroesOfCode.Components
{
    public interface INavigationGridAgent : INavigationGridAgentPosition
    {
        IObservable<bool> Move(IList<Vector2Int> _path);
    }
}