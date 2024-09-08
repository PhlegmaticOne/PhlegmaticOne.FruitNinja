using Abstracts.Factories;
using Concrete.Factories.Blocks.Models;
using Entities.Base;

namespace Concrete.Factories.Blocks.Base
{
    public interface IBlocksFactory<in TContext> : IFactory<TContext, Block> where TContext : ICreationContext { }
}