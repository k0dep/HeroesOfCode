using UnityEngine;

namespace HeroesOfCode.Components
{
    [ExecuteInEditMode]
    public class PointsSlider : MonoBehaviour
    {
        [SerializeField]
        private int _value;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                Recalculate();
            }
        }        

        public GameObject[] Points;

        private void Update()
        {
            Recalculate();
        }

        private void Recalculate()
        {
            foreach (var counter in Points)
            {
                counter.SetActive(false);
            }
            
            for (int i = 0; i < _value && i >= 0 && i < Points.Length; i++)
            {
                Points[i].SetActive(true);
            }
        }
    }
}