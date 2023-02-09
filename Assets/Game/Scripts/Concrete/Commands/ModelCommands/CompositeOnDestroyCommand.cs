using System.Collections.Generic;
using Concrete.Commands.ModelCommands.Base;
using Entities.Base;

namespace Concrete.Commands.ModelCommands
{
    public class CompositeOnDestroyCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly IList<ICuttableBlockOnDestroyCommand> _commands;

        public CompositeOnDestroyCommand(IList<ICuttableBlockOnDestroyCommand> commands) => _commands = commands;

        public void OnDestroy(CuttableBlock entity)
        {
            foreach (var destroyCommand in _commands)
            {
                destroyCommand.OnDestroy(entity);
            }
        }
    }
}