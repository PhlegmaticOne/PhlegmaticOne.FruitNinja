using Concrete.Commands.ViewCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Configurations;
using DG.Tweening;
using Entities.Base;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Concrete.Commands.ViewCommands
{
    public class ShowScoreOnScreenViewCommand : ICuttableBlockOnDestroyViewCommand
    {
        private readonly TextMeshProUGUI _text;
        private readonly Transform _uiTransform;
        private readonly float _animationDuration;

        public ShowScoreOnScreenViewCommand(TextMeshProUGUI text, Transform uiTransform, float animationDuration)
        {
            _text = text;
            _uiTransform = uiTransform;
            _animationDuration = animationDuration;
        }

        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            var text = SpawnText(entity.transform.position, destroyContext.SlicingVector, entity.BlockInfo);
            Object.Destroy(text, _animationDuration);
        }

        private TextMeshProUGUI SpawnText(Vector3 position, Vector2 moveLabelVector, BlockInfo blockInfo)
        {
            var text = Object.Instantiate(_text, _uiTransform);
            
            text.SetText(blockInfo.ScoreForSlicing.ToString());
            text.color = blockInfo.JuiceEffectColor;
            text.transform.position = position;
            text.transform.DOMove((Vector2)text.transform.position + moveLabelVector, _animationDuration);

            return text;
        }
    }
}