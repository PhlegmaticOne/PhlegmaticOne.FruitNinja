using Abstracts.Initialization;
using Configurations;
using Spawning.Spawning.Difficulty;
using UnityEngine;

namespace Initialization.Spawning
{
    public class DifficultyInitializer : InitializerBase<ISpawningDifficulty>
    {
        [SerializeField] private int _maxDifficulty;
        [SerializeField] private int _maxIncreaseGravityCoefficient;
        [SerializeField] private SpawningSystemInfo _spawningSystemInfo;
        
        public override ISpawningDifficulty Create()
        {
            return new DefaultSpawningDifficulty(_maxDifficulty, _maxIncreaseGravityCoefficient, _spawningSystemInfo);
        }
    }
}