using System;
using System.Collections.Generic;
using AStar.ActionGrid;
using HeroesOfCode.Services;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace HeroesOfCode.Components
{
    public class NavigationGridAgent : MonoBehaviour, INavigationGridAgent
    {
        [Inject]
        public INavigationActionGrid Grid { get; set; }

        [Inject]
        public GridWorldPositionService GridWorldPositionService { get; set; }

        
        public UnityEvent OnWalked;

        public float WalkSpeed;

        private IList<Vector2Int> path;
        private int targetPathPoint;
        private float elapsed;

        private Subject<bool> _onWalkedSubject;

        public Vector2Int Position => GridWorldPositionService.GetGridPosition(transform.position);

        public IObservable<bool> Move(IList<Vector2Int> _path)
        {
            path = _path;
            targetPathPoint = 1;
            return _onWalkedSubject = new Subject<bool>();;
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
                    _onWalkedSubject.OnNext(true);
                    _onWalkedSubject.OnCompleted();
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
}