using Abstracts.Initialization;
using Spawning.Spawning.SpawnPolicies;
using Systems.Health;
using UnityEngine;

namespace Initialization.Spawning.SpawnPolicies
{
    public class HealthBonusSpawnPolicyInitializer : InitializerBase<ISpawnPolicy>
    {
        [SerializeField] private HealthSystem _healthSystem;
        public override ISpawnPolicy Create() => new HealthBonusSpawnPolicy(_healthSystem);
    }
}