using Abstracts.Stages;
using Configurations;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Systems.Health
{
    public class HealthController : MonoBehaviour, IStageable
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private StateCheckingBlocksSystem _stateCheckingBlocksSystem;
        
        public void Enable()
        {
            _stateCheckingBlocksSystem.BlockFallen += StateCheckingBlocksSystemOnBlockFallen;
            _healthSystem.ResetHearts();
        }

        public void Disable() => _stateCheckingBlocksSystem.BlockFallen -= StateCheckingBlocksSystemOnBlockFallen;

        private void StateCheckingBlocksSystemOnBlockFallen(Block obj)
        {
            if (obj is CuttableBlock cuttableBlock && cuttableBlock.BlockInfo.FallenBehaviour == FallenBehaviour.HealthImpact)
            {
                _healthSystem.RemoveHeart();
            }
        }
    }
}