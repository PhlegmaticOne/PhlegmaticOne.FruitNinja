using UnityEngine;

namespace Entities.Base
{
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void SetSprite(Sprite sprite) => _spriteRenderer.sprite = sprite;

        public Sprite GetSprite() => _spriteRenderer.sprite;
    }
}