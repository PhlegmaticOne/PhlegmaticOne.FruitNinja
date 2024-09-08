using UnityEngine;

namespace Configurations.Systems
{
    [CreateAssetMenu(menuName = "Systems/Create losing system configuration", order = 0)]
    public class LosingSystemConfiguration : ScriptableObject
    {
        [SerializeField] private float _popupAnimationDuration;
        public float PopupAnimationDuration => _popupAnimationDuration;
    }
}