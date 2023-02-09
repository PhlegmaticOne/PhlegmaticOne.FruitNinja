using UnityEngine;

namespace Systems.Cutting
{
    public class Blade : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trailRenderer;
        public bool IsSlicing { get; private set; }
        public void StartSlicing(Vector3 slicePoint)
        {
            SliceTo(slicePoint);
            _trailRenderer.enabled = true;
            _trailRenderer.Clear();
            IsSlicing = true;
        }

        public void SliceTo(Vector3 newPosition) => transform.position = newPosition;

        public void EndSlicing()
        {
            _trailRenderer.enabled = false;
            IsSlicing = false;
        }
    }
}