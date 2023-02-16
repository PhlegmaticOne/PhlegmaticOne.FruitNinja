using Abstracts.Factories;
using Entities.Base;
using UnityEngine;

namespace Concrete.Factories.Blocks.Models
{
    public class FromBlockBlockCreationContext : ICreationContext
    {
        public Block OriginalBlock { get; set; }
        public Sprite BlockNewSprite { get; set; }
        public Vector2 MultiplySpeedBy { get; set; }
        public Vector2 Offset { get; set; }
        public int Direction { get; set; }
    }
}