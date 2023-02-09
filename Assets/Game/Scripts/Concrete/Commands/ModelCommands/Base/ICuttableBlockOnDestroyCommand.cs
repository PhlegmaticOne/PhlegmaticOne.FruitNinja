using Abstracts.Commands;
using Entities.Base;

namespace Concrete.Commands.ModelCommands.Base
{
    public interface ICuttableBlockOnDestroyCommand : IOnDestroyCommand<CuttableBlock> { }
}