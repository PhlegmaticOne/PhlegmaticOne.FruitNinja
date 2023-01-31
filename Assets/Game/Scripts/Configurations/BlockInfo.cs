using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(menuName = "Create block info", order = 0)]
    public class BlockInfo : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite => _sprite;
    }
}