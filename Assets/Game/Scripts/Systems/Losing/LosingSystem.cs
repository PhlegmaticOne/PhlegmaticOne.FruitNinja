using Abstracts.Commands;
using Abstracts.Stages;
using Configurations.Systems;
using Systems.Blocks;
using Systems.Health;
using Systems.Score;
using UnityEngine;

namespace Systems.Losing
{
    public class LosingSystem : MonoBehaviour, IStageable
    {
        private HealthSystem _healthSystem;
        private StateCheckingBlocksSystem _blocksSystem;
        private ScoreSystem _scoreSystem;
        private LosePopup _losePopup;
        private ICommand _gameLostCommand;

        public void Initialize(LosingSystemConfiguration losingSystemConfiguration,
            LosePopup losePopup,
            HealthSystem healthSystem,
            StateCheckingBlocksSystem stateCheckingBlocksSystem,
            ScoreSystem scoreSystem,
            ICommand gameLostCommand,
            ICommand restartCommand,
            ICommand menuCommand)
        {
            _losePopup = losePopup;
            _losePopup.Initialize(losingSystemConfiguration.PopupAnimationDuration, restartCommand, menuCommand);
            _blocksSystem = stateCheckingBlocksSystem;
            _scoreSystem = scoreSystem;
            _healthSystem = healthSystem;
            _gameLostCommand = gameLostCommand;
        }

        public void Enable() => _healthSystem.HealthEnded += HealthSystemOnHealthEnded;

        public void Disable() => _healthSystem.HealthEnded -= HealthSystemOnHealthEnded;

        private void HealthSystemOnHealthEnded()
        {
            if (_blocksSystem.BlocksCount == 0)
            {
                BlocksSystemOnAllBlocksFallen();    
            }
            
            _blocksSystem.AllBlocksFallen += BlocksSystemOnAllBlocksFallen;
            _gameLostCommand.Execute();
        }

        private void BlocksSystemOnAllBlocksFallen()
        {
            _losePopup.Show(_scoreSystem.GameScore, _scoreSystem.MaxScore);
            _blocksSystem.AllBlocksFallen -= BlocksSystemOnAllBlocksFallen;
        }
    }
}