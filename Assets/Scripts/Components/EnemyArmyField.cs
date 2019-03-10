using HeroesOfCode.Models;
using UnityEngine;

namespace HeroesOfCode.Components
{
    public class EnemyArmyField : MonoBehaviour
    {
        public ArmyScriptableObjectModel ArmyModelReference;

        public IArmyModel ArmyModel { get; set; }
    }
}