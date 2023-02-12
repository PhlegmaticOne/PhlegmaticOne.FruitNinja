using UnityEngine;

namespace Systems.Combos
{
    public class ComboSystem : MonoBehaviour
    {
        [SerializeField] private float _maxComboDelay;
        [SerializeField] private int _maxComboCount;
        [SerializeField] private ComboView _comboView;

        private float _timeSinceLastCombo;
        private int _currentComboCount;

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