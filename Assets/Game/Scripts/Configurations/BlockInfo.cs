using UnityEngine;
using UnityEngine.Serialization;

namespace Configurations
{
    [CreateAssetMenu(menuName = "Create block info", order = 0)]
    public class BlockInfo : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Color _particleEffectColor;
        [SerializeField] private float _radius;
        [SerializeField] private int _scoreForSlicing;
        [SerializeField] private ComboBehavior _comboBehavior;
        [SerializeField] private FallenBehaviour _fallenBehaviour;
        public Sprite Sprite => _sprite;
        public Color ParticleEffectColor => _particleEffectColor;
        public float Radius => _radius;
        public int ScoreForSlicing => _scoreForSlicing;
        public ComboBehavior ComboBehavior => _comboBehavior;
        public FallenBehaviour FallenBehaviour => _fallenBehaviour;
        public void SetSprite(Sprite sprite) => _sprite = sprite;
    }
    
    public enum ComboBehavior
    {
        Supports,
        BreaksComboSequence
    }

    public enum FallenBehaviour
    {
        None,
        HealthImpact
    }
}