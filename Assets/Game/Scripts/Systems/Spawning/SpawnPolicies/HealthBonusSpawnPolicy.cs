using Systems.Health;

namespace Spawning.Spawning.SpawnPolicies
{
    public class HealthBonusSpawnPolicy : ISpawnPolicy
    {
        private readonly HealthSystem _healthSystem;

        public HealthBonusSpawnPolicy(HealthSystem healthSystem) => _healthSystem = healthSystem;

        public bool CanSpawn() => _healthSystem.CurrentHeartsCount < _healthSystem.MaxHeartsCount;
    }
}