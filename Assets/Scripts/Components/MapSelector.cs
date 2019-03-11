using System.Linq;
using HeroesOfCode.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace HeroesOfCode.Components
{
    public class MapSelector : MonoBehaviour
    {
        [Inject]
        public IGameState GameState { get; set; }
            
        public void Select(SceneOptions sceneOption)
        {
            GameState.EnemiesArmy = sceneOption.Armies.Select(a => Instantiate(a)).Cast<IArmyModel>().ToList();
            SceneManager.LoadSceneAsync(sceneOption.SceneBuildIndex);
        }
    }
}