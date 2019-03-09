using System;
using UnityEngine;

namespace HeroesOfCode.Models
{
    [Serializable]
    public class SquadModel : ISquadModel
    {
        [SerializeField]
        private int _unitCount;

        [SerializeField]
        private int _currentHealth;

        [SerializeField]
        private int _maxHealth;

        [SerializeField]
        private int _availableActiveSkills;

        public int UnitCount
        {
            get => _unitCount;
            set => _unitCount = value;
        }

        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        public int AvailableActiveSkills
        {
            get => _availableActiveSkills;
            set => _availableActiveSkills = value;
        }
    }
}