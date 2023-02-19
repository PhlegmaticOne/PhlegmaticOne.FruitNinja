using System.Collections.Generic;
using Abstracts.Commands;
using UnityEngine;

namespace Concrete.Commands.BlockCommands.Models
{
    public class BlockDestroyContext : IDestroyContext
    {
        private readonly Dictionary<string, object> _additionalParameters;
        
        public Vector2 SlicingVector { get; set; }
        public Vector2 SlicingPoint { get; set; }

        public void AddParameter(string key, object value) => _additionalParameters.Add(key, value);
        public T GetParameter<T>(string key) => (T)_additionalParameters[key];
    }
}