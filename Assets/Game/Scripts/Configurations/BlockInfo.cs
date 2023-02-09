using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(menuName = "Create block info", order = 0)]
    public class BlockInfo : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Color _juiceEffectColor;
        [SerializeField] private float _radius;
        [SerializeField] private int _scoreForSlicing;
        public Sprite Sprite => _sprite;
        public Color JuiceEffectColor => _juiceEffectColor;
        public float Radius => _radius;
        public int ScoreForSlicing => _scoreForSlicing;
        public void SetSprite(Sprite sprite) => _sprite = sprite;
    }
}