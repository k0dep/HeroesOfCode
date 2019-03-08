using HeroesOfCode.Controllers;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/Game/Navigation controller installer")]
    public class NavigationControllerInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<GridNavigationController>().AsSingle();
        }
    }
}