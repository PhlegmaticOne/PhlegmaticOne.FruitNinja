using Abstracts.Initialization;
using Concrete.Commands.ViewCommands;
using Concrete.Commands.ViewCommands.Base;
using TMPro;
using UnityEngine;

namespace Initialization.ViewCommands
{
    public class ShowScoreOnScreenCommandInitializer : InitializerBase<ICuttableBlockOnDestroyViewCommand>
    {
        [SerializeField] private Transform _uiTransform;
        [SerializeField] private TextMeshProUGUI _textPrefaab;
        [SerializeField] private float _animationDuration;
        public override ICuttableBlockOnDestroyViewCommand Create() => 
            new ShowScoreOnScreenViewCommand(_textPrefaab, _uiTransform, _animationDuration);
    }
}