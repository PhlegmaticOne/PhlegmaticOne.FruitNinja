using System.Collections.Generic;
using Systems.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.Health
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;
        [SerializeField] private Camera _camera;
        private HealthView _healthViewPrefab;
        private int _maxHeartsCount;

        private readonly Stack<HealthView> _hearts = new Stack<HealthView>();
        public void Initialize(int startHeartsCount, HealthView prefab, Camera cam)
        {
            _maxHeartsCount = startHeartsCount;
            _camera = cam;
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
            _hearts.Pop().Hide();
        }

        public Vector2 CalculatePosition()
        {
            var viewPosition = _horizontalLayoutGroup.transform.position;
            var world = _camera.WorldToScreenPoint(viewPosition);
            var offset = _hearts.Count * (_healthViewPrefab.Width + _horizontalLayoutGroup.spacing);
            var result = new Vector2(world.x - offset - _healthViewPrefab.Width / 2, world.y - _healthViewPrefab.Height / 2);
            return _camera.ScreenToWorldPoint(result);
        }

        private HealthView CreateHeart()
        {
            var heart = Instantiate(_healthViewPrefab, _horizontalLayoutGroup.transform);
            _hearts.Push(heart);
            heart.Show();
            return heart;
        }
    }
}