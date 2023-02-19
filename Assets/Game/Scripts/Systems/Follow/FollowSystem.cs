using System.Collections.Generic;
using Abstracts.Stages;
using Entities.Base;
using InputSystem;
using UnityEngine;

namespace Systems.Follow
{
    public class FollowSystem : MonoBehaviour, IStageable
    {
        private IInputSystem _inputSystem;
        private readonly List<Block> _blocks = new List<Block>();

        private Camera _camera;
        private Coroutine _followCoroutine;

        public void Initialize(IInputSystem inputSystem, Camera cam)
        {
            _inputSystem = inputSystem;
            _camera = cam;
        }

        public void Enable()
        {
            _inputSystem.Ended += InputSystemOnEnded;
            _inputSystem.Moved += InputSystemOnMoved;
        }
        

        public void Disable()
        {
            _inputSystem.Ended -= InputSystemOnEnded;
            _inputSystem.Moved -= InputSystemOnMoved;
            
            foreach (var block in _blocks)
            {
                DestroyBlock(block);
            }
            
            _blocks.Clear();
        }
        
        public void Follow(Block block)
        {
            block.Fallen += BlockOnFallen;
            block.DisableGravity();
            _blocks.Add(block);
        }

        private void BlockOnFallen(Block obj) => DestroyBlock(obj);

        private void InputSystemOnMoved(Vector3 position)
        {
            if (_blocks.Count == 0)
            {
                return;
            }
            
            foreach (var block in _blocks)
            {
                block.transform.position = GetPosition(position);
            }
        }

        private void InputSystemOnEnded()
        {
            if (_blocks.Count == 0)
            {
                return;
            }
            
            foreach (var block in _blocks)
            {
                block.EnableDefaultGravity();
            }

            _blocks.Clear();
        }

        private Vector3 GetPosition(Vector3 inputPosition)
        {
            var position = _camera.ScreenToWorldPoint(inputPosition);
            position.z = _camera.nearClipPlane;
            return position;
        }

        private void DestroyBlock(Block block)
        {
            block.Fallen -= BlockOnFallen;
            block.PermanentDestroy();
        }
    }
}