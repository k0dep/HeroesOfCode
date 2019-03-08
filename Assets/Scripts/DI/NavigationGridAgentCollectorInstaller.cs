using HeroesOfCode.Services;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/Navigation grid agent collector installer")]
    public class NavigationGridAgentCollectorInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<INavigationGridAgentCollectorService>()
                .To<NavigationGridAgentCollectorService>()
                .AsTransient();
        }
    }
}