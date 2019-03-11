using HeroesOfCode.Controllers;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/Game/Walk field controllers installer")]
    public class WalkFieldControllersInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<GridNavigationController>().AsSingle();
            Container.Bind<IInitializable>().To<PlayerCollisionController>().AsSingle();
        }
    }
}