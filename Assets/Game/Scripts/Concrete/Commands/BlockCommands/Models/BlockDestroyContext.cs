using Abstracts.Commands;
using UnityEngine;

namespace Concrete.Commands.BlockCommands.Models
{
    public class BlockDestroyContext : IDestroyContext
    {
        public Vector2 SlicingVector { get; set; }
        public Vector2 SlicingPoint { get; set; }
    }
}