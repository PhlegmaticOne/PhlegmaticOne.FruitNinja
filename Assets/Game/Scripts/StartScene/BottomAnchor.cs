using UnityEngine;

namespace StartScene
{
    public class BottomAnchor : MonoBehaviour
    {
        [SerializeField] private RectTransform _imageTransform;

        private void Start()
        {
            _imageTransform.anchorMin = new Vector2(0.5f, 0);
            _imageTransform.anchorMax = new Vector2(0.5f, 0);
            _imageTransform.pivot = new Vector2(0.5f, 0);
        }
    }
}