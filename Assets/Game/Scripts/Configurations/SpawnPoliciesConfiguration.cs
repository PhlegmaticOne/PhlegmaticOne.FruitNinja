using System;
using System.Collections.Generic;
using System.Linq;
using Abstracts.Initialization;
using Spawning.Spawning.SpawnPolicies;
using UnityEngine;

namespace Configurations
{
    public class SpawnPoliciesConfiguration : MonoBehaviour
    {
        [SerializeField] private List<SpawnPolicyInfo> _spawnPolicyInfos;

        public IDictionary<BlockInfo, ISpawnPolicy> BuildSpawnPolicies()
        {
            return _spawnPolicyInfos.ToDictionary(x => x.BlockInfo, x => x.SpawnPolicyInitializer.Create());
        }
    }

    [Serializable]
    public class SpawnPolicyInfo
    {
        [SerializeField] private BlockInfo _blockInfo;
        [SerializeField] private InitializerBase<ISpawnPolicy> _spawnPolicyInitializer;

        public BlockInfo BlockInfo => _blockInfo;
        public InitializerBase<ISpawnPolicy> SpawnPolicyInitializer => _spawnPolicyInitializer;
    }
}