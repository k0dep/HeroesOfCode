using HeroesOfCode.Components;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/Path visualizer global installer")]
    public class PathVisualizerInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPathVisualizer>().FromComponentsInHierarchy().AsSingle();
        }
    }
}