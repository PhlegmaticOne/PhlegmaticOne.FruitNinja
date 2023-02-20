using System.Collections.Generic;
using Abstracts.Initialization;
using Abstracts.Stages;
using Spawning.Spawning;
using Systems.Blocks;
using Systems.Cutting;
using Systems.Follow;
using Systems.Freezing;
using Systems.Health;
using Systems.Losing;
using Systems.Magnet;
using Systems.Samurai;
using Systems.Score;
using UnityEngine;
using UnityEngine.Serialization;

namespace Initialization.Stages
{
    public class StageablesAccessor : MonoBehaviour
    {
        [SerializeField] private StateCheckingBlocksSystem _stateCheckingBlocksSystem;
        [SerializeField] private CuttingSystem _cuttingSystem;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private LosingSystem _losingSystem;
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private SpawningSystem _spawningSystem;
        [SerializeField] private FollowSystem _followSystem;
        [SerializeField] private FreezingSystem _freezingSystem;
        [SerializeField] private MagnetSystem _magnetSystem;
        [SerializeField] private SamuraiCanvas _samuraiCanvas;

        private List<IStageable> _stageables;
        public List<IStageable> GetStageables()
        {
            return _stageables ??= new List<IStageable>
            {
                _samuraiCanvas,
                _followSystem,
                _freezingSystem,
                _magnetSystem,
                _stateCheckingBlocksSystem,
                _scoreSystem,
                _cuttingSystem,
                _spawningSystem,
                _healthController,
                _losingSystem,
            };
        }
    }
}