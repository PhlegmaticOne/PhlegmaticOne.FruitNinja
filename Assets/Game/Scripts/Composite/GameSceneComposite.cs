﻿using System.Collections.Generic;
using Abstracts.Data;
using Abstracts.Initialization;
using Abstracts.Stages;
using Concrete.Commands.ButtonCommands;
using Concrete.Factories.Blocks.Base;
using Configurations;
using Scenes;
using Spawning.Spawning;
using Spawning.Spawning.Difficulty;
using Systems.Health;
using Systems.Losing;
using Systems.Score;
using Systems.Score.Models;
using UnityEngine;

namespace Composite
{
    public class GameSceneComposite : MonoBehaviour
    {
        [SerializeField] private CuttableBlocksSpawningSystem _spawningSystem;
        [SerializeField] private InitializerBase<ICuttableBlocksFactory> _factoryInitializer;
        [SerializeField] private InitializerBase<ISpawningDifficulty> _difficultyInitializer;
        
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private InitializerBase<IRepository<ScoreModel>> _repositoryInitalizer;

        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private HealthSystemConfiguration _healthSystemConfiguration;

        [SerializeField] private LosingSystem _losingSystem;
        [SerializeField] private InitializerBase<List<IStageable>> _stageablesInitializer;
        
        [SerializeField] private SceneTransition _sceneTransition;
        [SerializeField] private int _startSceneIndex;

        private List<IStageable> _stageables;
        private void Awake()
        {
            _stageables = _stageablesInitializer.Create();
            
            _spawningSystem.Initialize(_factoryInitializer.Create(), _difficultyInitializer.Create());
            _scoreSystem.Initialize(_repositoryInitalizer.Create());
            _healthSystem.Initialize(_healthSystemConfiguration);
            _losingSystem.Initialize(
                new RestartCommand(_stageables),
                new TransitToSceneCommand(_startSceneIndex, _sceneTransition),
                new DisableCommand(_stageables));
        }

        private void Start() => EnableAll(_stageables);

        private void EnableAll(List<IStageable> stageables)
        {
            foreach (var stageable in stageables)
            {
                stageable.Enable();
            }
        }
    }
}