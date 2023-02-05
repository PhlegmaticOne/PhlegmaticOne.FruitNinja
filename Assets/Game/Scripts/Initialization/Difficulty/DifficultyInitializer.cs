using Abstracts.Initialization;
using Spawning.Spawning.Difficulty;
using UnityEngine;

namespace Initialization.Difficulty
{
    public class DifficultyInitializer : InitializerBase<ISpawningDifficulty>
    {
        [SerializeField] private int _maxDifficulty;
        [SerializeField] private int _maxIncreaseGravityCoefficient;
        
        public override ISpawningDifficulty Create()
        {
            return new DefaultSpawningDifficulty(_maxDifficulty, _maxIncreaseGravityCoefficient);
        }
    }
}