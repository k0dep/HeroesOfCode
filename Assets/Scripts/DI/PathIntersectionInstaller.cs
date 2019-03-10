using HeroesOfCode.Services;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/Path intersection service installer")]
    public class PathIntersectionInstaller : ScriptableObjectInstaller
    {
        public SceneOptions Options;
        
        public override void InstallBindings()
        {
            Container.Bind<IPathIntersectionService>()
                .To<PathIntersectionService>()
                .AsTransient()
                .OnInstantiated((InjectContext ctx, PathIntersectionService instance) =>
                {
                    instance.MinimumDistance = Options.MinimumDistance;
                });
        }
    }
}