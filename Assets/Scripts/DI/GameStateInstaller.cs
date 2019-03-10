using HeroesOfCode.Models;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/Game state installer")]
    public class GameStateInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameState>()
                .To<GameState>()
                .AsSingle()
                .OnInstantiated((InjectContext context, GameState state) =>
                {
                    state.PlayerArmy = ScriptableObject.CreateInstance<ArmyScriptableObjectModel>();
                });
        }
    }
}