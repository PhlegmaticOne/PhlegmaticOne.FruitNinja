using Abstracts.Probabilities;
using Configurations.Base;
using UnityEngine;

namespace Configurations.Spawning
{
    public class SpawnerInfo : MonoBehaviour, IHavePriority
    {
        [SerializeField] private SpawnLine _spawnLine;
        [SerializeField] private MinMaxInfo<float> _anglesRange;
        [SerializeField] private MinMaxInfo<float> _initialSpeedMultiplierRangeX;
        [SerializeField] private MinMaxInfo<float> _initialSpeedMultiplierRangeY;
        [SerializeField] private int _priority;

        public Transform FromPoint => _spawnLine.FromPoint;
        public Transform ToPoint => _spawnLine.ToPoint;
        public MinMaxInfo<float> AnglesRange => _anglesRange;
        public MinMaxInfo<float> InitialSpeedMultiplierRangeX => _initialSpeedMultiplierRangeX;
        public MinMaxInfo<float> InitialSpeedMultiplierRangeY => _initialSpeedMultiplierRangeY;
        public float Priority => _priority;
    }
}