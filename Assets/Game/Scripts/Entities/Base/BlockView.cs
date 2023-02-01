using Effects;
using UnityEngine;

namespace Entities.Base
{
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private ShadowEffect _shadowEffect;
        
        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
            _shadowEffect.SetShadowForSprite(sprite);
        }

        private void LateUpdate()
        {
            _shadowEffect.UpdateShadow(transform);
        }
        

        public Sprite GetSprite() => _spriteRenderer.sprite;
    }
}