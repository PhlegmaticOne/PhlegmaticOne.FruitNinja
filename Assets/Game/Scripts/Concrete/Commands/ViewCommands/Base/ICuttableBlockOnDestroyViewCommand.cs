using Abstracts.Commands;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;

namespace Concrete.Commands.ViewCommands.Base
{
    public interface ICuttableBlockOnDestroyViewCommand : IOnDestroyViewCommand<CuttableBlock, BlockDestroyContext> { }
}