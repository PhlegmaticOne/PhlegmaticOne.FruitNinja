using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Configurations;

namespace Spawning.Spawning.Packages
{
    public class BlocksPackage : IEnumerable<PackageEntry>
    {
        private readonly List<PackageEntry> _blockInfos;
        public int BlocksCount => _blockInfos.Count;

        public BlocksPackage(List<PackageEntry> blockInfos) => _blockInfos = blockInfos;

        public IEnumerator<PackageEntry> GetEnumerator() => _blockInfos.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PackageEntry
    {
        public BlockInfo BlockInfo { get; set; }
        public float TimeToNextBlock { get; set; }
    }
}