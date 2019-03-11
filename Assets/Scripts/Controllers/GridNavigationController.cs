using AStar;
using HeroesOfCode.Components;
using HeroesOfCode.Messages;
using HeroesOfCode.Services;
using HeroesOfCode.Views;
using UniRx;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.Controllers
{
    public class GridNavigationController : IInitializable
    {
        private readonly IMessageBroker _messageBroker;
        private readonly INavigationGridAgent _gridAgent;
        private readonly IPathFindService _pathFindService;
        private readonly IGraph _graph;
        private readonly IPathVisualizer _pathVisualizer;
        private readonly IPathAskView _pathAskView;
        private readonly IPathIntersectionService _pathIntersectionService;
        private readonly INavigationGridAgentCollectorService _navigationGridAgentCollector;

        private bool walking = false;
        private Vector2Int? enemyNode;

        public GridNavigationController(IMessageBroker messageBroker, INavigationGridAgent gridAgent,
            IPathFindService pathFindService, IGraph graph, IPathVisualizer pathVisualizer, IPathAskView pathAskView,
            IPathIntersectionService pathIntersectionService,
            INavigationGridAgentCollectorService navigationGridAgentCollector)
        {
            _messageBroker = messageBroker;
            _gridAgent = gridAgent;
            _pathFindService = pathFindService;
            _graph = graph;
            _pathVisualizer = pathVisualizer;
            _pathAskView = pathAskView;
            _pathIntersectionService = pathIntersectionService;
            _navigationGridAgentCollector = navigationGridAgentCollector;
        }

        public void Initialize()
        {
            _messageBroker.Receive<GridInteractMessage>().Subscribe(GridInteract);
        }

        private void GridInteract(GridInteractMessage cellMessage)
        {
            if (walking)
            {
                return;
            }

            var path = _pathFindService.Find(_graph, new PathFindingOptions()
            {
                Start = _gridAgent.Position,
                End = cellMessage.Node
            });

            if (path == null)
            {
                _messageBroker.Publish(new PathNotFoundMessage());
                return;
            }

            var collision =
                _pathIntersectionService.CheckIntersections(path.Path, _navigationGridAgentCollector.GetAgents());

            if (collision != null)
            {
                path.Path = collision.IntersectedPath;
            }

            _pathVisualizer.Visualize(path.Path);
            
            _pathAskView.Ask().Subscribe(result =>
            {
                if (collision != null)
                {
                    enemyNode = collision.IntersectionNode;
                }
                else
                {
                    enemyNode = null;
                }
                
                
                if (!result)
                {
                    OnWalked(false);
                    return;
                }

                walking = true;
                _gridAgent.Move(path.Path).Subscribe(OnWalked);
            });
        }

        private void OnWalked(bool obj)
        {
            walking = false;
            _pathVisualizer.Hide();
            if (enemyNode.HasValue)
            {
                _messageBroker.Publish(new PlayerCollideEnemy()
                {
                    EnemyNode = enemyNode.Value
                });
            }
        }
    }
}