using Abstracts.Stages;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Systems.Health
{
    public class HealthController : MonoBehaviour, IStageable
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private StateCheckingBlocksSystem _removeableBlocksSystem;
        
        public void Enable()
        {
            _removeableBlocksSystem.BlockFallen += StateCheckingBlocksSystemOnBlockFallen;
            _healthSystem.ResetHearts();
        }

        public void Disable() => _removeableBlocksSystem.BlockFallen -= StateCheckingBlocksSystemOnBlockFallen;

        private void StateCheckingBlocksSystemOnBlockFallen(Block obj)
        {
            if (obj is CuttableBlock)
            {
                _healthSystem.RemoveHeart();
            }
        }
    }
}