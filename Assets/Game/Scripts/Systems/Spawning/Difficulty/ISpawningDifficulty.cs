namespace Spawning.Spawning.Difficulty
{
    public interface ISpawningDifficulty
    {
        DifficultyInfo CalculateDifficultyInfo(int spawnIteration);
    }
}