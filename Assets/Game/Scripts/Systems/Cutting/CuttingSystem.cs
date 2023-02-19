using System.Collections;
using System.Linq;
using Abstracts.Stages;
using Configurations.Systems;
using Entities.Base;
using InputSystem;
using Systems.Blocks;
using UnityEngine;

namespace Systems.Cutting
{
    public class CuttingSystem : MonoBehaviour, IStageable
    {
        private float _minSpeedToSlice;
        private Blade _blade;
        private Camera _camera;
        private FilteringBlocksSystem _cuttableBlocksSystem;
        private BlocksSystem _blocksSystem;
        private IInputSystem _inputSystem;
        
        private InputData _inputData;
        private bool _isCuttingEnabled;
        private bool _isInputEnabled;

        public void Initialize(CuttingSystemConfiguration cuttingSystemConfiguration,
            IInputSystemFactory inputSystemFactory,
            Transform bladeTransform,
            Camera cam,
            FilteringBlocksSystem cuttableBlocksSystem,
            BlocksSystem blocksSystem)
        {
            _blade = Instantiate(cuttingSystemConfiguration.Blade, bladeTransform);
            _minSpeedToSlice = cuttingSystemConfiguration.MinSpeedToSlice;
            _camera = cam;
            _cuttableBlocksSystem = cuttableBlocksSystem;
            _blocksSystem = blocksSystem;
            _inputSystem = inputSystemFactory.CreateInput();
            _isCuttingEnabled = true;
            _isInputEnabled = true;
            _inputData = new InputData(Vector3.zero, InputState.None, false);
        }

        public void DisableCutting(float time)
        {
            _isCuttingEnabled = false;
            StartCoroutine(EnableCuttingAfter(time));
        }

        private IEnumerator EnableCuttingAfter(float time)
        {
            yield return new WaitForSeconds(time);
            _isCuttingEnabled = true;
        }
        
        public void Enable()
        {
            _isCuttingEnabled = true;
            _isInputEnabled = true;
        }

        public void Disable()
        {
            _isCuttingEnabled = false;
            _isInputEnabled = false;
        }

        private void Update()
        {
            if (_isInputEnabled == false)
            {
                return;
            }

            _inputData = _inputSystem.ReadInput();

            switch (_inputData.InputState)
            {
                case InputState.Started:
                    _blade.StartSlicing(GetSlicePoint());
                    break;
                case InputState.Ended:
                    _blade.EndSlicing();
                    break;
            }
        }

        private void FixedUpdate()
        {
            PerformSlicing();
        }

        private void PerformSlicing()
        {
            if (_inputData.IsValid == false)
            {
                return;
            }
            
            var slicePoint = GetSlicePoint();
            var slicingVector = _blade.SliceTo(slicePoint);

            if (_isCuttingEnabled == false)
            {
                return;
            }

            var speed = slicingVector.magnitude / Time.fixedDeltaTime;
            
            if (speed > _minSpeedToSlice)
            {
                CutBlocks(slicingVector, slicePoint);
            }
        }

        private void CutBlocks(Vector2 slicingVector, Vector2 slicingPoint)
        {
            foreach (var cuttableBlock in _cuttableBlocksSystem.CuttableBlocksOnField)
            {
                var distance = (cuttableBlock.transform.position - _blade.transform.position).magnitude;
                
                if (distance <= cuttableBlock.BlockInfo.Radius)
                {
                    _blocksSystem.RemoveBlock(cuttableBlock);

                    cuttableBlock.Cut(new SliceContext
                    {
                        SlicingVector = slicingVector,
                        SlicePoint = slicingPoint,
                    });
                }
            }
        }

        private Vector3 GetSlicePoint()
        {
            var position = _camera.ScreenToWorldPoint(_inputData.Position);
            position.z = _camera.nearClipPlane;
            return position;
        }
    }
}