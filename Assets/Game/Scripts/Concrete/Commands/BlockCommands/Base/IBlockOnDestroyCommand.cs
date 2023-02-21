using Abstracts.Commands;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;

namespace Concrete.Commands.BlockCommands.Base
{
    public interface IBlockOnDestroyCommand : IOnDestroyCommand<Block, BlockDestroyContext> { }
}