using Spawning;
using UnityEngine;

namespace Initialization
{
    public class GameComposite : MonoBehaviour
    {
        [SerializeField] private CuttableBlocksSpawningSystem _cuttableBlocksSpawner;
        [SerializeField] private FactoryInitializer _factoryInitializer;
        private void Awake()
        {
            _cuttableBlocksSpawner.Initialize(_factoryInitializer.CreateFactory());
        }
    }
}