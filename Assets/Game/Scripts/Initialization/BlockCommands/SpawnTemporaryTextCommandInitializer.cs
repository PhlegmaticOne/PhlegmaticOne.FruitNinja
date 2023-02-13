using Abstracts.Initialization;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands;
using Helpers;
using UnityEngine;

namespace Initialization.BlockCommands
{
    public class SpawnTemporaryTextCommandInitializer : InitializerBase<ICuttableBlockOnDestroyCommand>
    {
        [SerializeField] private string _text;
        [SerializeField] private TemporaryTextMeshPro _temporaryTextMeshPro;
        [SerializeField] private Transform _transform;
        public override ICuttableBlockOnDestroyCommand Create() => 
            new SpawnTemporaryTextCommand(_text, _temporaryTextMeshPro, _transform);
    }
}