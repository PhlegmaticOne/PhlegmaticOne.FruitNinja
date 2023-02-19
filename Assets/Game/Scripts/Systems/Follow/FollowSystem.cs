using System.Collections.Generic;
using Abstracts.Stages;
using Entities.Base;
using InputSystem;
using Systems.Blocks;
using UnityEngine;

namespace Systems.Follow
{
    public class FollowSystem : MonoBehaviour, IStageable
    {
        private IInputSystem _inputSystem;
        private BlocksSystem _blocksSystem;
        private readonly List<Block> _blocks = new List<Block>();

        private Camera _camera;
        private Coroutine _followCoroutine;

        public void Initialize(BlocksSystem blocksSystem, IInputSystem inputSystem, Camera cam)
        {
            _inputSystem = inputSystem;
            _blocksSystem = blocksSystem;
            _camera = cam;
        }
        
        public void Enable() { }

        public void Disable()
        {
            foreach (var block in _blocks)
            {
                _blocksSystem.RemoveBlock(block);
                block.PermanentDestroy();
            }
            _blocks.Clear();
        }
        
        public void Follow(Block block)
        {
            _inputSystem.Ended += InputSystemOnEnded;
            _inputSystem.Moved += InputSystemOnMoved;
            block.DisableGravity();
            _blocks.Add(block);
        }

        private void InputSystemOnMoved(Vector3 position)
        {
            foreach (var block in _blocks)
            {
                block.transform.position = GetPosition(position);
            }
        }

        private void InputSystemOnEnded()
        {
            _inputSystem.Ended -= InputSystemOnEnded;
            _inputSystem.Moved -= InputSystemOnMoved;

            foreach (var block in _blocks)
            {
                block.EnableDefaultGravity();
                _blocksSystem.AddBlock(block);
            }
            
            _blocks.Clear();
        }

        private Vector3 GetPosition(Vector3 inputPosition)
        {
            var position = _camera.ScreenToWorldPoint(inputPosition);
            position.z = _camera.nearClipPlane;
            return position;
        }

       
    }
}