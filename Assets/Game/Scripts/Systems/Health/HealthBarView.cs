using System.Collections.Generic;
using Systems.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.Health
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;
        private HealthView _healthViewPrefab;
        private int _maxHeartsCount;

        private readonly Stack<HealthView> _hearts = new Stack<HealthView>();
        public void Initialize(int startHeartsCount, HealthView prefab)
        {
            _maxHeartsCount = startHeartsCount;
            _healthViewPrefab = prefab;
            CreateHearts();
        }

        private void CreateHearts()
        {
            for (var i = 0; i < _maxHeartsCount; i++)
            {
                CreateHeart();
            }
        }

        public void AddHeart() => CreateHeart();

        public void RemoveHeart()
        {
            if (_hearts.Count == 0)
            {
                return;
            }
            _hearts.Pop().Hide();
        }
        
        private void CreateHeart()
        {
            var heart = Instantiate(_healthViewPrefab, _horizontalLayoutGroup.transform, false);
            _hearts.Push(heart);
            heart.Show();
        }
    }
}