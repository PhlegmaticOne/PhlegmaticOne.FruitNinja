using System;
using System.Collections.Generic;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Configurations.Blocks;
using Entities.Base;
using Spawning.Spawning.Commands;

namespace Spawning.Commands
{
    public class OnDestroyCommandsProvider : IOnDestroyCommandsProvider
    {
        private readonly Dictionary<Type, Func<IBlockConfiguration, List<IBlockOnDestroyCommand>>>
            _onDestroyCommandsFactories;

        public OnDestroyCommandsProvider()
        {
            _onDestroyCommandsFactories =
                new Dictionary<Type, Func<IBlockConfiguration, List<IBlockOnDestroyCommand>>>();
        }

        public void On<TConfiguration>(Func<TConfiguration, List<IBlockOnDestroyCommand>> commandsFactory)
            where TConfiguration : IBlockConfiguration
        {
            _onDestroyCommandsFactories.Add(
                typeof(TConfiguration),
                c => commandsFactory.Invoke((TConfiguration)c));
        }

        public IBlockOnDestroyCommand CreateCommand(IBlockConfiguration blockConfiguration)
        {
            var factory = _onDestroyCommandsFactories[blockConfiguration.GetType()];
            var commands = factory.Invoke(blockConfiguration);
            return new CompositeOnDestroyCommand(commands);
        }
        
        private class CompositeOnDestroyCommand : IBlockOnDestroyCommand
        {
            private readonly IList<IBlockOnDestroyCommand> _commands;

            public CompositeOnDestroyCommand(IList<IBlockOnDestroyCommand> commands) => _commands = commands;

            public void OnDestroy(Block entity, BlockDestroyContext destroyContext)
            {
                foreach (var command in _commands)
                {
                    command.OnDestroy(entity, destroyContext);
                }
            }
        }
    }
}