using HeroesOfCode.Models;
using UnityEngine;

namespace HeroesOfCode.Components
{
    public class ArmyModelInstance : MonoBehaviour
    {
        public IArmyModel Army { get; set; }
    }
}