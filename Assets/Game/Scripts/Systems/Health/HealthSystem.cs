using System;
using Configurations.Systems;
using DG.Tweening;
using UnityEngine;

namespace Systems.Health
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private HealthBarView _healthBarView;
        private HealthSystemConfiguration _healthSystemConfiguration;
        private int _heartsCount;
        private int _maxHeartsCount;
        private HealthView _currentHealthView;

        public event Action HealthEnded;
        public int CurrentHeartsCount => _heartsCount;
        public int MaxHeartsCount => _maxHeartsCount;
        
        public void Initialize(HealthSystemConfiguration healthSystemConfiguration, Camera cam)
        {
            _healthSystemConfiguration = healthSystemConfiguration;
            _healthBarView.Initialize(healthSystemConfiguration.StartHealthCount,
                healthSystemConfiguration.HealthViewPrefab, cam);
            _heartsCount = healthSystemConfiguration.StartHealthCount;
            _maxHeartsCount = healthSystemConfiguration.MaxHealthCount;
        }
        
        public void AddHeart(Vector3 from)
        {
            if (_heartsCount == _maxHeartsCount)
            {
                return;
            }
            
            AddHeartFromPosition(from);
        }

        public void RemoveHeart()
        {
            if (_heartsCount == 0)
            {
                return;
            }
            
            if (_currentHealthView != null)
            {
                _currentHealthView.transform.DOKill();
            }

            RemoveHeartFromBar();
            
            if (_heartsCount == 0)
            {
                HealthEnded?.Invoke();
            }
        }
        
        public void ResetHearts()
        {
            var startHearts = _healthSystemConfiguration.StartHealthCount;
            while (_heartsCount != startHearts)
            {
                AddHeartDirectlyToHealthBar();
            }
        }
        
        private void AddHeartFromPosition(Vector3 position)
        {
            var newHeartPosition = _healthBarView.CalculatePosition();
            _currentHealthView = AddHeart();
            _currentHealthView.transform.position = position;
            _currentHealthView.transform.DOMove(newHeartPosition, _healthSystemConfiguration.TransitionToHealthBarTime)
                .OnComplete(() => _currentHealthView = null);
        }
        
        private void AddHeartDirectlyToHealthBar()
        {
            if (_heartsCount == _maxHeartsCount)
            {
                return;
            }

            AddHeart();
        }
        
        private HealthView AddHeart()
        {
            ++_heartsCount;
            return _healthBarView.AddHeart();
        }

        private void RemoveHeartFromBar()
        {
            _healthBarView.RemoveHeart();
            --_heartsCount;
        }
    }
}