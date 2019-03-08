using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/GameOption installer")]
    public class GameOptionsInstaller : ScriptableObjectInstaller
    {
        public GameOptions Options;
        
        public override void InstallBindings()
        {
            Container.BindInstance(Options);
        }
    }
}