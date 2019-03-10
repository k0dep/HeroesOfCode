using System.Collections.Generic;
using UnityEngine;

namespace HeroesOfCode.Models
{
    [CreateAssetMenu]
    public class AvailableMaps : ScriptableObject
    {
        [SerializeField]
        private List<SceneOptions> _maps;

        public List<SceneOptions> Maps
        {
            get => _maps;
            set => _maps = value;
        }
    }
}