using UniRx;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.DI
{
    [CreateAssetMenu(menuName = "Installers/Message broker installer")]
    public class MessageBrokerInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance<IMessageBroker>(MessageBroker.Default);
        }
    }
}