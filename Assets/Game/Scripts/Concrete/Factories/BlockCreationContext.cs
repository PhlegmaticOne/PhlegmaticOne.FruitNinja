using Abstracts.Factories;
using Configurations;
using UnityEngine;

namespace Concrete.Factories
{
    public class BlockCreationContext : ICreationContext
    {
        public Vector2 Position { get; set; }
        public Vector2 InitialSpeed { get; set; }
        public BlockInfo BlockInfo { get; set; }
        public float BlockGravity { get; set; }
    }
}