using HeroesOfCode.Views;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/UI/PathAskView installer")]
    public class PathAskViewInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPathAskView>().FromComponentsInHierarchy().AsSingle();
        }
    }
}