using System.Collections.Generic;
using Abstracts.Commands;
using Abstracts.Stages;

namespace Concrete.Commands.ButtonCommands
{
    public class RestartCommand : ICommand
    {
        private readonly IList<IStageable> _stageables;
        
        public RestartCommand(IList<IStageable> stageables) => _stageables = stageables;

        public void Execute()
        {
            foreach (var stageable in _stageables)
            {
                stageable.Enable();
            }
        }
    }
}