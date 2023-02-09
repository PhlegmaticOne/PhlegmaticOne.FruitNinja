using Abstracts.Commands;
using UnityEngine;

namespace Concrete.Commands.ButtonCommands
{
    public class ExitCommand : ICommand
    {
        public void Execute() => Application.Quit();
    }
}