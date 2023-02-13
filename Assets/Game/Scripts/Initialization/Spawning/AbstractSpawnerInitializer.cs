using Abstracts.Initialization;
using Configurations;
using Spawning.Spawning.Spawners;
using UnityEngine;

namespace Initialization.Spawning
{
    public class AbstractSpawnerInitializer : InitializerBase<IAbstractSpawner>
    {
        [SerializeField] private AbstractSpawnerConfiguration _abstractSpawnerConfiguration;
        public override IAbstractSpawner Create() => 
            new AbstractSpawner(_abstractSpawnerConfiguration.BuildBlockFactories());
    }
}