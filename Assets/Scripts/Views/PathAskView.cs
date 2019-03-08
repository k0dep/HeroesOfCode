using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace HeroesOfCode.Views
{
    public class PathAskView : MonoBehaviour, IPathAskView
    {
        public UnityEvent OnAskEvent;
        
        private Subject<bool> _askSubject;
        
        public IObservable<bool> Ask()
        {
            OnAskEvent.Invoke();
            _askSubject = new Subject<bool>();
            return _askSubject;
        }

        public void AnswerYes()
        {
            _askSubject.OnNext(true);
            _askSubject.OnCompleted();
        }
        
        public void AnswerNo()
        {
            _askSubject.OnNext(false);
            _askSubject.OnCompleted();
        }
    }
}