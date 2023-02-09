using Abstracts.Commands;
using Scenes;

namespace Concrete.Commands.ButtonCommands
{
    public class TransitToSceneCommand : ICommand
    {
        private readonly int _sceneIndex;
        private readonly SceneTransition _sceneTransition;

        public TransitToSceneCommand(int sceneIndex, SceneTransition sceneTransition)
        {
            _sceneIndex = sceneIndex;
            _sceneTransition = sceneTransition;
        }

        public void Execute() => _sceneTransition.TransitToScene(_sceneIndex);
    }
}