using Concrete.Commands.ViewCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Configurations;
using Entities.Base;
using Systems.Combos;
using Systems.Score;
using UnityEngine;

namespace Concrete.Commands.ViewCommands
{
    public class ScoreHandlingViewCommand : ICuttableBlockOnDestroyViewCommand
    {
        private readonly IComboScoreHandlingPolicy _comboScoreHandlingPolicy;
        private readonly ComboSystem _comboSystem;
        private readonly ScoreSystem _scoreSystem;
        private readonly TemporaryScreenScoreView _temporaryScreenScoreView;
        private readonly Transform _textParentTransform;

        public ScoreHandlingViewCommand(IComboScoreHandlingPolicy comboScoreHandlingPolicy,
            ComboSystem comboSystem,
            ScoreSystem scoreSystem,
            TemporaryScreenScoreView temporaryScreenScoreView,
            Transform textParentTransform)
        {
            _comboScoreHandlingPolicy = comboScoreHandlingPolicy;
            _comboSystem = comboSystem;
            _scoreSystem = scoreSystem;
            _temporaryScreenScoreView = temporaryScreenScoreView;
            _textParentTransform = textParentTransform;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            if (entity.BlockInfo.ComboBehavior == ComboBehavior.BreaksComboSequence)
            {
                _comboSystem.ResetCombos();
                return;
            }

            var position = entity.transform.position;
            var numberInComboSequence = _comboSystem.TryAddCombo(position);
            
            var newScore = _comboScoreHandlingPolicy
                .GetScoreFromPositionInCombo(entity.BlockInfo.ScoreForSlicing, numberInComboSequence);
            
            _temporaryScreenScoreView.SpawnScoreText(newScore, position, 
                    destroyContext.SlicingVector, entity.BlockInfo.JuiceEffectColor, _textParentTransform);
            
            _scoreSystem.AddScorePoints(newScore);
        }
    }

    public interface IComboScoreHandlingPolicy
    {
        int GetScoreFromPositionInCombo(int score, int comboNumber);
    }

    public class ComboScoreHandlingPolicy : IComboScoreHandlingPolicy
    {
        public int GetScoreFromPositionInCombo(int score, int comboNumber)
        {
            return score * comboNumber;
        }
    }
}