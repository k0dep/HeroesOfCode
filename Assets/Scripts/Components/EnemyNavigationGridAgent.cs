using HeroesOfCode.Services;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.Components
{
    public class EnemyNavigationGridAgent : MonoBehaviour, INavigationGridAgentPosition
    {
        [Inject]
        public GridWorldPositionService GridWorldPositionService { get; set; }

        public Vector2Int Position => GridWorldPositionService.GetGridPosition(transform.position);
    }
}