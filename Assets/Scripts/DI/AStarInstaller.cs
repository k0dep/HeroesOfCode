using AStar;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/A* installer")]
    public class AStarInstaller : ScriptableObjectInstaller
    {
        public SceneOptions sceneOptions;
        
        public override void InstallBindings()
        {
            var graph = new MatrixFullGraph(sceneOptions.GraphWidth, sceneOptions.GraphHeight);
            Container.BindInstance<IGraph>(graph);
            
            var neighborService = new GraphGridNeighborsService(sceneOptions.MaxNotWalkableCost);
            Container.BindInstance<IGraphNeighborsService>(neighborService);

            Container.Bind<IPathFindService>().To<AStarPathFindService>().AsSingle();
        }
    }
}