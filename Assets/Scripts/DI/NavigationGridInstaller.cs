using AStar;
using AStar.ActionGrid;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/NavigationGrid installer")]
    public class NavigationGridInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<INavigationActionGrid>()
                .To<NavigationActionGrid>()
                .FromMethod(NavigationFactory)
                .AsSingle()
                .NonLazy();
        }

        private NavigationActionGrid NavigationFactory(InjectContext ctx)
        {
            var target = SceneOptions.FindObjectOfType<NavigationActionGrid>();
            var grid = target as NavigationActionGrid;
            grid.Graph = ctx.Container.Resolve<IGraph>();
            grid.NeighborsService = ctx.Container.Resolve<IGraphNeighborsService>();
            return target;
        }
    }
}