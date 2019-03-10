using UnityEngine;

namespace HeroesOfCode.Models
{
    [CreateAssetMenu(menuName = "Game/Army")]
    public class ArmyScriptableObjectModel : ScriptableObject, IArmyModel
    {
        [SerializeField]
        private SquadModel _archersSquad;

        [SerializeField]
        private SquadModel _pikinersSquad;

        [SerializeField]
        private SquadModel _knightsSquad;
        
        [SerializeField]
        private SquadModel _goblinsSquad;

        [SerializeField]
        private string _guid;

        [SerializeField]
        private string _title;
        
        public string Guid => _guid;
        public string Title => _title;
        
        public ISquadModel ArchersSquad
        {
            get => _archersSquad;
            set => _archersSquad = (SquadModel)value;
        }

        public ISquadModel PikinersSquad
        {
            get => _pikinersSquad;
            set => _pikinersSquad = (SquadModel)value;
        }

        public ISquadModel KnightsSquad
        {
            get => _knightsSquad;
            set => _knightsSquad = (SquadModel)value;
        }

        public ISquadModel GoblinsSquad
        {
            get => _goblinsSquad;
            set => _goblinsSquad = (SquadModel)value;
        }

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(_guid))
            {
                _guid = System.Guid.NewGuid().ToString();
            }
        }

        public object Clone() => Instantiate(this);
    }
}