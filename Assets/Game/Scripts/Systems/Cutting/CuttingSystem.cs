using System.Linq;
using Systems.Blocks;
using Systems.Score;
using UnityEngine;

namespace Systems.Cutting
{
    public class CuttingSystem : MonoBehaviour
    {
        [SerializeField] private float _minSlicingSpeed = 50f;
        [SerializeField] private Blade _blade;
        [SerializeField] private Camera _camera;
        [SerializeField] private CuttableBlocksSystem _blocksSystem;
        [SerializeField] private ScoreSystem _scoreSystem;

        private void Update()
        {
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
            var slicingSpeed = GetSlicingSpeed(slicingVector);
            _blade.SliceTo(slicePoint);

            if (slicingSpeed > _minSlicingSpeed)
            {
                CutBlocks(slicingVector, slicePoint);
            }
        }

        private void CutBlocks(Vector2 slicingVector, Vector2 slicingPoint)
        {
            foreach (var cuttableBlock in _blocksSystem.CuttableBlocksOnField.ToList())
            {
                var distance = (cuttableBlock.transform.position - _blade.transform.position).magnitude;
                
                if (distance <= cuttableBlock.BlockInfo.Radius)
                {
                    cuttableBlock.Cut(slicingVector, slicingPoint);
                    
                    _scoreSystem.AddScorePoints(1);
                }
            }
        }

        private float GetSlicingSpeed(Vector2 slicingVector) => slicingVector.magnitude / Time.deltaTime;

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