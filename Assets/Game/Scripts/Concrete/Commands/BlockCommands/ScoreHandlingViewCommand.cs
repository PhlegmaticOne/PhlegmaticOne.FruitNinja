using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Configurations;
using Entities.Base;
using Helpers;
using Systems.Combos;
using Systems.Score;
using UnityEngine;

namespace Concrete.Commands.ViewCommands
{
    public class ScoreHandlingViewCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly IComboScoreHandlingPolicy _comboScoreHandlingPolicy;
        private readonly ComboSystem _comboSystem;
        private readonly ScoreSystem _scoreSystem;
        private readonly TemporaryTextMeshPro _temporaryTextMeshPro;
        private readonly Transform _textParentTransform;

        public ScoreHandlingViewCommand(IComboScoreHandlingPolicy comboScoreHandlingPolicy,
            ComboSystem comboSystem,
            ScoreSystem scoreSystem,
            TemporaryTextMeshPro temporaryTextMeshPro,
            Transform textParentTransform)
        {
            _comboScoreHandlingPolicy = comboScoreHandlingPolicy;
            _comboSystem = comboSystem;
            _scoreSystem = scoreSystem;
            _temporaryTextMeshPro = temporaryTextMeshPro;
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
            
            _temporaryTextMeshPro.SpawnText(newScore.ToString(), position, 
                    destroyContext.SlicingVector, entity.BlockInfo.ParticleEffectColor, _textParentTransform);
            
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