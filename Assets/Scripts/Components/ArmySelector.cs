using HeroesOfCode.Models;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.Components
{
    public class ArmySelector : MonoBehaviour
    {
        [Inject]
        public IGameState GameState { get; set; }

        public ArmyScriptableObjectModel[] Armies;

        private int currentArmy;

        private void Start()
        {
            GameState.PlayerArmy = Instantiate(Armies[currentArmy % Armies.Length]);
        }

        public void Next()
        {
            currentArmy++;
            Start();
        }
        
        public void Prev()
        {
            currentArmy--;
            Start();
        }
    }
}