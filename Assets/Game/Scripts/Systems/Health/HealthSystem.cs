using System;
using Configurations.Systems;
using UnityEngine;

namespace Systems.Health
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private HealthBarView _healthBarView;
        private HealthSystemConfiguration _healthSystemConfiguration;
        private int _heartsCount;
        private int _maxHeartsCount;

        public event Action HealthEnded;
        public int CurrentHeartsCount => _heartsCount;
        public int MaxHeartsCount => _maxHeartsCount;
        
        public void Initialize(HealthSystemConfiguration healthSystemConfiguration)
        {
            _healthSystemConfiguration = healthSystemConfiguration;
            _healthBarView.Initialize(healthSystemConfiguration.StartHealthCount, healthSystemConfiguration.HealthViewPrefab);
            _heartsCount = healthSystemConfiguration.StartHealthCount;
            _maxHeartsCount = healthSystemConfiguration.MaxHealthCount;
        }

        public void RemoveHeart()
        {
            if (_heartsCount == 0)
            {
                return;
            }
            
            _healthBarView.RemoveHeart();
            --_heartsCount;
            
            if (_heartsCount == 0)
            {
                HealthEnded?.Invoke();
            }
        }
        
        public void AddHeart()
        {
            if (_heartsCount == _maxHeartsCount)
            {
                return;
            }
            
            _healthBarView.AddHeart();
            ++_heartsCount;
        }

        public void ResetHearts()
        {
            var startHearts = _healthSystemConfiguration.StartHealthCount;
            while (_heartsCount != startHearts)
            {
                AddHeart();
            }
        }
    }
}