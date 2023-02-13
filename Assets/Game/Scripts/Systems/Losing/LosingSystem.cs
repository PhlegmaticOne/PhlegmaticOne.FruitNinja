using Abstracts.Commands;
using Abstracts.Stages;
using Systems.Blocks;
using Systems.Health;
using Systems.Score;
using UnityEngine;

namespace Systems.Losing
{
    public class LosingSystem : MonoBehaviour, IStageable
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private StateCheckingBlocksSystem _blocksSystem;
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private LosePopup _losePopup;

        private ICommand _gameLostCommand;

        public void Initialize(ICommand restartCommand, ICommand menuCommand, ICommand gameLostCommand)
        {
            _losePopup.OnRestartButtonClickedExecute(restartCommand);
            _losePopup.OnMenuButtonClickedExecute(menuCommand);
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