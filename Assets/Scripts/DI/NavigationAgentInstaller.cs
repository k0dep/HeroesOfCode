using HeroesOfCode.Components;
using HeroesOfCode.Services;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/Global navigation agent installer")]
    public class NavigationAgentInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GridWorldPositionService>().AsTransient();
            Container.Bind<INavigationGridAgent>().FromComponentsInHierarchy().AsSingle();
        }
    }
}