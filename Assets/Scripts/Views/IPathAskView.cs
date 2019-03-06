using System;

namespace HeroesOfCode.Views
{
    public interface IPathAskView
    {
        IObservable<bool> Ask();
    }
}