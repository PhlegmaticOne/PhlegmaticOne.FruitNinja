using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Configurations.Spawning;
using Entities.Base;
using Spawning.Spawning;
using Spawning.Spawning.Difficulty;
using Systems.Health;
using Systems.Samurai;

namespace Concrete.Commands.BlockCommands
{
    public class EnableSamuraiModeCommand : IBlockOnDestroyCommand
    {
        private readonly SpawningSystem _spawningSystem;
        private readonly HealthController _healthController;
        private readonly SamuraiCanvas _samuraiCanvas;
        private readonly SpawnSystemConfiguration _spawnSystemConfiguration;
        private readonly float _duration;
        private readonly float _increaseBlocksCountInPackageBy;
        private readonly float _decreasePackageIntervalsBy;

        public EnableSamuraiModeCommand(SpawningSystem spawningSystem, 
            HealthController healthController,
            SamuraiCanvas samuraiCanvas,
            SpawnSystemConfiguration spawnSystemConfiguration,
            float duration, 
            float increaseBlocksCountInPackageBy,
            float decreasePackageIntervalsBy)
        {
            _spawningSystem = spawningSystem;
            _healthController = healthController;
            _samuraiCanvas = samuraiCanvas;
            _spawnSystemConfiguration = spawnSystemConfiguration;
            _duration = duration;
            _increaseBlocksCountInPackageBy = increaseBlocksCountInPackageBy;
            _decreasePackageIntervalsBy = decreasePackageIntervalsBy;
        }
        public void OnDestroy(Block entity, BlockDestroyContext destroyContext)
        {
            var samuraiSpawningDifficulty = new SamuraiModeSpawningDifficulty(_spawnSystemConfiguration,
                _increaseBlocksCountInPackageBy, _decreasePackageIntervalsBy);
            _samuraiCanvas.Show(_duration);
            _healthController.DisableHeartRemoving(_duration);
            _spawningSystem.ChangeSpawnDifficulty(samuraiSpawningDifficulty, _duration - 1);
        }
    }
}