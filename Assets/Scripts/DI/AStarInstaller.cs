using AStar;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/A* installer")]
    public class AStarInstaller : ScriptableObjectInstaller
    {
        public GameOptions gameOptions;
        
        public override void InstallBindings()
        {
            var graph = new MatrixFullGraph(gameOptions.GraphWidth, gameOptions.GraphHeight);
            Container.BindInstance<IGraph>(graph);
            
            var neighborService = new GraphGridNeighborsService(gameOptions.MaxNotWalkableCost);
            Container.BindInstance<IGraphNeighborsService>(neighborService);

            Container.Bind<IPathFindService>().To<AStarPathFindService>().AsSingle();
        }
    }
}