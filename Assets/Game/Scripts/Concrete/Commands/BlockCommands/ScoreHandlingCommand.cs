using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Configurations;
using Entities.Base;
using Helpers;
using Systems.Combos;
using Systems.Combos.Handling;
using Systems.Score;
using UnityEngine;

namespace Concrete.Commands.BlockCommands
{
    public class ScoreHandlingCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly IComboScoreHandlingPolicy _comboScoreHandlingPolicy;
        private readonly ComboSystem _comboSystem;
        private readonly ScoreSystem _scoreSystem;
        private readonly TemporaryTextMeshPro _temporaryTextMeshPro;
        private readonly Transform _textParentTransform;

        public ScoreHandlingCommand(IComboScoreHandlingPolicy comboScoreHandlingPolicy,
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
            switch (entity.BlockInfo.ComboBehavior)
            {
                case ComboBehavior.BreaksComboSequence:
                {
                    _comboSystem.ResetCombos();
                    return;
                }
                case ComboBehavior.Supports:
                {
                    TryAddCombo(entity, destroyContext);
                    break;
                }
                default:
                {
                    return;
                }
            }
        }

        private void TryAddCombo(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            var position = entity.transform.position;
            var numberInComboSequence = _comboSystem.TryAddCombo(position);
            
            var newScore = _comboScoreHandlingPolicy
                .GetScoreFromPositionInCombo(entity.BlockInfo.ScoreForSlicing, numberInComboSequence);
            
            _temporaryTextMeshPro.SpawnText(newScore.ToString(), position, 
                destroyContext.SlicingVector, entity.BlockInfo.ParticleEffectColor, _textParentTransform);
            
            _scoreSystem.AddScorePoints(newScore);
        }
    }
}