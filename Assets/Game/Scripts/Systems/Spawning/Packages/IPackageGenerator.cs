using Spawning.Spawning.Difficulty;

namespace Spawning.Spawning.Packages
{
    public interface IPackageGenerator
    {
        BlocksPackage GeneratePackage(DifficultyInfo difficultyInfo);
    }
}