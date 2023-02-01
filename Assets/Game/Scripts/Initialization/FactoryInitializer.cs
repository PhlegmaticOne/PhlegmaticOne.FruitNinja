using Abstracts.Factories;
using Concrete.Factories;
using Entities.Base;
using UnityEngine;

namespace Initialization
{
    public class FactoryInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private CuttableBlock _prefab;
        public IFactory<BlockCreationContext, CuttableBlock> CreateFactory()
        {
            return new FruitsFactory(_parent, _prefab);
        }
    }
}