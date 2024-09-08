﻿using Abstracts.Data;
using Abstracts.Initialization;
using Concrete.Commands.ButtonCommands;
using Scenes;
using Systems.Score.Models;
using UnityEngine;

namespace StartScene
{
    public class StartSceneComposite : MonoBehaviour
    {
        [SerializeField] private StartScenePopup _startScenePopup;
        [SerializeField] private SceneTransition _sceneTransition;
        [SerializeField] private InitializerBase<IRepository<ScoreModel>> _repositoryInitializer;
        [SerializeField] private int _gameSceneIndex;
        private void Awake()
        {
            SetTimeScale(1f);
            _startScenePopup.Initialize(_repositoryInitializer.Create());
            _startScenePopup.OnStartGameClickExecuteCommand(new TransitToSceneCommand(_gameSceneIndex, _sceneTransition));
            _startScenePopup.OnExitButtonClickExecuteCommand(new ExitCommand());
        }
        
        private void SetTimeScale(float scale)
        {
            Time.timeScale = scale;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
}