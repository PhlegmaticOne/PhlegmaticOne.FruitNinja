using Concrete.Commands.BlockCommands.Base;
using Configurations.Blocks;

namespace Spawning.Spawning.Commands
{
    public interface IOnDestroyCommandsProvider
    {
        ICuttableBlockOnDestroyCommand CreateCommand(IBlockConfiguration blockConfiguration);
    }
}