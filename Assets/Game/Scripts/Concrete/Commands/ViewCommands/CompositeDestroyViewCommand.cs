using System.Collections.Generic;
using System.Linq;
using Abstracts.Commands;
using Concrete.Commands.ViewCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;

namespace Concrete.Commands.ViewCommands
{
    public class CompositeDestroyViewCommand : ICuttableBlockOnDestroyViewCommand
    {
        private readonly IList<ICuttableBlockOnDestroyViewCommand> _commands;

        public CompositeDestroyViewCommand(IList<ICuttableBlockOnDestroyViewCommand> commands) => _commands = commands;

        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            foreach (var command in _commands)
            {
                command.OnDestroy(entity, destroyContext);
            }
        }
    }
}