using AStar;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/A* installer")]
    public class AStarInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGraph>().FromFactory<MatrixFullGraphFactory>().AsSingle();

            Container.Bind<IGraphNeighborsService>().FromFactory<GraphGridNeighborsServiceFactory>().AsSingle();

            Container.Bind<IPathFindService>().To<AStarPathFindService>().AsSingle();
        }

        public class MatrixFullGraphFactory : IFactory<IGraph>
        {
            private readonly SceneOptions _options;

            public MatrixFullGraphFactory(SceneOptions options)
            {
                _options = options;
            }

            public IGraph Create()
            {
                return new MatrixFullGraph(_options.GraphWidth, _options.GraphHeight);
            }
        }
        
        public class GraphGridNeighborsServiceFactory : IFactory<IGraphNeighborsService>
        {
            private readonly SceneOptions _options;

            public GraphGridNeighborsServiceFactory(SceneOptions options)
            {
                _options = options;
            }

            public IGraphNeighborsService Create()
            {
                return new GraphGridNeighborsService(_options.MaxNotWalkableCost);
            }
        }
    }
}