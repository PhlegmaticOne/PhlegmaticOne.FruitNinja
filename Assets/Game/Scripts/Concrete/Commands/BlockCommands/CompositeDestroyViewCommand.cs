using System.Collections.Generic;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;

namespace Concrete.Commands.BlockCommands
{
    public class CompositeDestroyViewCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly IList<ICuttableBlockOnDestroyCommand> _commands;

        public CompositeDestroyViewCommand(IList<ICuttableBlockOnDestroyCommand> commands) => _commands = commands;

        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            foreach (var command in _commands)
            {
                command.OnDestroy(entity, destroyContext);
            }
        }
    }
}