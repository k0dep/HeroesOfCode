using System.Linq;
using HeroesOfCode.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace HeroesOfCode.Components
{
    [ExecuteInEditMode]
    public class SceneComponent : MonoBehaviour
    {
        [Inject]
        public IGameState GameState { get; set; }
        
        public SceneOptions SceneOptionsReference;

        private void Start()
        {
            if (!Application.isPlaying)
            {
                return;
            }
            
            // inject army models to field enemies
            var enemyArmies = GameObject.FindObjectsOfType<EnemyArmyField>();
            var armyModels = GameState.EnemiesArmy;
            
            foreach (var enemyArmy in enemyArmies)
            {
                var model = armyModels.Single(m => m.Guid == enemyArmy.ArmyModelReference.Guid);
                enemyArmy.ArmyModel = model;
            }
        }

        public void Update()
        {
            if (Application.isEditor && !Application.isPlaying)
            {
                RefreshSceneArmies();
            }
        }

        private void RefreshSceneArmies()
        {
            if (SceneOptionsReference == null)
            {
                return;
            }
            
            SceneOptionsReference.Armies =
                GameObject.FindObjectsOfType<EnemyArmyField>().Select(t => t.ArmyModelReference).ToList();

            SceneOptionsReference.SceneBuildIndex = gameObject.scene.buildIndex;
        }
    }
}