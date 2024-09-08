using Abstracts.Commands;
using Composite.Base;
using Concrete.Commands.ButtonCommands;
using Scenes;
using StartScene;
using Systems.Pause;
using UnityEngine;

namespace Composite.Initialization
{
    public class PauseSystemInitializer : CompositeInitializer
    {
        [SerializeField] private PauseSystem _pauseSystem;
        
        [SerializeField] private PausePopup _pausePopup;
        [SerializeField] private AnimatedButton _pauseButton;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private int _startSceneIndex;
        [SerializeField] private SceneTransition _sceneTransition;
        public override void Initialize()
        {
            _pausePopup.Initialize(
                new TransitToSceneCommand(_startSceneIndex, _sceneTransition),
                new EnableButtonCommand(_pauseButton),
                _fadeDuration);
            
            _pauseSystem.Initialize(_pauseButton, _pausePopup);
        }
        
        private class EnableButtonCommand : ICommand
        {
            private readonly AnimatedButton _animatedButton;

            public EnableButtonCommand(AnimatedButton animatedButton) => _animatedButton = animatedButton;

            public void Execute()
            {
                _animatedButton.Enable();
                _animatedButton.ToNormalState();
            }
        }
    }
}