using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Helpers
{
    public class TemporaryTextMeshPro : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _animationDuration;

        public void SpawnText(string text, Vector3 position, Vector2 direction, Color color, Transform parentTransform)
        {
            var textMeshPro = SpawnTextMeshPro(text, position, direction, color, parentTransform);
            Destroy(textMeshPro, _animationDuration);
        }
        
        private TextMeshProUGUI SpawnTextMeshPro(string text, Vector3 position, 
            Vector2 direction, Color color, Transform parentTransform)
        {
            var textMeshPro = Instantiate(_text, parentTransform);
            
            textMeshPro.SetText(text);
            textMeshPro.color = color;
            textMeshPro.transform.position = position;
            textMeshPro.transform.DOMove((Vector2)textMeshPro.transform.position + direction, _animationDuration);

            return textMeshPro;
        }
    }
}