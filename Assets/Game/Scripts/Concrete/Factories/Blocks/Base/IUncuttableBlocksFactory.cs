using Abstracts.Factories;
using Concrete.Factories.Blocks.Models;
using Entities.Base;

namespace Concrete.Factories.Blocks.Base
{
    public interface IUncuttableBlocksFactory : IFactory<FromBlockBlockCreationContext, UncuttableBlock> { }
}