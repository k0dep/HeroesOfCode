using UnityEngine;

namespace HeroesOfCode.Components
{
    public class PathPartInstance : MonoBehaviour
    {
        public LineRenderer renderer;
        public void Setup(Vector3 from, Vector3 to)
        {
            renderer.SetPositions(new [] {from, to});
        }
    }
}