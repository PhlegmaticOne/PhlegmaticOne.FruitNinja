using Abstracts.Factories;
using Abstracts.Initialization;
using Concrete.Factories.Blocks;
using Entities.Base;
using Game.Scripts.Concrete.Data;
using Spawning.Spawning;
using Spawning.Spawning.Difficulty;
using Systems.Score;
using UnityEngine;

namespace Composite
{
    public class GameSceneComposite : MonoBehaviour
    {
        [SerializeField] private CuttableBlocksSpawningSystem _spawningSystem;
        [SerializeField] private InitializerBase<IFactory<BlockCreationContext, CuttableBlock>> _factoryInitializer;
        [SerializeField] private InitializerBase<ISpawningDifficulty> _difficultyInitializer;
        [SerializeField] private ScoreSystem _scoreSystem;
        private void Awake()
        {
            _spawningSystem.Initialize(_factoryInitializer.Create(), _difficultyInitializer.Create());
            _scoreSystem.Initialize(new InMemoryMaxScoreRepository());
        }
    }
}