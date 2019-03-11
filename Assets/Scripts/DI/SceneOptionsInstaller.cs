using HeroesOfCode.Components;
using Zenject;

namespace HeroesOfCode.DI
{
    public class SceneOptionsInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            Container.Bind<SceneComponent>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<SceneOptions>().ToSelf().FromResolveGetter<SceneComponent>(s => s.SceneOptionsReference).AsSingle();
        }
    }
}