using Abstracts.Factories;
using Entities.Base;
using UnityEngine;

namespace Concrete.Factories.Blocks
{
    public class FromBlockBlockCreationContext : ICreationContext
    {
        public Block OriginalBlock { get; set; }
        public Sprite BlockNewSprite { get; set; }
        public Vector2 MultiplySpeedBy { get; set; }
    }
}