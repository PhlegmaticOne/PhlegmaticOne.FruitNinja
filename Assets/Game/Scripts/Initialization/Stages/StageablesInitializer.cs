using System.Collections.Generic;
using Abstracts.Initialization;
using Abstracts.Stages;
using Spawning.Spawning;
using Systems.Blocks;
using Systems.Cutting;
using Systems.Health;
using Systems.Losing;
using Systems.Score;
using UnityEngine;
using UnityEngine.Serialization;

namespace Initialization.Stages
{
    public class StageablesInitializer : InitializerBase<List<IStageable>>
    {
        [SerializeField] private StateCheckingBlocksSystem _stateCheckingBlocksSystem;
        [SerializeField] private CuttingSystem _cuttingSystem;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private LosingSystem _losingSystem;
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private SpawningSystem _spawningSystem;
        public override List<IStageable> Create()
        {
            return new List<IStageable>
            {
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