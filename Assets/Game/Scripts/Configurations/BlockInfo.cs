using UnityEngine;
using UnityEngine.Serialization;

namespace Configurations
{
    [CreateAssetMenu(menuName = "BlocksInfo/Create block info", order = 0)]
    public class BlockInfo : ScriptableObject
    {
        [SerializeField] private bool _destroyOnCut = true;
        [SerializeField] private bool _isCuttable = true;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Color _particleEffectColor;
        [SerializeField] private float _radius;
        [SerializeField] private int _scoreForSlicing;
        [SerializeField] private ComboBehavior _comboBehavior;
        [SerializeField] private FallenBehaviour _fallenBehaviour;
        [SerializeField] private MagnetBehaviour _magnetBehaviour;
        public bool DestroyOnCut => _destroyOnCut;
        public bool IsCuttable => _isCuttable;
        public Sprite Sprite => _sprite;
        public Color ParticleEffectColor => _particleEffectColor;
        public float Radius => _radius;
        public int ScoreForSlicing => _scoreForSlicing;
        public ComboBehavior ComboBehavior => _comboBehavior;
        public FallenBehaviour FallenBehaviour => _fallenBehaviour;
        public MagnetBehaviour MagnetBehaviour => _magnetBehaviour;
        public void SetSprite(Sprite sprite) => _sprite = sprite;
        public void SetIsCuttable(bool isCuttable) => _isCuttable = isCuttable;
        public void SetMagnetBehaviour(MagnetBehaviour magnetBehaviour) => _magnetBehaviour = magnetBehaviour;
    }
    
    public enum ComboBehavior
    {
        None,
        Supports,
        BreaksComboSequence
    }

    public enum FallenBehaviour
    {
        None,
        HealthImpact
    }

    public enum MagnetBehaviour
    {
        None,
        Magnetized
    }
}