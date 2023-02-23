using System.Collections.Generic;
using System.Linq;
using Systems.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.Health
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private Transform _hideToTransform;
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

        public HealthView AddHeart() => CreateHeart();

        public void RemoveHeart()
        {
            if (_hearts.Count == 0)
            {
                return;
            }
            _hearts.Pop().Hide(_hideToTransform);
            Rebuild();
        }
        

        private HealthView CreateHeart()
        {
            var heart = Instantiate(_healthViewPrefab, _gridLayoutGroup.transform);
            Rebuild();
            _hearts.Push(heart);
            heart.Show();
            return heart;
        }
        
        private void Rebuild() => LayoutRebuilder.ForceRebuildLayoutImmediate(_gridLayoutGroup.transform as RectTransform);
    }
}