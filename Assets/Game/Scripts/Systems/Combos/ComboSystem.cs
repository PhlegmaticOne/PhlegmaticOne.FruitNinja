﻿using Configurations.Systems;
using UnityEngine;

namespace Systems.Combos
{
    public class ComboSystem : MonoBehaviour
    {
        [SerializeField] private ComboView _comboView;
        private float _maxComboDelay;
        private int _maxComboCount;

        private float _timeSinceLastCombo;
        private int _currentComboCount;

        public void Initialize(ComboSystemConfiguration comboSystemConfiguration)
        {
            _maxComboDelay = comboSystemConfiguration.MaxComboDelay;
            _maxComboCount = comboSystemConfiguration.MaxComboCount;
        }

        public int TryAddCombo(Vector3 position)
        {
            var currentTime = Time.time;
            if (currentTime - _timeSinceLastCombo >= _maxComboDelay)
            {
                ResetCount();
                _timeSinceLastCombo = currentTime;
                return _currentComboCount;
            }

            ++_currentComboCount;

            if (_currentComboCount > _maxComboCount)
            {
                _currentComboCount = _maxComboCount;
            }

            _comboView.ShowCombo(_currentComboCount, position);

            return _currentComboCount;
        }

        public void ResetCombos()
        {
            ResetCount();
            _comboView.Hide();
        }

        private void ResetCount() => _currentComboCount = 1;
    }
}