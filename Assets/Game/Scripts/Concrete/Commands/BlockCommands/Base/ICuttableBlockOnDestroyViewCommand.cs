using Abstracts.Commands;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;

namespace Concrete.Commands.BlockCommands.Base
{
    public interface ICuttableBlockOnDestroyCommand : IOnDestroyCommand<CuttableBlock, BlockDestroyContext> { }
}