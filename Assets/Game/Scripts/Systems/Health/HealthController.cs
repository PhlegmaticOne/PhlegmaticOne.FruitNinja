using System.Collections;
using Abstracts.Stages;
using Configurations;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Systems.Health
{
    public class HealthController : MonoBehaviour, IStageable
    {
        private bool _isRemoving;
        private HealthSystem _healthSystem;
        private StateCheckingBlocksSystem _stateCheckingBlocksSystem;

        public void Initialize(HealthSystem healthSystem, StateCheckingBlocksSystem stateCheckingBlocksSystem)
        {
            _healthSystem = healthSystem;
            _stateCheckingBlocksSystem = stateCheckingBlocksSystem;
            _isRemoving = true;
        }

        public void DisableHeartRemoving(float time)
        {
            StartCoroutine(DisableHeartRemovingRoutine(time));
        }

        private IEnumerator DisableHeartRemovingRoutine(float time)
        {
            _isRemoving = false;
            yield return new WaitForSeconds(time);
            _isRemoving = true;
        }
        
        public void Enable()
        {
            _stateCheckingBlocksSystem.BlockFallen += StateCheckingBlocksSystemOnBlockFallen;
            _healthSystem.ResetHearts();
        }

        public void Disable() => _stateCheckingBlocksSystem.BlockFallen -= StateCheckingBlocksSystemOnBlockFallen;

        private void StateCheckingBlocksSystemOnBlockFallen(Block obj)
        {
            if (obj.IsCuttable && 
                obj.BlockInfo.FallenBehaviour == FallenBehaviour.HealthImpact && 
                _isRemoving)
            {
                _healthSystem.RemoveHeart();
            }
        }
    }
}