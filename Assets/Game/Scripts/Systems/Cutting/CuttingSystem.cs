using System.Linq;
using Abstracts.Stages;
using Entities.Base;
using InputSystem;
using Systems.Blocks;
using UnityEngine;

namespace Systems.Cutting
{
    public class CuttingSystem : MonoBehaviour, IStageable
    {
        [SerializeField] private float _minDistanceToSlice;
        [SerializeField] private Blade _blade;
        [SerializeField] private Camera _camera;
        [SerializeField] private CuttableBlocksSystem _cuttableBlocksSystem;
        [SerializeField] private BlocksSystem _blocksSystem;
        private bool _isCutting = true;
        
        private IInputSystem _inputSystem;
        private InputData _inputData;

        public void Initialize(IInputSystemFactory inputSystemFactory)
        {
            _inputSystem = inputSystemFactory.CreateInput();
        }

        public void Enable() => _isCutting = true;

        public void Disable() => _isCutting = false;

        private void Update()
        {
            if (_isCutting == false)
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
                case InputState.Active:
                    PerformSlicing();
                    break;
            }
        }

        private void PerformSlicing()
        {
            if (_inputData.IsValid == false)
            {
                return;
            }
            
            var slicePoint = GetSlicePoint();
            var slicingVector = _blade.SliceTo(slicePoint);

            if (slicingVector.magnitude > _minDistanceToSlice)
            {
                CutBlocks(slicingVector, slicePoint);
            }
        }

        private void CutBlocks(Vector2 slicingVector, Vector2 slicingPoint)
        {
            foreach (var cuttableBlock in _cuttableBlocksSystem.CuttableBlocksOnField.ToList())
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