namespace Spawning.Spawning.Difficulty
{
    public class DifficultyInfo
    {
        public int BlocksInPackageCount { get; set; }
        public float TimeToNextBlockPackage { get; set; }
        public float DecreaseBlocksInPackageIntervalsBy { get; set; }
        public float BlocksGravity { get; set; }
        public float TotalBonusesSpawnPercentage { get; set; }
        public float TotalDebufsSpawnPercentage { get; set; }
    }
}