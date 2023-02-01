using UnityEngine;

namespace Effects
{
    public class ShadowEffect : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Material _shadowMaterial;
        [SerializeField] private Vector2 _shadowOffset;
        [SerializeField] private Transform _transform;
        public void SetShadowForSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
            _spriteRenderer.material = _shadowMaterial;
        }

        public void UpdateShadow(Transform mainSpriteTransform)
        {
            transform.position = mainSpriteTransform.position + (Vector3) _shadowOffset;
            transform.localRotation = _transform.localRotation;
        }
    }
}