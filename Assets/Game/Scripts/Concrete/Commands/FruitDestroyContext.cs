using Abstracts.Commands;
using UnityEngine;

namespace Concrete.Commands
{
    public class FruitDestroyContext : IDestroyContext
    {
        public Vector2 SlicingVector { get; set; }
        public Vector2 SlicingPoint { get; set; }
    }
}