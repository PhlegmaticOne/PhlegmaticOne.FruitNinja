using System.Collections.Generic;
using System.Linq;
using Abstracts.Commands;
using Entities.Base;

namespace Concrete.Commands
{
    public class CompositeDestroyViewCommand : IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext>
    {
        private readonly List<IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext>> _commands;

        public CompositeDestroyViewCommand(
            IEnumerable<IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext>> commands)
        {
            _commands = commands.ToList();
        }

        public void OnDestroy(CuttableBlock entity, FruitDestroyContext destroyContext)
        {
            foreach (var command in _commands)
            {
                command.OnDestroy(entity, destroyContext);
            }
        }
    }
}