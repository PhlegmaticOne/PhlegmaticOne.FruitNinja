using UnityEngine;

namespace Configurations
{
    public class SpawnLine : MonoBehaviour
    {
        [SerializeField] private Transform _fromPoint;
        [SerializeField] private Transform _toPoint;

        public Transform FromPoint => _fromPoint;
        public Transform ToPoint => _toPoint;
    }
}