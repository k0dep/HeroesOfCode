using System.Collections.Generic;
using HeroesOfCode.Models;
using UnityEngine;

namespace HeroesOfCode
{
    [CreateAssetMenu(menuName = "Options/Scene options", fileName = "SceneOptions.asset")]
    public class SceneOptions : ScriptableObject
    {
        public int GraphWidth;
        public int GraphHeight;
        public float MaxNotWalkableCost;
        public int MinimumDistance;
        
        [SerializeField]
        private string _guid;
        
        [SerializeField]
        private string _title;
        
        [SerializeField]
        private Sprite UIIcon;
        
        [SerializeField]
        private List<ArmyScriptableObjectModel> _armies;

        public string Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Sprite UiIcon
        {
            get { return UIIcon; }
            set { UIIcon = value; }
        }

        public List<ArmyScriptableObjectModel> Armies
        {
            get { return _armies; }
            set { _armies = value; }
        }

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(Guid))
            {
                Guid = System.Guid.NewGuid().ToString();
            }
        }

    }
}