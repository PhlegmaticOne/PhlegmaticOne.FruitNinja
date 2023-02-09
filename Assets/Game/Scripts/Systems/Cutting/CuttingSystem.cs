using System.Linq;
using Abstracts.Stages;
using Systems.Blocks;
using UnityEngine;

namespace Systems.Cutting
{
    public class CuttingSystem : MonoBehaviour, IStageable
    {
        [SerializeField] private float minDistanceToSlice;
        [SerializeField] private Blade _blade;
        [SerializeField] private Camera _camera;
        [SerializeField] private CuttableBlocksSystem _cuttableBlocksSystem;
        [SerializeField] private BlocksSystem _blocksSystem;
        private bool _isCutting = true;
        
        public void Enable() => EnableCutting();

        public void Disable() => DisableCutting();

        private void EnableCutting() => _isCutting = true;
        private void DisableCutting() => _isCutting = false;

        private void Update()
        {
            if (_isCutting == false)
            {
                return;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                _blade.StartSlicing(GetSlicePoint());
            }

            if (Input.GetMouseButtonUp(0))
            {
                _blade.EndSlicing();
            }

            if (_blade.IsSlicing)
            {
                PerformSlicing();
            }
        }

        private void PerformSlicing()
        {
            var slicePoint = GetSlicePoint();
            var slicingVector = GetSlicingVector(slicePoint);
            _blade.SliceTo(slicePoint);

            if (slicingVector.magnitude > minDistanceToSlice)
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
                    cuttableBlock.Cut(slicingVector, slicingPoint);
                }
            }
        }

        private Vector2 GetSlicingVector(Vector2 newPosition) =>
            newPosition - (Vector2)_blade.transform.position;

        private Vector3 GetSlicePoint()
        {
            var position = _camera.ScreenToWorldPoint(Input.mousePosition);
            position.z = _camera.nearClipPlane;
            return position;
        }
    }
}