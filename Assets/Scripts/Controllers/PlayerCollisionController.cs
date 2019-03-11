using HeroesOfCode.Components;
using HeroesOfCode.Messages;
using HeroesOfCode.Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.Controllers
{
    public class PlayerCollisionController : IInitializable
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ZenjectSceneLoader _sceneLoader;
        private readonly INavigationGridAgentCollectorService _agentCollectorService;
        private readonly SceneOptions _sceneOptions;

        public PlayerCollisionController(IMessageBroker messageBroker, ZenjectSceneLoader sceneLoader,
            INavigationGridAgentCollectorService agentCollectorService, SceneOptions sceneOptions)
        {
            _messageBroker = messageBroker;
            _sceneLoader = sceneLoader;
            _agentCollectorService = agentCollectorService;
            _sceneOptions = sceneOptions;
        }

        public void Initialize()
        {
            _messageBroker.Receive<PlayerCollideEnemy>().Subscribe(OnCollision);
        }

        private void OnCollision(PlayerCollideEnemy message)
        {
            var enemyObject = _agentCollectorService.GetAgentInNode(message.EnemyNode);
            var enemyArmyComponent = enemyObject?.GetComponent<EnemyArmyField>();

            if (enemyArmyComponent == null)
            {
                Debug.LogError("Enemy army scene component not found!");
                return;
            }

            if (!string.IsNullOrEmpty(enemyArmyComponent.WarFieldSceneName))
            {
                _sceneLoader.LoadScene(enemyArmyComponent.WarFieldSceneName);
                return;
            }

            if (string.IsNullOrEmpty(_sceneOptions.DefaultWarFieldSceneName))
            {
                Debug.LogError($"Default war field scene not set! check {_sceneOptions.name} asset");
                return;
            }

            _sceneLoader.LoadScene(_sceneOptions.DefaultWarFieldSceneName);
        }
    }
}