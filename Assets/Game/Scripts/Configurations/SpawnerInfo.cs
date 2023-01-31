using System;
using Abstracts.Probabilities;
using UnityEngine;

namespace Configurations
{
    [Serializable]
    public class SpawnerInfo : IHavePriority
    {
        [SerializeField] private SpawnLine _spawnLine;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle;
        [SerializeField] private int _priority;

        public Transform FromPoint => _spawnLine.FromPoint;
        public Transform ToPoint => _spawnLine.ToPoint;
        public float MinAngle => _minAngle;
        public float MaxAngle => _maxAngle;
        public float Priority => _priority;
    }
}