using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Systems.Score
{
    public class TemporaryScreenScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _animationDuration;

        public void SpawnScoreText(int score, Vector3 position, Vector2 direction, Color color, Transform parentTransform)
        {
            var text = SpawnText(score, position, direction, color, parentTransform);
            Destroy(text, _animationDuration);
        }
        
        private TextMeshProUGUI SpawnText(int score, Vector3 position, Vector2 direction, Color color, Transform parentTransform)
        {
            var text = Instantiate(_text, parentTransform);
            
            text.SetText(score.ToString());
            text.color = color;
            text.transform.position = position;
            text.transform.DOMove((Vector2)text.transform.position + direction, _animationDuration);

            return text;
        }
    }
}