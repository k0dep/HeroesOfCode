using UnityEngine;

namespace HeroesOfCode
{
    [CreateAssetMenu(menuName = "Options/Game", fileName = "GameOptions.asset")]
    public class GameOptions : ScriptableObject
    {
        public int GraphWidth;
        public int GraphHeight;
        public float MaxNotWalkableCost;
    }
}