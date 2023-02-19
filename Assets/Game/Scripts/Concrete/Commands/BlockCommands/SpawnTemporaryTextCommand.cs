using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;
using Helpers;
using UnityEngine;

namespace Concrete.Commands.BlockCommands
{
    public class SpawnTemporaryTextCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly string _text;
        private readonly TemporaryTextMeshPro _temporaryTextMeshPro;
        private readonly Transform _uiTransform;

        public SpawnTemporaryTextCommand(string text, TemporaryTextMeshPro temporaryTextMeshPro, Transform uiTransform)
        {
            _text = text;
            _temporaryTextMeshPro = temporaryTextMeshPro;
            _uiTransform = uiTransform;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            _temporaryTextMeshPro.SpawnText(_text, entity.transform.position, 
                destroyContext.SlicingVector, Color.white, _uiTransform);
        }
    }
}